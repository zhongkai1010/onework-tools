package onework.sample.mybatisplus.handler;

import com.baomidou.mybatisplus.core.injector.AbstractMethod;
import com.baomidou.mybatisplus.core.injector.DefaultSqlInjector;
import com.baomidou.mybatisplus.core.metadata.TableInfo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.sample.mybatisplus.handler
 * @Description: 描述
 * @date Date : 2021年12月24日 14:51
 */
@Component public class MyBatisInjector extends DefaultSqlInjector {
    @Override public List<AbstractMethod> getMethodList(final Class<?> mapperClass, final TableInfo tableInfo) {
        final List<AbstractMethod> methodList = super.getMethodList(mapperClass, tableInfo);
        methodList.add(new DeleteAllMethod());
        return methodList;
    }
}
