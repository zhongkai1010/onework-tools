package com.onework.tools.domain.database;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.dao.Connection;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;
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
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Transactional;

import javax.sql.DataSource;
import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;
import java.util.List;

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

    public DatabaseServiceImpl(ConnectionRepository connectionRepository, DatabaseRepository databaseRepository,
        TableRepository tableRepository) {
        this.connectionRepository = connectionRepository;
        this.databaseRepository = databaseRepository;
        this.tableRepository = tableRepository;
    }

    @Override
    @Transactional(rollbackFor = Exception.class, isolation = Isolation.READ_COMMITTED)
    public ExecuteResult saveConnection(@NonNull Connection connection, Boolean sync) {

        ExecuteResult executeResult = new ExecuteResult();

        Check.notNull(connection.getName(), new DatabaseDomainException(DomainDatabaseModule.CONNECTION_NAME_IS_NULL));

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        if (dbConnection != null) {
            BeanUtil.copyProperties(connection, dbConnection,new CopyOptions().ignoreNullValue());
            connectionRepository.updateConnection(dbConnection);
            connection.setUid(dbConnection.getUid());
        } else {
            connectionRepository.addConnection(connection);
        }

        if (sync) {
            handleConnection(connection);
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

        ExecuteResult executeResult = new ExecuteResult();

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        Check.notNull(dbConnection.getUid(), new DatabaseDomainException(DomainDatabaseModule.SYSC_CONNECTION_ERROR,
            new String[] {connection.getName()}));

        handleConnection(dbConnection);

        return executeResult.ok();
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
        handleTables(database, dataTables);

        // TODO 同步表

        database.setLastSyncDate(LocalDateTime.now());
        database.setIsSync(true);
        databaseRepository.updateDatabase(database);

        return executeResult.ok();
    }

    /**
     * @param connection
     */
    private void handleConnection(@NonNull Connection connection) {

        Check.notNull(connection.getUid(), new DatabaseDomainException(DomainDatabaseModule.SYSC_CONNECTION_ERROR,
            new String[] {connection.getName()}));

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (!dbSchemaServer.TestConnection()) {
            throw new DatabaseDomainException(DomainDatabaseModule.SYSC_CONNECTION_ERROR,
                new String[] {connection.getName()});
        }

        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabaseAndTables();
        handleDatabases(connection, dataDatabases);
    }

    /**
     * @param connection
     * @param dataDatabases
     * @return
     */
    private void handleDatabases(@NonNull Connection connection, @NonNull List<DataDatabase> dataDatabases) {

        Check.notNull(connection.getUid(), new DatabaseDomainException(DomainDatabaseModule.SYSC_CONNECTION_ERROR,
            new String[] {connection.getName()}));

        for (DataDatabase dataDatabase : dataDatabases) {

            Database database = new Database();
            database.setName(dataDatabase.getDbName());
            database.setCnUid(connection.getUid());
            databaseRepository.saveDatabase(database);

            List<DataTable> dataTables = dataDatabase.getTables();
            handleTables(database, dataTables);
        }
    }

    /**
     * @param database
     * @param dataTables
     * @return
     */
    private void handleTables(@NonNull Database database, @NonNull List<DataTable> dataTables) {

        //TODO 是否考虑同步之前，对比数据库表，将已删除的表也在数据中进行移除

        Check.notNull(database.getUid(),
            new DatabaseDomainException(DomainDatabaseModule.SYSC_DATABASE_CONNECTION_ERROR,
                new String[] {database.getName()}));
        Check.notNull(database.getCnUid(),
            new DatabaseDomainException(DomainDatabaseModule.SYSC_DATABASE_CONNECTION_ERROR,
                new String[] {database.getName()}));

        for (DataTable dataTable : dataTables) {
            Table table = new Table();
            table.setName(dataTable.getTbName());
            table.setCnUid(database.getCnUid());
            table.setDbUid(database.getUid());
            table.setDbName(database.getName());
            tableRepository.addOrUpdateTable(table);
        }
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
