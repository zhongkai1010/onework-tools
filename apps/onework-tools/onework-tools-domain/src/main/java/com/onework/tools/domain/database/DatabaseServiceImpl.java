package com.onework.tools.domain.database;

import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.dao.Connection;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;
import com.onework.tools.domain.database.repository.ColumnRepository;
import com.onework.tools.domain.database.repository.ConnectionRepository;
import com.onework.tools.domain.database.repository.DatabaseRepository;
import com.onework.tools.domain.database.repository.TableRepository;
import com.onework.tools.domain.database.schema.DatabaseType;
import com.onework.tools.domain.database.schema.DbSchemaFactory;
import com.onework.tools.domain.database.schema.DbSchemaServer;
import com.onework.tools.domain.database.schema.entity.DataDatabase;
import com.onework.tools.domain.database.schema.entity.DataTable;
import lombok.NonNull;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.BeanUtils;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Transactional;

import javax.sql.DataSource;
import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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
        TableRepository tableRepository, ColumnRepository columnRepository, ColumnRepository columnRepository1) {
        this.connectionRepository = connectionRepository;
        this.databaseRepository = databaseRepository;
        this.tableRepository = tableRepository;
        this.columnRepository = columnRepository1;
    }

    @Override
    @Transactional(rollbackFor = Exception.class, isolation = Isolation.READ_COMMITTED)
    public ExecuteResult saveConnection(@NonNull Connection connection, Boolean sync) {

        ExecuteResult executeResult = new ExecuteResult();

        Check.notNull(connection.getName(), new DatabaseDomainException(DomainDatabaseModule.CONNECTION_NAME_IS_NULL));

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        if (dbConnection != null) {
            BeanUtils.copyProperties(connection, dbConnection);
            connectionRepository.updateConnection(dbConnection);
        } else {
            connectionRepository.addConnection(connection);
        }

        if (sync) {
            DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
            List<DataDatabase> dataDatabases = dbSchemaServer.getDatabaseAndTables();
            handleDatabases(connection.getUid(), dataDatabases);
        }

        return executeResult.ok();
    }

    @Override
    public ExecuteResult testConnection(@NonNull Connection connection) {

        ExecuteResult executeResult = new ExecuteResult();
        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (dbSchemaServer.TestConnection()) {
            return executeResult.ok();
        }
        return executeResult;
    }

    @Override
    public ExecuteResult deleteConnection(@NonNull Connection connection) {

        ExecuteResult executeResult = new ExecuteResult();
        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        String connectionName = dbConnection.getName();
        connectionRepository.deleteConnection(connectionName);
        return executeResult.ok();
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult syscConnection(@NotNull Connection connection) {

        //        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        //
        //        if (!dbSchemaServer.TestConnection()) {
        //            throw new DatabaseDomainException(DomainDatabaseModule.DB_CONNECTION_ERROR);
        //        }
        //
        //        // 同步数据库和表
        //        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabaseAndTables();
        //        handleDatabases(connection, dataDatabases);

        //        // 同步字段信息
        //        tableMap.forEach((database, tables) -> {
        //            //计算线程数
        //            int size = tables.size();
        //            int processCount = 1;
        //            if (size > max) {
        //                processCount = (size / max) + ((size % max == 0 ? 0 : 1));
        //            }
        //            // 开启线程
        //            int index = 0;
        //            int toIndex = max;
        //            for (int i = 0; i < processCount; i++) {
        //
        //                List<Table> subTables = tables.subList(index, toIndex);
        //                TableBatchHandle tableBatchHandle = new TableBatchHandle(database, subTables, columnRepository);
        //                Thread thread = new Thread(tableBatchHandle);
        //                thread.start();
        //                toIndex += max + (i == 0 ? 1 : 0);
        //            }
        //        });

        return new ExecuteResult();
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult syscDatabase(@NotNull String connName, @NonNull String dbName) {

        ExecuteResult executeResult = new ExecuteResult();

        Connection connection = connectionRepository.getConnectionByName(connName);
        Check.notNull(connection, new DatabaseDomainException(DomainDatabaseModule.DB_CONNECTION_ERROR));
        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);

        Database database = databaseRepository.getDatabaseByName(connection.getUid(), dbName);
        Check.notNull(database, new DatabaseDomainException(DomainDatabaseModule.DB_CONNECTION_ERROR));

        List<DataTable> dataTables = dbSchemaServer.getDataTables(dbName);
        handleTables(database.getUid(), dbName, dataTables);

        database.setLastSyncDate(LocalDateTime.now());
        database.setIsSync(true);
        databaseRepository.updateDatabase(database);

        return executeResult.ok();
    }

    /**
     * @param connection
     */
    private void internalSyscDatabase(@NotNull Connection connection, Database database) {

    }

    /**
     * @param connUid
     * @param dataDatabases
     * @return
     */
    private Map<Database, List<Table>> handleDatabases(@NonNull String connUid,
        @NonNull List<DataDatabase> dataDatabases) {

        Map<Database, List<Table>> tableMap = new HashMap<>(16);

        for (DataDatabase dataDatabase : dataDatabases) {

            Database database = new Database();
            database.setName(dataDatabase.getDbName());
            database.setCnUid(connUid);
            databaseRepository.saveDatabase(database);

            String dbUid = database.getUid();
            String dbName = database.getName();

            List<DataTable> dataTables = dataDatabase.getTables();
            List<Table> tables = handleTables(dbUid, dbName, dataTables);
            tableMap.put(database, tables);
        }
        return tableMap;
    }

    /**
     * @param dbUid
     * @param dbName
     * @param dataTables
     * @return
     */
    private List<Table> handleTables(@NonNull String dbUid, @NonNull String dbName,
        @NonNull List<DataTable> dataTables) {

        //TODO 是否考虑同步之前，对比数据库表，将已删除的表也在数据中进行移除

        List<Table> tables = new ArrayList<>();

        for (DataTable dataTable : dataTables) {

            Table table = new Table();
            table.setName(dataTable.getTbName());
            table.setCnUid(dbUid);
            table.setDbUid(dbName);
            tableRepository.addOrUpdateTable(table);

            tables.add(table);
        }

        return tables;
    }

    /**
     * @param connection
     * @return
     */
    private static DbSchemaServer getDbSchemaServer(@NonNull Connection connection) throws DatabaseDomainException {
        DataSource dataSource = connection.getDbConnection().build();
        DatabaseType databaseType = DatabaseType.Map.get(connection.getDbType());
        DbSchemaServer dbSchemaServer = DbSchemaFactory.getDbSchemaServer(databaseType, dataSource);

        if (dbSchemaServer == null) {
            throw new DatabaseDomainException(DomainDatabaseModule.DB_SCHEMA_SERVER_ERROR);
        }

        return dbSchemaServer;
    }

}
