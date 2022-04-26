package com.onework.tools.database.mapper;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.onework.tools.database.entity.DatabaseTable;
import org.springframework.data.repository.query.Param;

import java.util.ArrayList;

/**
 * <p>
 * Mapper 接口
 * </p>
 *
 * @author zhongkai
 * @since 2022-04-26
 */
public interface DatabaseTableMapper extends BaseMapper<DatabaseTable> {

    /**
     * 批量新增数据库表
     *
     * @param tables
     */
    void insertBatch(@Param("tables") ArrayList<DatabaseTable> tables);

    /**
     * 根据数据库id删除表和字段
     *
     * @param dbId
     */
    void deleteTableByDatabase(@Param("dbId") String dbId);

}
