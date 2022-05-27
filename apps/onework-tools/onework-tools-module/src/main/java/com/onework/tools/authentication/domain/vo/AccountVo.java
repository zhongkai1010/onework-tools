package com.onework.tools.authentication.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月27日 16:54
 */
@Data
public class AccountVo implements Entity {

    /**
     * ID
     */
    private String uid;

    /**
     * 用户Id
     */
    private String userId;

    /**
     * 账户类型
     */
    private AccountType type;

    /**
     * 激活状态
     */
    private Boolean activate;

    /**
     * 凭证，邮箱、手机、用户名、openid
     */
    private String ticket;

    /**
     * 密码
     */
    private String password;
}
