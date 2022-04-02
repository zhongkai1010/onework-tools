package com.onework.tools.server.database.mapper;

import com.onework.tools.server.database.entity.DatabaseColumn;
import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import org.apache.ibatis.annotations.Param;

/**
 * <p>
 *  Mapper 接口
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-31
 */
public interface DatabaseColumnMapper extends BaseMapper<DatabaseColumn> {

    /**
     * 根据数据库id删除字段
     *
     * @param dbId
     */
    void deleteColumnByDatabase(@Param("dbId") String dbId);
}
