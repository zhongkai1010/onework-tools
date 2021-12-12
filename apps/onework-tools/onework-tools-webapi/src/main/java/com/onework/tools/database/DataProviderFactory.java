package com.onework.tools.database;

import org.springframework.stereotype.Component;

/**
 * @ClassName: DataProviderFactory
 * @Description: 数据提供者工厂
 * @Author: 钟凯
 * @Date: 2021/12/8 22:04
 **/
@Component
public interface DataProviderFactory {

    /**
    * 描述
    * @param databaseType
    * @return DataProvider
    */
    public  DataProvider getDataProvider(DatabaseType databaseType);
}
