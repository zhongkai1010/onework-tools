package com.onework.tools.database;

import com.onework.tools.database.DataColumn;
import lombok.Data;

import java.util.List;

/**
 *
 * @author Administrator
 */
@Data
public class DataTable {
    private String tbName;
    private List<DataColumn> columns;
}
