package onework.sample.mybatisplus.entity;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.samole.mybatisplussample.entity
 * @Description: 描述
 * @date Date : 2021年12月23日 9:30
 */
@Data
public class User {
    private Long id;
    private String name;
    private Integer age;
    private String email;

    @Override public String toString() {
        return "User{" + "id=" + id + ", name='" + name + '\'' + ", age=" + age + ", email='" + email + '\'' + '}';
    }
}