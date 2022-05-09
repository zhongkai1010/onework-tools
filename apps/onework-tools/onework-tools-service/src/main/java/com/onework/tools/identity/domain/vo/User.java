package com.onework.tools.identity.domain.vo;

import com.onework.tools.core.domain.Entity;
import lombok.Data;

import java.time.LocalDateTime;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月06日 9:21
 */
@Data
public class User implements Entity {
    private String uid;
    private String username;
    private String displayName;
    private Integer sex;
    private LocalDateTime birthday;
    private String mail;
    private String phone;
    private String password;
    private Boolean enableState;
    private Boolean activeState;
    private LocalDateTime lastLoginDate;
}
