package com.onework.tools.domain.database.entity;


import com.onework.tools.domain.database.schema.entity.DataTable;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.dao
 * @Description: 描述
 * @date Date : 2022年03月29日 16:30
 */
@Data
public class Table {

    private String uid;
    private String name;
    private String cnUid;
    private String dbUid;
    private String dbName;

    public static Table getTable(Database database, DataTable dataTable) {
        Table table = new Table();
        table.setName(dataTable.getTbName());
        table.setCnUid(database.getCnUid());
        table.setDbUid(database.getUid());
        table.setDbName(database.getName());
        return table;
    }
}
