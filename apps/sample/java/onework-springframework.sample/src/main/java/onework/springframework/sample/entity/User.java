package onework.springframework.sample.entity;

import org.springframework.stereotype.Component;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.entity
 * @className: User
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/26 9:46
 * @version: 1.0
 */
@Component public class User {

    private String username;
    private String password;

    public User() {

    }

    public User(String username, String password) {
        this.username = username;
        this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    @Override public String toString() {
        return "User{" + "username='" + username + '\'' + ", password='" + password + '\'' + '}';
    }
}
