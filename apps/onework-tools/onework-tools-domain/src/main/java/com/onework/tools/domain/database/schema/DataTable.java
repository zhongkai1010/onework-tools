package com.onework.tools.domain.database.schema;

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
