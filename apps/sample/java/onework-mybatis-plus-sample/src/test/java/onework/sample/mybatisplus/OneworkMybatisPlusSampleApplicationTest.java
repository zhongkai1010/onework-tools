package onework.sample.mybatisplus;

import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.core.conditions.query.QueryWrapper;
import com.baomidou.mybatisplus.core.conditions.update.UpdateWrapper;
import com.baomidou.mybatisplus.core.metadata.OrderItem;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import lombok.extern.slf4j.Slf4j;
import onework.sample.mybatisplus.generate.entity.Personnel;
import onework.sample.mybatisplus.generate.entity.UserArticle;
import onework.sample.mybatisplus.generate.mapper.PersonnelMapper;
import onework.sample.mybatisplus.generate.mapper.UserArticleMapper;
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
@Slf4j @SpringBootTest class OneworkMybatisPlusSampleApplicationTest {

    @Autowired private PersonnelMapper personnelMapper;

    @Autowired private UserArticleMapper userArticleMapper;

    @Test void test1() {

        System.out.println(("----- selectAll method test ------"));
        final List<Personnel> personnelList = personnelMapper.selectList(null);
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
        final int count = personnelMapper.insert(personnel);
        Assertions.assertEquals(1, count);
    }

    @Test void test3() {
        System.out.println(("----- update method test ------"));
        final Personnel personnel = new Personnel();
        personnel.setId(5L);
        personnel.setName("update");
        personnel.setAge(30);
        personnel.setEmail("zhongkai1010@163.com");
        final int count = personnelMapper.updateById(personnel);
        Assertions.assertEquals(1, count);
    }

    @Test void test4() {
        System.out.println(("----- delete method test ------"));
        final int count = personnelMapper.deleteById(5L);
        Assertions.assertEquals(1, count);
    }

    @Test void test5() {
        final QueryWrapper<Personnel> queryWrapper = new QueryWrapper<>();
        queryWrapper.lambda().eq(Personnel::getAge, 18);
        final List<Personnel> personnels = personnelMapper.selectList(queryWrapper);
        personnels.forEach(v -> System.out.println(v.toString()));
    }

    @Test void test6() {
        final LambdaQueryWrapper<Personnel> lambdaQueryWrapper = new LambdaQueryWrapper<>();
        lambdaQueryWrapper.eq(Personnel::getAge, 20);

        final List<Personnel> personnels = personnelMapper.selectList(lambdaQueryWrapper);
        personnels.forEach(v -> System.out.println(v.toString()));
    }

    @Test void test7() {
        log.info("-----------------UpdateWrapper示例--------------------");
        final UpdateWrapper<Personnel> updateWrapper = new UpdateWrapper<>();
        final Personnel employee = new Personnel();
        employee.setEmail("1234@qq.com");
        updateWrapper.eq("id", 5);
        personnelMapper.update(employee, updateWrapper);
    }

    @Test void test8() {
        log.info("-----------------分页查询--------------------");
        final Page<Personnel> page = new Page<>();
        page.setSize(2);
        page.setPages(2);
        page.addOrder(new OrderItem("age", true));
        final QueryWrapper<Personnel> queryWrapper = new QueryWrapper<>();
        final Page<Personnel> personnelPage = personnelMapper.selectPage(page, queryWrapper);
        System.out.println("总数：" + personnelPage.getTotal());
        personnelPage.getRecords().forEach(v -> System.out.println(v.toString()));
    }

    @Test void test9() {
        log.info("-----------------自动填充--------------------");

        final UserArticle userArticle = new UserArticle();
        userArticle.setUserId("1");
        userArticle.setContent("需要被删除的内容");
        userArticle.setTitle("逻辑删除示例文章");
        userArticleMapper.insert(userArticle);
        System.out.println("新增的文章信息：" + userArticle);

        final UserArticle updateUserArticle = new UserArticle();
        updateUserArticle.setUid(userArticle.getUid());
        updateUserArticle.setContent("需要被删除的内容,已被修改");
        userArticleMapper.updateById(updateUserArticle);
        System.out.println("修改后文章信息" + updateUserArticle);
    }

    @Test void test10() {
        log.info("-----------------逻辑删除--------------------");

        final UserArticle userArticle = new UserArticle();
        userArticle.setUserId("1");
        userArticle.setContent("需要被删除的内容");
        userArticle.setTitle("逻辑删除示例文章");
        userArticleMapper.insert(userArticle);
        System.out.println("新增的文章:" + userArticle);

        final UserArticle deleteUserArticle = new UserArticle();
        deleteUserArticle.setUid(userArticle.getUid());
        userArticleMapper.deleteById(deleteUserArticle);

        final QueryWrapper<UserArticle> queryWrapper = new QueryWrapper<>();
        queryWrapper.lambda().eq(UserArticle::getUid, userArticle.getUid());
        final long count = userArticleMapper.selectCount(queryWrapper);
        Assertions.assertEquals(count, 0);
    }

    @Test void test11() {
        log.info("-----------------自定义deleteAll方法--------------------");
        final long count = userArticleMapper.deleteAll();
        System.out.println("共删除" + count + "记录");
    }
}
