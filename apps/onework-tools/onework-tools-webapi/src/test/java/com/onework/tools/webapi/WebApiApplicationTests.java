package com.onework.tools.webapi;

import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import java.sql.*;

@Slf4j
@SpringBootTest
class WebApiApplicationTests {

    @Test
    void contextLoads() {
        try {
            String url =
                "jdbc:mysql://127.0.0.1:3306/onework?useUnicode=true&characterEncoding=UTF8&serverTimezone=Asia/Shanghai";
            String user = "root";
            String password = "123456";
            Connection connection = DriverManager.getConnection(url, user, password);
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery("show tables;");
            while (resultSet.next()) {
                String value = resultSet.getString(1);
                System.out.println(value);
            }
            resultSet.close();
            statement.close();
            connection.close();
        } catch (SQLException e) {
            log.error("连接数据库失败！失败原因：" + e.getMessage());
            e.printStackTrace();
        }
    }
}
