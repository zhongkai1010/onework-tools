package com.onework.tools.database.domain.schema.mapper;

import com.onework.tools.database.domain.schema.entity.DataTable;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database.model
 * @Description: 描述
 * @date Date : 2022年03月24日 17:09
 */
public class DataTableMapper implements RowMapper<DataTable> {
    @Override
    public DataTable mapRow(ResultSet rs, int rowNum) throws SQLException {
        DataTable dataTable = new DataTable();

        dataTable.setTbName(rs.getString("name"));

        return dataTable;
    }
}
