package com.onework.tools.domain.database.impl;

import com.onework.tools.domain.database.*;
import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.domain.database.dao.Connection;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;
import com.onework.tools.domain.database.schema.*;
import lombok.NonNull;
import org.springframework.beans.BeanUtils;

import javax.sql.DataSource;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.impl
 * @Description: 描述
 * @date Date : 2022年03月29日 10:38
 */
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
    public void saveConnection(@NonNull Connection connection, Boolean sync) throws DatabaseDomainException {

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());

        if (dbConnection != null) {
            BeanUtils.copyProperties(connection, dbConnection);
            connectionRepository.addOrUpdateConnection(dbConnection);
        } else
            connectionRepository.addOrUpdateConnection(connection);

        if (sync)
            syscDatabase(connection);
    }

    @Override
    public Boolean testConnection(@NonNull Connection connection) throws DatabaseDomainException {

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        return dbSchemaServer.TestConnection();
    }

    @Override
    public void deleteConnection(@NonNull Connection connection) {

        Connection dbConnection = connectionRepository.getConnectionByName(connection.getName());
        connectionRepository.deleteConnection(dbConnection.getName());
    }

    @Override
    public void syscDatabase(@NonNull Connection connection) throws DatabaseDomainException {

        DbSchemaServer dbSchemaServer = getDbSchemaServer(connection);
        if (!dbSchemaServer.TestConnection())
            throw new DatabaseDomainException(DatabaseDomainErrorTemplate.DbConnectionError);
        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabases();
        handleDatabase(connection, dataDatabases);
    }

    /**
     * @param dataDatabases
     */
    private void handleDatabase(@NonNull Connection connection, @NonNull List<DataDatabase> dataDatabases) {

        for (DataDatabase dataDatabase : dataDatabases) {

            Database database = new Database();
            database.setConnUid(connection.getUid());
            database.setName(dataDatabase.getDbName());
            databaseRepository.addOrUpdateDatabase(connection.getName(), database);

            handleTable(database, dataDatabase.getTables());
        }
    }

    private void handleTable(@NonNull Database database, @NonNull List<DataTable> dataTables) {

        for (DataTable dataTable : dataTables) {

            Table table = new Table();
            table.setConnUid(database.getConnUid());
            table.setDbUid(database.getUid());
            table.setName(dataTable.getTbName());
            tableRepository.addOrUpdateTable(database, table);

            handleColumn(database, table, dataTable.getColumns());
        }
    }

    private void handleColumn(@NonNull Database database, @NonNull Table table, @NonNull List<DataColumn> columns) {

        for (DataColumn dataColumn : columns) {

            Column column = new Column();
            column.setConnUid(database.getConnUid());
            column.setDbUid(database.getUid());
            column.setTbUid(table.getUid());
            BeanUtils.copyProperties(dataColumn, column);
            columnRepository.addOrUpdateColumn(table, column);
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

        if (dbSchemaServer == null)
            throw new DatabaseDomainException(DatabaseDomainErrorTemplate.DbSchemaServerError);

        return dbSchemaServer;
    }
}
