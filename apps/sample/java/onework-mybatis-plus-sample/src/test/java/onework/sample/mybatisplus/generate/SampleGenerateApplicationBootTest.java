package onework.sample.mybatisplus.generate;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.sample.mybatisplus.generate
 * @Description: 描述
 * @date Date : 2021年12月23日 15:25
 */
@SpringBootTest class SampleGenerateApplicationBootTest {

    @Autowired private SampleGenerateApplicationBoot sampleGenerateApplicationBoot;

    @Test void executeByAllTable() {
        this.sampleGenerateApplicationBoot.executeByAllTable();

    }

    @Test void executeByCustomTable() {

        this.sampleGenerateApplicationBoot.executeByCustomTable();
    }
}