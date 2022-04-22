package com.onework.tools.database.domain;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import cn.hutool.core.collection.CollUtil;
import cn.hutool.core.thread.ThreadUtil;
import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.database.DatabaseException;
import com.onework.tools.database.DatabaseModule;
import com.onework.tools.database.domain.entity.Column;
import com.onework.tools.database.domain.entity.Connection;
import com.onework.tools.database.domain.entity.Database;
import com.onework.tools.database.domain.entity.Table;
import com.onework.tools.database.domain.repository.ColumnRepository;
import com.onework.tools.database.domain.repository.ConnectionRepository;
import com.onework.tools.database.domain.repository.DatabaseRepository;
import com.onework.tools.database.domain.repository.TableRepository;
import com.onework.tools.database.schema.DatabaseType;
import com.onework.tools.database.schema.DbSchemaFactory;
import com.onework.tools.database.schema.DbSchemaServer;
import com.onework.tools.database.schema.entity.DataColumn;
import com.onework.tools.database.schema.entity.DataDatabase;
import com.onework.tools.database.schema.entity.DataTable;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Transactional;

import javax.sql.DataSource;
import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ThreadPoolExecutor;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.impl
 * @Description: 描述
 * @date Date : 2022年03月29日 10:38
 */
@Service
@Slf4j
public class DatabaseServiceImpl implements DatabaseService {

    private final ConnectionRepository connectionRepository;
    private final DatabaseRepository databaseRepository;
    private final TableRepository tableRepository;
    private final ColumnRepository columnRepository;

    public DatabaseServiceImpl(ConnectionRepository connectionRepository, DatabaseRepository databaseRepository,
        TableRepository tableRepository, ColumnRepository columnRepository) {
        this.connectionRepository = connectionRepository;
        this.databaseRepository = databaseRepository;
        this.tableRepository = tableRepository;
        this.columnRepository = columnRepository;

    }

    @Override
    @Transactional(rollbackFor = Exception.class, isolation = Isolation.READ_COMMITTED)
    public ExecuteResult saveConnection(@NotNull Connection connection, Boolean sync) {

        Check.notNull(connection.getName(), new DatabaseException(DatabaseModule.CONNECTION_NAME_IS_NULL));

        Connection oldConnection = connectionRepository.getConnectionByName(connection.getName());
        if (oldConnection != null) {
            BeanUtil.copyProperties(connection, oldConnection, new CopyOptions().ignoreNullValue());
            connectionRepository.updateConnection(oldConnection);
            connection.setUid(oldConnection.getUid());
        } else {
            connectionRepository.addConnection(connection);
        }

        if (sync) {
            handleConnection(connection);
        }

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult testConnection(@NotNull Connection connection) {

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (dbSchemaServer.TestConnection()) {
            return ExecuteResult.success();
        }
        return ExecuteResult.failure();
    }

    @Override
    public ExecuteResult deleteConnection(@NotNull Connection connection) {

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        String connectionName = dbConnection.getName();
        connectionRepository.deleteConnection(connectionName);
        return ExecuteResult.success();
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult syscConnection(@NotNull Connection connection) {

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        Check.notNull(dbConnection.getUid(),
            new DatabaseException(DatabaseModule.SYSC_CONNECTION_ERROR, new String[] {connection.getName()}));

        handleConnection(dbConnection);

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult syscDatabase(@NotNull String connName, @NotNull String dbName) {

        Connection connection = connectionRepository.getConnectionByName(connName);
        Check.notNull(connection, new DatabaseException(DatabaseModule.DB_CONNECTION_ERROR));

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);

        Database database = databaseRepository.getDatabaseByName(connection.getUid(), dbName);
        Check.notNull(database, new DatabaseException(DatabaseModule.DB_CONNECTION_ERROR));

        // 同步数据库表前，移除数据库表
        tableRepository.batchDeleteTable(database);
        List<DataTable> dataTables = dbSchemaServer.getDataTables(dbName);
        List<Table> tables = handleTables(database, dataTables);

        //        handleColumns(dbSchemaServer, tables);
        //        database.setLastSyncDate(LocalDateTime.now());
        //        database.setIsSync(true);
        //        databaseRepository.updateDatabase(database);
        //        return executeResult.ok();

        final int pageSize = 10;
        int pageCount = (tables.size() + pageSize - 1) / pageSize;
        ThreadPoolExecutor threadPoolExecutor = ThreadUtil.newExecutor(pageCount, pageCount);
        for (int i = 0; i < pageCount; i++) {
            int page = i;
            threadPoolExecutor.execute(() -> {
                //                // 1.获取事务定义
                //                DefaultTransactionDefinition def = new DefaultTransactionDefinition();
                //                // 2.设置事务隔离级别，开启新事务
                //                def.setPropagationBehavior(TransactionDefinition.PROPAGATION_REQUIRES_NEW);
                //                TransactionStatus status = dataSourceTransactionManager.getTransaction(def);
                try {
                    List<Table> pageTables = CollUtil.page(page, pageSize, tables);
                    handleColumns(dbSchemaServer, pageTables);
                } catch (Exception ex) {
                    // dataSourceTransactionManager.rollback(status);
                    log.error(String.format("%s：批量提交失败", Thread.currentThread().getName()), ex);
                }
                // 3.提交事务
                //dataSourceTransactionManager.commit(status);
            });
        }
        while (true) {
            int count = threadPoolExecutor.getActiveCount();
            if (count == 0) {
                database.setLastSyncDate(LocalDateTime.now());
                database.setIsSync(true);
                databaseRepository.updateDatabase(database);
                threadPoolExecutor.shutdown();

                return ExecuteResult.success();
            }
        }
    }

    /**
     * @param tables
     */
    private void handleColumns(@NotNull DbSchemaServer dbSchemaServer, @NotNull List<Table> tables) {

        for (Table table : tables) {
            Check.notNull(new DatabaseException(DatabaseModule.SYSC_TABLE_ERROR,
                new String[] {table.getCnUid(), table.getDbUid(), table.getDbName(), table.getUid(), table.getName()}));

            List<DataColumn> dataColumns = dbSchemaServer.getDataColumns(table.getDbName(), table.getName());
            List<Column> columns = new ArrayList<>();
            for (DataColumn dataColumn : dataColumns) {
                columns.add(Column.getColumn(dataColumn, table));
            }
            columnRepository.batchDeleteColumn(table);
            columnRepository.batchAddColumn(columns);
        }
    }

    /**
     * @param connection
     */
    private void handleConnection(@NotNull Connection connection) {

        Check.notNull(connection.getUid(),
            new DatabaseException(DatabaseModule.SYSC_CONNECTION_ERROR, new String[] {connection.getName()}));

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (!dbSchemaServer.TestConnection()) {
            throw new DatabaseException(DatabaseModule.SYSC_CONNECTION_ERROR, new String[] {connection.getName()});
        }

        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabaseAndTables();
        handleDatabases(connection, dataDatabases);
    }

    /**
     * List<DataTable> dataTables = dataDatabase.getTables();
     * handleTables(database, dataTables);
     *
     * @param connection
     * @param dataDatabases
     * @return
     */
    private void handleDatabases(@NotNull Connection connection, @NotNull List<DataDatabase> dataDatabases) {

        Check.notNull(connection.getUid(),
            new DatabaseException(DatabaseModule.SYSC_CONNECTION_ERROR, new String[] {connection.getName()}));

        for (DataDatabase dataDatabase : dataDatabases) {
            Database database = Database.getDatabase(connection, dataDatabase);
            databaseRepository.saveDatabase(database);
        }
    }

    /**
     * @param database
     * @param dataTables
     * @return
     */
    private List<Table> handleTables(@NotNull Database database, @NotNull List<DataTable> dataTables) {

        Check.notNull(database.getUid(),
            new DatabaseException(DatabaseModule.SYSC_DATABASE_CONNECTION_ERROR, new String[] {database.getName()}));
        Check.notNull(database.getCnUid(),
            new DatabaseException(DatabaseModule.SYSC_DATABASE_CONNECTION_ERROR, new String[] {database.getName()}));

        List<Table> tables = new ArrayList<>();
        for (DataTable dataTable : dataTables) {
            tables.add(Table.getTable(database, dataTable));
        }
        return tableRepository.batchAddTable(tables);
    }

    /**
     * @param connection
     * @return
     */
    private static DbSchemaServer getDbSchemaServer(@NotNull Connection connection) throws DatabaseException {
        DataSource dataSource = connection.getDbConnection().build();
        DatabaseType databaseType = DatabaseType.Map.get(connection.getDbType());
        DbSchemaServer dbSchemaServer = DbSchemaFactory.getDbSchemaServer(databaseType, dataSource);

        if (dbSchemaServer == null) {
            throw new DatabaseException(DatabaseModule.DB_SCHEMA_SERVER_ERROR);
        }

        return dbSchemaServer;
    }

}
