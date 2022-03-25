package com.onework.tools.web.api.controller.model.db;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.web.api.controller
 * @Description: 描述
 * @date Date : 2022年03月24日 10:56
 */
@Data
public class DbInput {

    private String host;
    private Integer port;
    private String user;
    private String password;
    private String database;
}
