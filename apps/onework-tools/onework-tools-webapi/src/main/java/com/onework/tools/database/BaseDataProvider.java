package com.onework.tools.database;

import lombok.extern.log4j.Log4j2;
import org.apache.ibatis.session.Configuration;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;

import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;

/**
 * @ClassName: BaseDataProvider
 * @Description: 基础数据源提供者
 * @Author: 钟凯
 * @Date: 2021/12/12 8:50
 **/
@Log4j2
public abstract class BaseDataProvider implements DataProvider {

    private static Map<DatabaseType, String> dbDriverMap = new HashMap<DatabaseType, String>() {
        {
            put(DatabaseType.Mysql, "test");
            put(DatabaseType.MsSql, "20");
        }
    };

    /**
     * 描述
     * 
     * @param connection
     *            连接参数
     * @return Connection
     */
    public java.sql.Connection createConnection(Connection connection) {

//        DruidDataSource dataSource = new DruidDataSource();
//
//        SqlSessionFactoryBuilder sqlSessionFactoryBuilder = new SqlSessionFactoryBuilder();
//        Configuration configuration = new Configuration();
//        configuration.ad
//        SqlSessionFactory sqlSessionFactory =  sqlSessionFactoryBuilder.build(configuration);
//        SqlSession sqlSession =  sqlSessionFactory.openSession();

        String url = connection.getDatabaseHost();
        String username = connection.getDataBaseUserName();
        String password = connection.getDatabasePassword();
        try {
            String driverClassName = dbDriverMap.get(connection.getDbType());
            Class.forName(driverClassName);
            return DriverManager.getConnection(url, username, password);
        } catch (SQLException | ClassNotFoundException throwable) {
            log.error(throwable);
            return null;
        }
    }
}
