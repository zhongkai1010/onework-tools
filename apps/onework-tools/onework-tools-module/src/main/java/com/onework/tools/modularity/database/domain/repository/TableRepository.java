//package com.onework.tools.modularity.database.domain.repository;
//
//import com.onework.tools.modularity.database.domain.vo.Database;
//import com.onework.tools.modularity.database.domain.vo.Table;
//import lombok.NonNull;
//import org.springframework.stereotype.Component;
//
//import java.util.List;
//
///**
// * @author : zhongkai1010@163.com
// * @version V1.0
// * @Project: onework-tools
// * @Package com.onework.tools.domain.database.schema
// * @Description: 描述
// * @date Date : 2022年03月29日 17:29
// */
//@Component
//public interface TableRepository {
//
//    /**
//     * 批量处理数据库表
//     *
//     * @param tables
//     * @param <T>
//     * @throws T
//     */
//    <T extends Throwable> List<Table> batchAddTable(@NonNull List<Table> tables) throws T;
//
//    /**
//     * 根据数据库批量删除表
//     *
//     * @param database
//     * @param <T>
//     * @throws T
//     */
//    <T extends Throwable> void batchDeleteTable(@NonNull Database database) throws T;
//}
