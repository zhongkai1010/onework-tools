package onework.sample.mybatisplus;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/**
 * @author ZK
 * @description 启动类
 * @date 2021/12/22 20:20
 */

@SpringBootApplication(scanBasePackages = "onework.sample.mybatisplus")
@MapperScan("onework.sample.mybatisplus.generate.mapper")
public class OneworkMybatisPlusSampleApplication {

    public static void main(String[] args) {
        SpringApplication.run(OneworkMybatisPlusSampleApplication.class, args);
    }

}
