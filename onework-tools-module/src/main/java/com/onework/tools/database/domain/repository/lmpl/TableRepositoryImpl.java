//package com.onework.tools.modularity.database.domain.repository.lmpl;
//
//import cn.hutool.core.bean.BeanUtil;
//import com.baomidou.mybatisplus.core.toolkit.IdWorker;
//import com.onework.tools.modularity.database.domain.repository.TableRepository;
//import com.onework.tools.modularity.database.domain.vo.Database;
//import com.onework.tools.modularity.database.domain.vo.Table;
//import com.onework.tools.modularity.database.entity.DatabaseTable;
//import com.onework.tools.modularity.database.mapper.DatabaseTableMapper;
//import lombok.NonNull;
//import org.springframework.stereotype.Repository;
//
//import java.time.LocalDateTime;
//import java.util.ArrayList;
//import java.util.List;
//
///**
// * @author : zhongkai1010@163.com
// * @version V1.0
// * @Project: onework-tools
// * @Package com.onework.tools.server.database
// * @Description: 描述
// * @date Date : 2022年03月31日 10:48
// */
//@Repository
//public class TableRepositoryImpl implements TableRepository {
//
//    private final DatabaseTableMapper databaseTableMapper;
//
//    public TableRepositoryImpl(DatabaseTableMapper databaseTableMapper) {
//        this.databaseTableMapper = databaseTableMapper;
//    }
//
//    @Override
//    public <T extends Throwable> List<Table> batchAddTable(@NonNull List<Table> tables) {
//
//        ArrayList<DatabaseTable> databaseTables = new ArrayList<>();
//        tables.forEach(table -> {
//            table.setUid(IdWorker.getIdStr());
//            DatabaseTable databaseTable = BeanUtil.copyProperties(table, DatabaseTable.class);
//            databaseTable.setCode(table.getName());
//            databaseTable.setCreatedAt(LocalDateTime.now());
//            databaseTable.setUpdatedAt(LocalDateTime.now());
//            databaseTables.add(databaseTable);
//        });
//        databaseTableMapper.insertBatch(databaseTables);
//        return tables;
//    }
//
//    @Override
//    public <T extends Throwable> void batchDeleteTable(@NonNull Database database) {
//        databaseTableMapper.deleteTableByDatabase(database.getUid());
//    }
//}
