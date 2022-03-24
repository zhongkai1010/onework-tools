package com.onework.tools.database;

import lombok.extern.slf4j.Slf4j;
import org.springframework.jdbc.core.JdbcTemplate;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.database
 * @Description: 描述
 * @date Date : 2022年03月23日 14:56
 */
@Slf4j
public abstract class DbSchemaServer {

    private final DbConnection dbConnection;

    protected DbSchemaServer(DbConnection dbConnection) {
        this.dbConnection = dbConnection;
    }

    /**
     * 获取
     * @return
     */
    protected abstract String getDatabasesSql();

    /**
     * 获取
     * @param dbName
     * @return
     */
    protected abstract String getTablesSql(String dbName);

    /**
     *  获取
     * @param dbName
     * @param dbTable
     * @return
     */
    protected abstract String getColumnsSql(String dbName, String dbTable);

    public List<DataColumn> getDataColumns(String dbName, String dbTable) {
        JdbcTemplate jdbcTemplate = new JdbcTemplate(this.dbConnection.getDataSource());
        return getInternalDataColumns(jdbcTemplate, dbName, dbTable);
    }

    public List<DataTable> getDataTables(String dbName) {
        JdbcTemplate jdbcTemplate = new JdbcTemplate(this.dbConnection.getDataSource());
        return getInternalDataTables(jdbcTemplate, dbName);
    }

    public List<DataDatabase> getDatabases() {
        String sql = getDatabasesSql();
        JdbcTemplate jdbcTemplate = new JdbcTemplate(this.dbConnection.getDataSource());
        return jdbcTemplate.query(sql, new DataDatabaseMapper());
    }

    public List<DataDatabase> getDatabaseAndTables() {
        String sql = getDatabasesSql();
        JdbcTemplate jdbcTemplate = new JdbcTemplate(this.dbConnection.getDataSource());
        List<DataDatabase> dataDatabases = jdbcTemplate.query(sql, new DataDatabaseMapper());

        dataDatabases.forEach(s -> s.setTables(getInternalDataTables(jdbcTemplate, s.getDbName())));
        return dataDatabases;
    }

    private List<DataColumn> getInternalDataColumns(JdbcTemplate jdbcTemplate, String dbName, String dbTable) {
        String sql = getColumnsSql(dbName, dbTable);
        return jdbcTemplate.query(sql, new DataColumnMapper());
    }

    private List<DataTable> getInternalDataTables(JdbcTemplate jdbcTemplate, String dbName) {
        String tablesSql = getTablesSql(dbName);
        List<DataTable> dataTables = jdbcTemplate.query(tablesSql, new DataTableMapper());

        dataTables.forEach(s -> s.setColumns(getInternalDataColumns(jdbcTemplate, dbName, s.getTbName())));

        return dataTables;
    }
}
