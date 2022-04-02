package com.onework.tools.domain.database;

import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;
import com.onework.tools.domain.database.repository.ColumnRepository;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.schema
 * @Description: 描述
 * @date Date : 2022年04月01日 16:08
 */
public class TableBatchHandle implements Runnable {

    private final Database database;

    private final List<Table> tables;

    private final ColumnRepository columnRepository;

    public TableBatchHandle(Database database, List<Table> tables, ColumnRepository columnRepository) {
        this.database = database;
        this.tables = tables;
        this.columnRepository = columnRepository;
    }

    @Override
    public void run() {

//        for (Table table : tables) {
//            Column column = new Column();
//            column.setCnUid(database.getCnUid());
//            column.setDbUid(database.getUid());
//            column.setDbName(database.getName());
//            column.setTbUid(table.getUid());
//            columnRepository.addOrUpdateColumn(column);
//        }
    }
}
