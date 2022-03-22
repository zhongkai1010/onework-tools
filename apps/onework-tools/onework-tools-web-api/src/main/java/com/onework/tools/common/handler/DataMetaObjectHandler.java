package com.onework.tools.common.handler;

import com.baomidou.mybatisplus.core.handlers.MetaObjectHandler;
import org.apache.ibatis.reflection.MetaObject;
import org.springframework.stereotype.Component;

import java.time.LocalDateTime;

/**
 * @author ZK
 */
@Component
public class DataMetaObjectHandler implements MetaObjectHandler {

    @Override
    public void insertFill(MetaObject metaObject) {
        fillStrategy(metaObject, "createdAt", LocalDateTime.now());
        fillStrategy(metaObject, "updatedAt", LocalDateTime.now());
    }

    @Override
    public void updateFill(MetaObject metaObject) {
        fillStrategy(metaObject, "updatedAt", LocalDateTime.now());
    }

}
