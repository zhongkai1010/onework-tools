package com.onework.tools.domain.database.schema;

import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database.model
 * @Description: 描述
 * @date Date : 2022年03月24日 17:10
 */
public class DataColumnMapper implements RowMapper<DataColumn> {

    @Override
    public DataColumn mapRow(ResultSet rs, int rowNum) throws SQLException {
        DataColumn dataColumn = new DataColumn();
        dataColumn.setName(rs.getString("name"));
        dataColumn.setType(rs.getString("type"));
        dataColumn.setLength(rs.getLong("length"));
        dataColumn.setDescription(rs.getString("description"));
        dataColumn.setPrecision(rs.getInt("precision"));
        dataColumn.setAllowNull(rs.getBoolean("allowNull"));
        dataColumn.setPrimarykey(rs.getBoolean("primarykey"));
        dataColumn.setDefaultValue(rs.getString("defaultValue"));
        dataColumn.setOrder(rs.getInt("order"));
        return dataColumn;
    }
}
