package onework.sample.mybatisplus;

import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.core.conditions.query.QueryWrapper;
import com.baomidou.mybatisplus.core.conditions.update.UpdateWrapper;
import onework.sample.mybatisplus.generate.entity.Personnel;
import onework.sample.mybatisplus.generate.mapper.PersonnelMapper;
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

    @Autowired private PersonnelMapper personnelMapper;

    @Test void test1() {

        System.out.println(("----- selectAll method test ------"));
        final List<Personnel> personnelList = this.personnelMapper.selectList(null);
        Assertions.assertEquals(5, personnelList.size());
        personnelList.forEach(System.out::println);
    }

    @Test void test2() {
        System.out.println(("----- insert method test ------"));
        final Personnel personnel = new Personnel();
        personnel.setId(6L);
        personnel.setName("test");
        personnel.setAge(30);
        personnel.setEmail("zhongkai1010@163.com");
        final int count = this.personnelMapper.insert(personnel);
        Assertions.assertEquals(1, count);
    }

    @Test void test3() {
        System.out.println(("----- update method test ------"));
        final Personnel personnel = new Personnel();
        personnel.setId(5L);
        personnel.setName("update");
        personnel.setAge(30);
        personnel.setEmail("zhongkai1010@163.com");
        final int count = this.personnelMapper.updateById(personnel);
        Assertions.assertEquals(1, count);
    }

    @Test void test4() {
        System.out.println(("----- delete method test ------"));
        final int count = this.personnelMapper.deleteById(5L);
        Assertions.assertEquals(1, count);
    }

    @Test void test5() {
        final QueryWrapper<Personnel> queryWrapper = new QueryWrapper<Personnel>();
        queryWrapper.lambda().eq(Personnel::getAge, 18);
        final List<Personnel> personnels = this.personnelMapper.selectList(queryWrapper);
        personnels.forEach(v -> System.out.println(v.toString()));
    }

    @Test void test6() {
        final LambdaQueryWrapper<Personnel> lambdaQueryWrapper = new LambdaQueryWrapper<Personnel>();
        lambdaQueryWrapper.eq(Personnel::getAge, 20);

        final List<Personnel> personnels = this.personnelMapper.selectList(lambdaQueryWrapper);
        personnels.forEach(v -> System.out.println(v.toString()));
    }

    @Test void test7() {
        final UpdateWrapper<Personnel> updateWrapper = new UpdateWrapper<>();
        final Personnel employee = new Personnel();
        employee.setEmail("1234@qq.com");
        updateWrapper.eq("id", 5);
        this.personnelMapper.update(employee, updateWrapper);
    }
}
