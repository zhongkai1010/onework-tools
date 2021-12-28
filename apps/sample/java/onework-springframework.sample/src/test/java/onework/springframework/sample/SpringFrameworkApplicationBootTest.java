package onework.springframework.sample;

import onework.springframework.sample.common.DefaultTransactionManager;
import onework.springframework.sample.common.TransactionManager;
import onework.springframework.sample.entity.User;
import onework.springframework.sample.mapper.BaseMapper;
import onework.springframework.sample.mapper.UserMapper;
import org.junit.Assert;
import org.junit.Test;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.util.Map;

public class SpringFrameworkApplicationBootTest {

    @Test public void test01() {
        BeanFactory beanFactory = new ClassPathXmlApplicationContext("application_boot.xml");
        User user = (User)beanFactory.getBean("user");
        System.out.println(user);
    }

    @Test public void test02() {
        ClassPathXmlApplicationContext applicationContext = new ClassPathXmlApplicationContext("application_boot.xml");
        Map<String, BaseMapper> userMapperMap = applicationContext.getBeansOfType(BaseMapper.class);
        userMapperMap.forEach((k, v) -> System.out.println(v));
    }

    @Test public void test03() {
        ClassPathXmlApplicationContext applicationContext = new ClassPathXmlApplicationContext("application_boot.xml");
        UserMapper userMapper = applicationContext.getBean(UserMapper.class);
        userMapper.add(new User("123","1234"));
        userMapper.getAll().forEach(v-> System.out.println(v));
    }

    @Test public void test04() {
        ApplicationContext applicationContext = new AnnotationConfigApplicationContext(SpringFrameworkApplicationBoot.class);
        User user = (User)applicationContext.getBean("user");
        System.out.println(user);
    }

    @Test public void test05() {
        ApplicationContext applicationContext = new AnnotationConfigApplicationContext(SpringFrameworkApplicationBoot.class);
        DefaultTransactionManager defaultTransactionManager = (DefaultTransactionManager)applicationContext.getBean("defaultTransactionManager");
        Assert.assertNotNull(defaultTransactionManager);
    }

    @Test public void test06() {
        AnnotationConfigApplicationContext applicationContext = new AnnotationConfigApplicationContext(SpringFrameworkApplicationBoot.class);
        TransactionManager transactionManager = applicationContext.getBean(TransactionManager.class);
        System.out.println(transactionManager.getClass().getName());
    }
}