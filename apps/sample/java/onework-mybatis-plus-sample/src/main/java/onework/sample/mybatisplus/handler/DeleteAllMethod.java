package onework.sample.mybatisplus.handler;

import com.baomidou.mybatisplus.core.injector.AbstractMethod;
import com.baomidou.mybatisplus.core.metadata.TableInfo;
import org.apache.ibatis.mapping.MappedStatement;
import org.apache.ibatis.mapping.SqlSource;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.sample.mybatisplus.handler
 * @Description: 描述
 * @date Date : 2021年12月24日 15:13
 */
@Component public class DeleteAllMethod extends AbstractMethod {
    @Override public MappedStatement injectMappedStatement(final Class<?> mapperClass, final Class<?> modelClass,
        final TableInfo tableInfo) {
        // 执行的sql
        final String sql = " delete from " + tableInfo.getTableName();
        // mapper 接口方法名
        final String method = "deleteAll";
        final SqlSource sqlSource = languageDriver.createSqlSource(configuration, sql, modelClass);
        return addDeleteMappedStatement(mapperClass, method, sqlSource);
    }
}
