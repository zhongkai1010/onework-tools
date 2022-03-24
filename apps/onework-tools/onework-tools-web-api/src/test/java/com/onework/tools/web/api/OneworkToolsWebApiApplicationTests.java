package com.onework.tools.web.api;

import com.onework.tools.database.DataDatabase;
import com.onework.tools.database.DataDatabaseMapper;
import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;

import javax.sql.DataSource;
import java.util.List;

@SpringBootTest
class OneworkToolsWebApiApplicationTests {

    @Test
    void contextLoads() {

        HikariConfig config = new HikariConfig();
        String url = "jdbc:mysql://101.37.81.183:8033/onework";
        config.setJdbcUrl(url);
        config.setUsername("root");
        config.setPassword("123qwe!@#mysql_root");
        DataSource dataSource = new HikariDataSource(config);
        JdbcTemplate jdbcTemplate = new JdbcTemplate(dataSource);

        List<DataDatabase> dataDatabases =
            jdbcTemplate.query("SELECT db.SCHEMA_NAME AS name FROM information_schema.`SCHEMATA` AS db",
                new DataDatabaseMapper());
        dataDatabases.forEach(s -> System.out.println(s.getDbName()));
    }
}
