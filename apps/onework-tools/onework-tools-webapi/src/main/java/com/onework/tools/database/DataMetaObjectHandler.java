package com.onework.tools.database;

import com.baomidou.mybatisplus.core.handlers.MetaObjectHandler;
import org.apache.ibatis.reflection.MetaObject;
import org.springframework.stereotype.Component;

import java.time.LocalDateTime;

/**
 * @ClassName: DataMetaObjectHandler
 * @Description: 自动填充处理
 * @Author: 钟凯
 * @Date: 2021/12/12 12:44
 **/
//@Component
//public class DataMetaObjectHandler implements MetaObjectHandler {
//
//    @Override
//    public void insertFill(MetaObject metaObject) {
//        this.fillStrategy(metaObject, "created_at", LocalDateTime.now());
//        this.fillStrategy(metaObject, "updated_at", LocalDateTime.now());
//    }
//
//    @Override
//    public void updateFill(MetaObject metaObject) {
//        this.fillStrategy(metaObject, "updated_at", LocalDateTime.now());
//    }
//}
