package com.onework.tools.database;

import lombok.Data;
import lombok.NonNull;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DataBaseTable
 * @author: 钟凯
 * @description: 数据库表
 * @date: 2021/12/7 23:30
 * @version: 1.0
 */
@Data
public class DataBaseTable {

  /**
   *  数据库连接
   */
  @NonNull
  private DataBaseConnection connection;

  /**
   *  表名
   */
  @NonNull
  private String tableName;

  public DataBaseTable(@NonNull DataBaseConnection connection, @NonNull String tableName) {
    this.connection = connection;
    this.tableName = tableName;
  }
}
