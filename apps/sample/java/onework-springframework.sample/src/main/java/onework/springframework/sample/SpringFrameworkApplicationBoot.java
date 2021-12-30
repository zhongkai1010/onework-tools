package onework.springframework.sample;

import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.EnableAspectJAutoProxy;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample
 * @className: SpringFrameworkApplicationBoot
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/25 21:30
 * @version: 1.0
 */
@EnableAspectJAutoProxy
@ComponentScan(basePackages = "onework/springframework/sample") public class SpringFrameworkApplicationBoot {
    public static void main(String[] args) {

    }
}
