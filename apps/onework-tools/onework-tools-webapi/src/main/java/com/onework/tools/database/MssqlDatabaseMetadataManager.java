package com.onework.tools.database;

import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.sql.Driver;
import java.sql.SQLException;
import java.util.List;

/**
 * @ClassName: MssqlDatabaseMetadataManager
 * @Description: sql
 * @Author: 钟凯
 * @Date: 2021/12/14 21:25
 **/
@Component
@Slf4j
public class MssqlDatabaseMetadataManager extends AbstractMetadataManager {

    public MssqlDatabaseMetadataManager(DatabaseConnection databaseConnection) {
        super(databaseConnection);
    }

    /**
     * 返回jdbc驱动
     *
     * @return Driver
     */
    @Override
    protected Driver getDriver() throws SQLException {
        return new com.mysql.cj.jdbc.Driver();
    }

    /**
     * 描述
     *
     * @return List<Database>
     */
    @Override
    public List<String> getDatabase() {
        String sql = "select name from sysdatabases";
        return getDatabaseOrTableNames(sql);
    }

    /**
     * 描述
     *
     * @return List
     */
    @Override
    public List<String> getTables(String databaseName) {
        String sql = "use %s select * from sysobjects where xtype='U';";
        return getDatabaseOrTableNames(String.format(sql, databaseName));
    }

    /**
     * 描述
     *
     * @param databaseName
     *            数据库名称
     * @param tableName
     *            表名称
     * @return List<Column>
     */
    @Override
    public List<DataBaseColumn> getColumns(String databaseName, String tableName) {
        String sql =
            "USE %s SELECT 'order' = a.colorder, 'name' = a.name, 'primarykey' = CASE WHEN EXISTS( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid) ) ) THEN 1 ELSE 0 END, 'type' = b.name, 'length' = COLUMNPROPERTY( a.id , a.name, 'PRECISION' ), 'precision' = isnull( COLUMNPROPERTY( a.id, a.name , 'Scale' ), 0 ), 'allowNull' = CASE WHEN a.isnullable= 1 THEN 1 ELSE 0 END, 'defaultValue' = isnull( e.text , '' ), 'description' = isnull( g.[value], '' ) FROM syscolumns a LEFT JOIN systypes b ON a.xusertype = b.xusertype INNER JOIN sysobjects d ON a.id = d.id AND d.xtype= 'U' AND d.name <> 'dtproperties' LEFT JOIN syscomments e ON a.cdefault = e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0 WHERE a.id= OBJECT_ID( '%s' ) ORDER BY a.id, a.colorder";
        return getDatabaseColumns(String.format(sql, databaseName, tableName));
    }
}
