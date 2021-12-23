package onework.sample.mybatisplus;

import onework.sample.mybatisplus.entity.User;
import onework.sample.mybatisplus.mapper.UserMapper;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.sample.mybatisplussample
 * @Description: 描述
 * @date Date : 2021年12月23日 10:00
 */
@SpringBootTest class OneworkMybatisPlusSampleApplicationTest {

    @Autowired private UserMapper userMapper;

    @Test void testSelect() {

        System.out.println(("----- selectAll method test ------"));
        List<User> userList = userMapper.selectList(null);
        Assertions.assertEquals(5, userList.size());
        userList.forEach(System.out::println);
    }

    @Test void testInsert() {
        System.out.println(("----- insert method test ------"));
        User user = new User();
        user.setId(6L);
        user.setName("test");
        user.setAge(30);
        user.setEmail("zhongkai1010@163.com");
        int count = userMapper.insert(user);
        Assertions.assertEquals(1, count);
    }

    @Test void testUpdate() {
        System.out.println(("----- update method test ------"));
        User user = new User();
        user.setId(5L);
        user.setName("update");
        user.setAge(30);
        user.setEmail("zhongkai1010@163.com");
        int count = userMapper.updateById(user);
        Assertions.assertEquals(1, count);
    }

    @Test void testDelete() {
        System.out.println(("----- delete method test ------"));
        int count = userMapper.deleteById(5L);
        Assertions.assertEquals(1, count);
    }
}