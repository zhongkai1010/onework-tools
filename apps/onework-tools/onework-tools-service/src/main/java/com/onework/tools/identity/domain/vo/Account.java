package com.onework.tools.identity.domain.vo;

import com.onework.tools.core.domain.Entity;
import com.onework.tools.identity.domain.AccountType;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月09日 9:12
 */
@Data
public class Account implements Entity {
    private String uid;
    private String userUid;
    private String account;
    private AccountType accountType;
}
