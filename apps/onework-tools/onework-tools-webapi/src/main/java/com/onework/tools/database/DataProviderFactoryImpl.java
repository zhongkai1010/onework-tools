package com.onework.tools.database;

import org.springframework.stereotype.Component;

/**
 * @ClassName: DataProviderFactoryImpl
 * @Description: 数据库提供者工厂
 * @Author: 钟凯
 * @Date: 2021/12/8 23:49
 **/
@Component
public class DataProviderFactoryImpl implements DataProviderFactory {

    /**
     * 描述
     *
     * @param databaseType
     * @return DataProvider
     */
    @Override public DataProvider getDataProvider(DatabaseType databaseType) {
        return new MssqlDataProvider();
    }
}
