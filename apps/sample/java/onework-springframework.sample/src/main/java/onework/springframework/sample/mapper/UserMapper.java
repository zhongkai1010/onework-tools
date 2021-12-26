package onework.springframework.sample.mapper;

import onework.springframework.sample.entity.User;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.mapper
 * @className: UserMapper
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/26 10:05
 * @version: 1.0
 */
@Component
public interface UserMapper {

  /**
   * 获取所有用户
   * @return List<User>
   * @author ZK
   * @description 获取所有用户
   * @date 2021/12/26 10:11
   */
  List<User> getAllUser();
}
