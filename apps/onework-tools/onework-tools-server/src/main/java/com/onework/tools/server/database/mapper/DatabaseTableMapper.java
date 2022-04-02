package com.onework.tools.server.database.mapper;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.onework.tools.server.database.entity.DatabaseTable;
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
public interface DatabaseTableMapper extends BaseMapper<DatabaseTable> {

    //    /**
    //     * 批量处理数据库表
    //     *
    //     * @param tables
    //     */
    //    void insertOrUpdateBatch(@Param("tables") ArrayList<DatabaseTable> tables);

    /**
     *
     * @param id
     * @return
     */
    DatabaseTable getCustom(@Param("id") String id);
}
