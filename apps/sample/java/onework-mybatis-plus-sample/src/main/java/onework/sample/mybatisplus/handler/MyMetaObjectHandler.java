package onework.sample.mybatisplus.handler;

import com.baomidou.mybatisplus.core.handlers.MetaObjectHandler;
import org.apache.ibatis.reflection.MetaObject;
import org.springframework.stereotype.Component;

import java.time.LocalDateTime;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.sample.mybatisplus.handler
 * @Description: 描述
 * @date Date : 2021年12月24日 14:04
 */
@Component
public class MyMetaObjectHandler implements MetaObjectHandler {

    @Override public void insertFill(final MetaObject metaObject) {
        fillStrategy(metaObject, "createdAt", LocalDateTime.now());
    }

    @Override public void updateFill(final MetaObject metaObject) {
        fillStrategy(metaObject, "updatedAt", LocalDateTime.now());
    }
}
