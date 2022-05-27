package com.onework.tools.database.domain.repository;

import com.onework.tools.database.domain.vo.DatabaseVo;
import com.onework.tools.database.domain.vo.TableVo;
import lombok.NonNull;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.schema
 * @Description: 描述
 * @date Date : 2022年03月29日 17:29
 */
@Component
public interface TableRepository {

    /**
     * 批量处理数据库表
     *
     * @param tables
     * @param <T>
     * @throws T
     */
    <T extends Throwable> List<TableVo> batchAddTable(@NonNull List<TableVo> tables) throws T;

    /**
     * 根据数据库批量删除表
     *
     * @param database
     * @param <T>
     * @throws T
     */
    <T extends Throwable> void batchDeleteTable(@NonNull DatabaseVo database) throws T;
}
