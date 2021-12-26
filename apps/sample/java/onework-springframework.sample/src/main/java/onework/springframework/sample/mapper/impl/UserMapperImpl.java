package onework.springframework.sample.mapper.impl;

import onework.springframework.sample.entity.User;
import onework.springframework.sample.mapper.UserMapper;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.mapper.impl
 * @className: UserMapperImpl
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/26 10:08
 * @version: 1.0
 */
@Component
public class UserMapperImpl implements UserMapper {
  /**
   * @return List<User>
   * @author ZK
   * @description 获取所有用户
   * @date 2021/12/26 10:06
   */
  @Override
  public List<User> getAllUser() {
    return new ArrayList<User>() {
      {
        new User("zhongkai01", "123456");
        new User("zhongkai02", "123456");
        new User("zhongkai03", "123456");
      }
    };
  }
}
