package onework.springframework.sample;

import junit.framework.TestCase;
import onework.springframework.sample.entity.User;
import onework.springframework.sample.mapper.UserMapper;
import org.junit.Test;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationEvent;
import org.springframework.context.ApplicationListener;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.core.io.ProtocolResolver;
import org.springframework.core.io.Resource;
import org.springframework.core.io.ResourceLoader;

import java.util.Map;

public class SpringFrameworkApplicationBootTest extends TestCase {

    private static void accept(String k, UserMapper v) {
        System.out.println(k);
    }

    @Test public void test01() {
        BeanFactory beanFactory = new ClassPathXmlApplicationContext("application_boot.xml");
        User user = (User)beanFactory.getBean("user");
        System.out.println(user);
    }

    @Test public void test02() {
        ClassPathXmlApplicationContext applicationContext = new ClassPathXmlApplicationContext("application_boot.xml");
        applicationContext.start();
        applicationContext.addApplicationListener(new ApplicationListener<ApplicationEvent>() {
            @Override public void onApplicationEvent(ApplicationEvent event) {
                System.out.println("onApplicationEvent");
            }
        });
        User user = applicationContext.getBean("user", User.class);
        System.out.println(user);
    }

    @Test public void test03() {
        ApplicationContext applicationContext = new ClassPathXmlApplicationContext("application_boot.xml");

        Map<String, UserMapper> stringClassMap = applicationContext.getBeansOfType(UserMapper.class);
        stringClassMap.forEach((k,v)-> {
           v.getAllUser().forEach(i-> System.out.println(i));
        });
    }
}