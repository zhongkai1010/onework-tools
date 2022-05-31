package com.onework.tools.authentication.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月27日 16:03
 */
@Data
public class UserVo implements Entity {

    /**
     * ID
     */
    private String uid;

    /**
     * 用户名
     */
    private String username;

    /**
     * 密码
     */
    private String password;

    /**
     * 邮箱
     */
    private String mailbox;

    /**
     * 移动电话
     */
    private String mobilePhone;

    /**
     * 锁定状态
     */
    private Boolean lockState;
}
