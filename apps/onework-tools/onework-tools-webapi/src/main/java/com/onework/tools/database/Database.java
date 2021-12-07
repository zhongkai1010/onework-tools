package com.onework.tools.database;

import lombok.Builder;
import lombok.Data;
import lombok.NonNull;

import java.util.ArrayList;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: Database
 * @author: 钟凯
 * @description: 数据库
 * @date: 2021/12/7 23:39
 * @version: 1.0
 */
@Data
public class Database {

  /**
   * 数据库名称
   */
  private String databaseName;

  /**
   * 数据库连接
   */
  @NonNull
  private DataBaseConnection connection;

  /**
   * 数据库表
   */
  @Builder.Default
  private ArrayList<DataBaseTable> tables = new ArrayList<>();
}
