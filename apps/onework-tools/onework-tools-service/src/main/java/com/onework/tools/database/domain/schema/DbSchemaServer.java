package com.onework.tools.database.domain.schema;

import com.onework.tools.database.domain.schema.entity.DataColumn;
import com.onework.tools.database.domain.schema.entity.DataDatabase;
import com.onework.tools.database.domain.schema.entity.DataTable;
import com.onework.tools.database.domain.schema.mapper.DataColumnMapper;
import com.onework.tools.database.domain.schema.mapper.DataDatabaseMapper;
import com.onework.tools.database.domain.schema.mapper.DataTableMapper;
import lombok.NonNull;
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
     * 获取数据库所有字段Sql
     *
     * @param dbName
     * @return
     */
    protected abstract String getDatabaseAllColumnSql(String dbName);

    /**
     * 测试连接
     *
     * @return
     */
    public Boolean testConnection() {
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
            List<DataDatabase> dataDatabases = jdbcTemplate.query(sql, new DataDatabaseMapper());

            log.info(String.format("%s:%s", "DbSchemaServer getDatabases", sql));

            return dataDatabases;

        } catch (Exception exception) {
            log.error("DbSchemaServer getDatabases error", exception);
            return new ArrayList<>();
        }

    }

    public List<DataColumn> getDatabaseAllColumn(String dbName) {
        try {
            String sql = getDatabaseAllColumnSql(dbName);
            List<DataColumn> dataColumns = jdbcTemplate.query(sql, new DataColumnMapper());

            log.info(String.format("%s:%s", "DbSchemaServer getDatabaseAllColumn", sql));

            return dataColumns;

        } catch (Exception exception) {
            log.error("DbSchemaServer getDatabaseAllColumn error", exception);
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

            log.info(String.format("%s:%s", "DbSchemaServer getDatabaseAndTables", sql));

            for (DataDatabase db : dataDatabases) {
                String dbName = db.getDbName();
                List<DataTable> dataTables = getInternalDataTables(dbName);
                db.setTables(dataTables);
            }

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
            List<DataColumn> dataColumns = jdbcTemplate.query(sql, new DataColumnMapper());

            log.info(String.format("%s:%s", "DbSchemaServer getInternalDataColumns", sql));

            return dataColumns;

        } catch (Exception exception) {
            log.error("DbSchemaServer getInternalDataColumns error", exception);
            return new ArrayList<>();
        }
    }

    /**
     * @param dbName
     * @return
     */
    private List<DataTable> getInternalDataTables(@NonNull String dbName) {

        try {
            String tablesSql = getTablesSql(dbName);
            List<DataTable> dataTables = jdbcTemplate.query(tablesSql, new DataTableMapper());

            log.info(String.format("%s:%s", "DbSchemaServer getInternalDataTables", tablesSql));

            return dataTables;

        } catch (Exception exception) {
            log.error("DbSchemaServer getInternalDataTables error", exception);
            return new ArrayList<>();
        }
    }
}
