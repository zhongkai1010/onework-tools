package com.onework.tools.webapi.controller.database.dto;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.webapi.controller.database
 * @Description: 描述
 * @date Date : 2022年05月09日 14:00
 */

@Data
public class ConnectionDto {
    private String uid;
    private String name;
    private String dbType;
    private String host;
    private Integer port;
    private String database;
    private String username;
    private String password;
}
