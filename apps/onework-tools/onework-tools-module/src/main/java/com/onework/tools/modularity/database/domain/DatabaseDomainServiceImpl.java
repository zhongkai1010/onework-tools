package com.onework.tools.modularity.database.domain;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import cn.hutool.core.collection.CollUtil;
import cn.hutool.core.thread.ThreadUtil;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.database.DatabaseException;
import com.onework.tools.modularity.database.domain.repository.ColumnRepository;
import com.onework.tools.modularity.database.domain.repository.ConnectionRepository;
import com.onework.tools.modularity.database.domain.repository.DatabaseRepository;
import com.onework.tools.modularity.database.domain.repository.TableRepository;
import com.onework.tools.modularity.database.domain.schema.DatabaseType;
import com.onework.tools.modularity.database.domain.schema.DbSchemaFactory;
import com.onework.tools.modularity.database.domain.schema.DbSchemaServer;
import com.onework.tools.modularity.database.domain.schema.entity.DataColumn;
import com.onework.tools.modularity.database.domain.schema.entity.DataDatabase;
import com.onework.tools.modularity.database.domain.schema.entity.DataTable;
import com.onework.tools.modularity.database.domain.vo.ColumnVo;
import com.onework.tools.modularity.database.domain.vo.ConnectionVo;
import com.onework.tools.modularity.database.domain.vo.DatabaseVo;
import com.onework.tools.modularity.database.domain.vo.TableVo;
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
public class DatabaseDomainServiceImpl implements DatabaseDomainService {

    private final ConnectionRepository connectionRepository;
    private final DatabaseRepository databaseRepository;
    private final TableRepository tableRepository;
    private final ColumnRepository columnRepository;

    public DatabaseDomainServiceImpl(ConnectionRepository connectionRepository, DatabaseRepository databaseRepository,
        TableRepository tableRepository, ColumnRepository columnRepository) {
        this.connectionRepository = connectionRepository;
        this.databaseRepository = databaseRepository;
        this.tableRepository = tableRepository;
        this.columnRepository = columnRepository;

    }

    @Override
    @Transactional(rollbackFor = Exception.class, isolation = Isolation.READ_COMMITTED)
    public ExecuteResult<Boolean> saveConnection(@NotNull ConnectionVo connection, Boolean sync) {

        Check.notNull(connection.getName(), new AppException(DatabaseException.CONNECTION_NAME_IS_NULL));

        ConnectionVo oldConnection = connectionRepository.getConnectionByName(connection.getName());
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
    public ExecuteResult<Boolean> testConnection(@NotNull ConnectionVo connection) {

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (dbSchemaServer.testConnection()) {
            return ExecuteResult.success();
        }
        return ExecuteResult.failure();
    }

    @Override
    public ExecuteResult<Boolean> deleteConnection(@NotNull String connectionName) {

        connectionRepository.deleteConnection(connectionName);
        return ExecuteResult.success();
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult<Boolean> syscConnection(@NotNull String connectionName) {

        ConnectionVo dbConnection = connectionRepository.getConnectionByName(connectionName);
        Check.notNull(dbConnection.getUid(),
            new AppException(DatabaseException.SYSC_CONNECTION_ERROR, new String[] {connectionName}));

        handleConnection(dbConnection);

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult<Boolean> syscDatabase(@NotNull String connName, @NotNull String dbName) {

        ConnectionVo connection = connectionRepository.getConnectionByName(connName);
        Check.notNull(connection, new AppException(DatabaseException.DB_CONNECTION_ERROR));

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);

        DatabaseVo database = databaseRepository.getDatabaseByName(connection.getUid(), dbName);
        Check.notNull(database, new AppException(DatabaseException.DB_CONNECTION_ERROR));

        // 同步数据库表前，移除数据库表
        tableRepository.batchDeleteTable(database);
        List<DataTable> dataTables = dbSchemaServer.getDataTables(dbName);
        List<TableVo> tables = handleTables(database, dataTables);

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
                    List<TableVo> pageTables = CollUtil.page(page, pageSize, tables);
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
    private void handleColumns(@NotNull DbSchemaServer dbSchemaServer, @NotNull List<TableVo> tables) {

        for (TableVo table : tables) {
            Check.notNull(new AppException(DatabaseException.SYSC_TABLE_ERROR,
                new String[] {table.getCnUid(), table.getDbUid(), table.getDbName(), table.getUid(), table.getName()}));

            List<DataColumn> dataColumns = dbSchemaServer.getDataColumns(table.getDbName(), table.getName());
            List<ColumnVo> columns = new ArrayList<>();
            for (DataColumn dataColumn : dataColumns) {
                columns.add(ColumnVo.getColumn(dataColumn, table));
            }
            columnRepository.batchDeleteColumn(table);
            columnRepository.batchAddColumn(columns);
        }
    }

    /**
     * @param connection
     */
    private void handleConnection(@NotNull ConnectionVo connection) {

        Check.notNull(connection.getUid(),
            new AppException(DatabaseException.SYSC_CONNECTION_ERROR, new String[] {connection.getName()}));

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (!dbSchemaServer.testConnection()) {
            throw new AppException(DatabaseException.SYSC_CONNECTION_ERROR, new String[] {connection.getName()});
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
    private void handleDatabases(@NotNull ConnectionVo connection, @NotNull List<DataDatabase> dataDatabases) {

        Check.notNull(connection.getUid(),
            new AppException(DatabaseException.SYSC_CONNECTION_ERROR, new String[] {connection.getName()}));

        for (DataDatabase dataDatabase : dataDatabases) {
            DatabaseVo database = DatabaseVo.getDatabase(connection, dataDatabase);
            databaseRepository.saveDatabase(database);
        }
    }

    /**
     * @param database
     * @param dataTables
     * @return
     */
    private List<TableVo> handleTables(@NotNull DatabaseVo database, @NotNull List<DataTable> dataTables) {

        Check.notNull(database.getUid(),
            new AppException(DatabaseException.SYSC_DATABASE_CONNECTION_ERROR, new String[] {database.getName()}));
        Check.notNull(database.getCnUid(),
            new AppException(DatabaseException.SYSC_DATABASE_CONNECTION_ERROR, new String[] {database.getName()}));

        List<TableVo> tables = new ArrayList<>();
        for (DataTable dataTable : dataTables) {
            tables.add(TableVo.getTable(database, dataTable));
        }
        return tableRepository.batchAddTable(tables);
    }

    /**
     * @param connection
     * @return
     */
    private static DbSchemaServer getDbSchemaServer(@NotNull ConnectionVo connection) throws AppException {
        DataSource dataSource = connection.getDbConnection().build();
        DatabaseType databaseType = DatabaseType.Map.get(connection.getDbType());
        DbSchemaServer dbSchemaServer = DbSchemaFactory.getDbSchemaServer(databaseType, dataSource);

        if (dbSchemaServer == null) {
            throw new AppException(DatabaseException.DB_SCHEMA_SERVER_ERROR);
        }

        return dbSchemaServer;
    }

}
