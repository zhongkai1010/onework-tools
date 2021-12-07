package com.onework.tools.database;

import lombok.Data;
import lombok.NonNull;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DataBaseConnection
 * @author: 钟凯
 * @description: 数据库连接
 * @date: 2021/12/7 23:35
 * @version: 1.0
 */
@Data
public class DataBaseConnection {

  /**
   * 数据库连接字符串
   */
  @NonNull
  private String databaseHost;

  /**
   * 数据库类型
   */
  private Enum<DatabaseType> dbType;

  /**
   * 数据库用户名
   */
  @NonNull
  private String dataBaseUserName;

  /**
   * 数据库密码
   */
  @NonNull
  private String databasePassword;

  /**
   * 端口
   */
  private Integer port;

}
