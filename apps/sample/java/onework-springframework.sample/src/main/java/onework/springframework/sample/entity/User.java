package onework.springframework.sample.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
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
@Data
@AllArgsConstructor
@NoArgsConstructor
@Component
public class User {

    private String username;
    private String password;

    @Override public String toString() {
        return "User{" + "username='" + username + '\'' + ", password='" + password + '\'' + '}';
    }
}
