package com.onework.tools.server.database.mapper;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.onework.tools.server.database.entity.DatabaseColumn;
import org.apache.ibatis.annotations.Param;

import java.util.ArrayList;

/**
 * <p>
 * Mapper 接口
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-31
 */
public interface DatabaseColumnMapper extends BaseMapper<DatabaseColumn> {

    /**
     * 批量新增数据库表
     *
     * @param columns
     */
    void insertBatch(@Param("columns") ArrayList<DatabaseColumn> columns);

    /**
     * 根据数据库id删除字段
     *
     * @param dbId
     */
    void deleteColumnByDatabase(@Param("dbId") String dbId);
}
