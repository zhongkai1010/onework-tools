package com.onework.tools.web.api.controller.model.database;

import com.baomidou.mybatisplus.annotation.TableField;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.web.api.controller.model.db.database
 * @Description: 描述
 * @date Date : 2022年03月25日 16:57
 */
@Data
public class ConnectionInput {

    @Schema(description = "连接名")
    private String name;

    @Schema(description = "数据库类型")
    private String dbType;

    @Schema(description = "主机地址")
    private String host;

    @Schema(description = "端口")
    private Integer port;

    @Schema(description = "数据库")
    private String database;

    @Schema(description = "用户")
    private String username;

    @Schema(description = "密码")
    private String password;
}
