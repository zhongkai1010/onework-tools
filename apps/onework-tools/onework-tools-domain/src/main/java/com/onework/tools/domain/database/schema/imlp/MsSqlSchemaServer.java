package com.onework.tools.domain.database.schema.imlp;

import com.onework.tools.domain.database.schema.DbSchemaServer;

import javax.sql.DataSource;

/**
 * @author Administrator
 */
public class MsSqlSchemaServer extends DbSchemaServer {

    public MsSqlSchemaServer(DataSource dataSource) {
        super(dataSource);
    }

    @Override
    protected String getDatabasesSql() {
        return "select name from sysdatabases";
    }

    @Override
    protected String getTablesSql(String dbName) {
        return String.format("use %s select * from sysobjects where xtype='U';", dbName);
    }

    @Override
    protected String getColumnsSql(String dbName, String dbTable) {
        return String.format(
            "USE %s SELECT 'order' = a.colorder, 'name' = a.name, 'primarykey' = CASE WHEN EXISTS(SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND name IN (SELECT name FROM sysindexes WHERE indid IN (SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid) ) ) THEN 1 ELSE 0 END, 'type' = b.name, 'length' = COLUMNPROPERTY( a.id , a.name, 'PRECISION' ), 'precision' = isnull( COLUMNPROPERTY( a.id, a.name , 'Scale' ), 0 ), 'allowNull' = CASE WHEN a.isnullable= 1 THEN 1 ELSE 0 END, 'defaultValue' = isnull( e.text , '' ), 'description' = isnull( g.[value], '' ) FROM syscolumns a LEFT JOIN systypes b ON a.xusertype = b.xusertype INNER JOIN sysobjects d ON a.id = d.id AND d.xtype= 'U' AND d.name <> 'dtproperties' LEFT JOIN syscomments e ON a.cdefault = e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0 WHERE a.id= OBJECT_ID( '%s' ) ORDER BY a.id, a.colorder",
            dbName, dbTable);
    }
}
