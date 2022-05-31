package com.onework.tools.error;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools
 * @Description: 描述
 * @date Date : 2022年05月23日 18:01
 */
@Data
public class ErrorMessageImlp implements ErrorMessage {
    private String code;
    private String message;

    public ErrorMessageImlp(String code, String message) {
        this.code = code;
        this.message = message;
    }
}
