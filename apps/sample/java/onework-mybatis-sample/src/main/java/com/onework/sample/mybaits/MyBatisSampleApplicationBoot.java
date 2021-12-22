package com.onework.sample.mybaits;

import com.onework.sample.mybaits.entity.DatabaseConnection;
import com.onework.sample.mybaits.mapper.DatabaseConnectionMapper;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.apache.ibatis.session.SqlSessionManager;

import java.io.InputStream;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-sample
 * @Package PACKAGE_NAME
 * @Description: 描述
 * @date Date : 2021年12月22日 9:12
 */
public class MyBatisSampleApplicationBoot {

    public static void main(String[] args) {
        execDefaultSqlSession();
        execSqlSessionManager();
    }

    private static void execSqlSessionTemplate() {
    }

    private static void execSqlSessionManager() {
        try {
            InputStream inputStream =
                Thread.currentThread().getContextClassLoader().getResourceAsStream("mybatis-config.xml");
            SqlSessionManager sqlSessionManager = SqlSessionManager.newInstance(inputStream);
            DatabaseConnectionMapper databaseConnectionMapper =
                sqlSessionManager.getMapper(DatabaseConnectionMapper.class);
            DatabaseConnection databaseConnection =
                databaseConnectionMapper.getDatabaseConnection("1471389712973402114");
            System.out.println(databaseConnection.toString());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static void execDefaultSqlSession() {
        try {
            InputStream inputStream =
                Thread.currentThread().getContextClassLoader().getResourceAsStream("mybatis-config.xml");
            SqlSessionFactory sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
            SqlSession sqlSession = sqlSessionFactory.openSession();
            DatabaseConnectionMapper databaseConnectionMapper = sqlSession.getMapper(DatabaseConnectionMapper.class);
            DatabaseConnection databaseConnection =
                databaseConnectionMapper.getDatabaseConnection("1471389712973402114");
            System.out.println(databaseConnection.toString());
            sqlSession.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
