package com.onework.tools.domain.database;

import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.dao.Column;
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
import com.onework.tools.domain.database.schema.entity.DataColumn;
import com.onework.tools.domain.database.schema.entity.DataDatabase;
import com.onework.tools.domain.database.schema.entity.DataTable;
import lombok.NonNull;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.BeanUtils;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.sql.DataSource;
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
    private final ColumnRepository columnRepository;

    public DatabaseServiceImpl(ConnectionRepository connectionRepository, DatabaseRepository databaseRepository,
        TableRepository tableRepository, ColumnRepository columnRepository) {
        this.connectionRepository = connectionRepository;
        this.databaseRepository = databaseRepository;
        this.tableRepository = tableRepository;
        this.columnRepository = columnRepository;
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
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
            internalSyscDatabase(connection);
        }

        return executeResult.ok();
    }

    @Override
    public ExecuteResult testConnection(@NonNull Connection connection) {

        ExecuteResult executeResult = new ExecuteResult();

        try {

            DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
            if (dbSchemaServer.TestConnection()) {
                return executeResult.ok();
            }

            return executeResult;

        } catch (Exception exception) {
            log.error(exception.getMessage(), exception);
            return executeResult.fail(exception);
        }
    }

    @Override
    public ExecuteResult deleteConnection(@NonNull Connection connection) {

        ExecuteResult executeResult = new ExecuteResult();

        try {
            Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
            String connectionName = dbConnection.getName();
            connectionRepository.deleteConnection(connectionName);
            return executeResult.ok();
        } catch (Exception exception) {
            log.error(exception.getMessage(), exception);
            return executeResult.fail(exception);
        }
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult syscDatabase(@NonNull String connectionName) {

        ExecuteResult executeResult = new ExecuteResult();

        Connection connection = connectionRepository.getConnectionByName(connectionName);
        Check.notNull(connection, new DatabaseDomainException(DomainDatabaseModule.DB_CONNECTION_ERROR));

        internalSyscDatabase(connection);

        return executeResult.ok();
    }

    private void internalSyscDatabase(Connection connection) throws DatabaseDomainException {

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);

        if (!dbSchemaServer.TestConnection()) {
            throw new DatabaseDomainException(DomainDatabaseModule.DB_CONNECTION_ERROR);
        }

        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabases();
        handleDatabase(connection, dataDatabases);
    }

    /**
     * @param dataDatabases
     */
    private void handleDatabase(@NonNull Connection connection, @NonNull List<DataDatabase> dataDatabases) {

        for (DataDatabase dataDatabase : dataDatabases) {

            Database database = new Database();
            database.setName(dataDatabase.getDbName());
            database.setCnUid(connection.getUid());
            databaseRepository.addOrUpdateDatabase(database);

            handleTable(database, dataDatabase.getTables());

            database.setIsSync(true);
            database.setLastSyncDate(LocalDateTime.now());
            databaseRepository.addOrUpdateDatabase(database);
        }
    }

    private void handleTable(@NonNull Database database, @NonNull List<DataTable> dataTables) {

        //TODO 是否考虑同步之前，对比数据库表，将已删除的表也在数据中进行移除

        for (DataTable dataTable : dataTables) {

            Table table = new Table();
            table.setName(dataTable.getTbName());
            table.setCnUid(database.getCnUid());
            table.setDbUid(database.getUid());

            tableRepository.addOrUpdateTable(table);

            handleColumn(database, table, dataTable.getColumns());
        }
    }

    private void handleColumn(@NonNull Database database, @NonNull Table table, @NonNull List<DataColumn> columns) {

        //TODO 是否考虑同步之前，对比表字段，将已删除的字段也在数据中进行移除

        for (DataColumn dataColumn : columns) {

            Column column = new Column();
            column.setCnUid(database.getCnUid());
            column.setDbUid(database.getUid());
            column.setTbUid(table.getUid());
            BeanUtils.copyProperties(dataColumn, column);

            columnRepository.addOrUpdateColumn(column);
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
