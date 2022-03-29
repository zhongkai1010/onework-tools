package com.onework.tools.domain.database.schema;

import lombok.extern.slf4j.Slf4j;
import org.springframework.jdbc.core.JdbcTemplate;

import javax.sql.DataSource;
import java.util.ArrayList;
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

    private final JdbcTemplate jdbcTemplate;

    protected DbSchemaServer(DataSource dataSource) {

        jdbcTemplate = new JdbcTemplate(dataSource);
    }

    /**
     * 获取
     *
     * @return
     */
    protected abstract String getDatabasesSql();

    /**
     * 获取
     *
     * @param dbName
     * @return
     */
    protected abstract String getTablesSql(String dbName);

    /**
     * 获取
     *
     * @param dbName
     * @param dbTable
     * @return
     */
    protected abstract String getColumnsSql(String dbName, String dbTable);

    /**
     * 测试连接
     *
     * @return
     */
    public Boolean TestConnection() {
        try {
            jdbcTemplate.execute("select 1");
            return true;
        } catch (Exception exception) {
            log.error("dbSchemaServer testConnection error", exception);
            return false;
        }
    }

    /**
     * @param dbName
     * @param dbTable
     * @return
     */
    public List<DataColumn> getDataColumns(String dbName, String dbTable) {
        return getInternalDataColumns(dbName, dbTable);
    }

    /**
     * @param dbName
     * @return
     */
    public List<DataTable> getDataTables(String dbName) {
        return getInternalDataTables(dbName);
    }

    /**
     * @return
     */
    public List<DataDatabase> getDatabases() {

        try {
            String sql = getDatabasesSql();
            return jdbcTemplate.query(sql, new DataDatabaseMapper());
        } catch (Exception exception) {
            log.error("DbSchemaServer getDatabases error", exception);
            return new ArrayList<>();
        }

    }

    /**
     * @return
     */
    public List<DataDatabase> getDatabaseAndTables() {

        try {
            String sql = getDatabasesSql();
            List<DataDatabase> dataDatabases = jdbcTemplate.query(sql, new DataDatabaseMapper());

            dataDatabases.forEach(s -> s.setTables(getInternalDataTables(s.getDbName())));
            return dataDatabases;
        } catch (Exception exception) {
            log.error("DbSchemaServer getDatabaseAndTables error", exception);
            return new ArrayList<>();
        }
    }

    /**
     * @param dbName
     * @param dbTable
     * @return
     */
    private List<DataColumn> getInternalDataColumns(String dbName, String dbTable) {

        try {
            String sql = getColumnsSql(dbName, dbTable);
            return jdbcTemplate.query(sql, new DataColumnMapper());
        } catch (Exception exception) {
            log.error("DbSchemaServer getInternalDataColumns error", exception);
            return new ArrayList<>();
        }
    }

    /**
     * @param dbName
     * @return
     */
    private List<DataTable> getInternalDataTables(String dbName) {

        try {
            String tablesSql = getTablesSql(dbName);
            List<DataTable> dataTables = jdbcTemplate.query(tablesSql, new DataTableMapper());

            dataTables.forEach(s -> s.setColumns(getInternalDataColumns(dbName, s.getTbName())));

            return dataTables;
        } catch (Exception exception) {
            log.error("DbSchemaServer getInternalDataTables error", exception);
            return new ArrayList<>();
        }
    }
}
