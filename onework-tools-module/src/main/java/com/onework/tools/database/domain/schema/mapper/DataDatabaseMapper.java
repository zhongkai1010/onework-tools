package com.onework.tools.database.domain.schema.mapper;

import com.onework.tools.database.domain.schema.entity.DataDatabase;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database.model
 * @Description: 描述
 * @date Date : 2022年03月24日 16:53
 */
public class DataDatabaseMapper implements RowMapper<DataDatabase> {

    @Override
    public DataDatabase mapRow(ResultSet rs, int rowNum) throws SQLException {
        DataDatabase dataDatabase = new DataDatabase();
        dataDatabase.setDbName(rs.getString("name"));
        return dataDatabase;
    }
}
