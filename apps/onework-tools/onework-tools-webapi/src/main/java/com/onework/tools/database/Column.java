package com.onework.tools.database;

import lombok.Builder;
import lombok.Data;
import lombok.NonNull;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DataBaseColumn
 * @author: 钟凯
 * @description: 数据库表字段
 * @date: 2021/12/7 23:35
 * @version: 1.0
 */
@Data
public class Column {

  /**
   * 数据库表
   */
  @NonNull
  private Table table;

  /**
   * 类型
   */
  @NonNull
  private String type;

  /**
   * 是否为空
   */
  @NonNull
  private Boolean isNull;

  /**
   * 是否主键
   */
  @NonNull
  private Boolean isUnique = false;

  /**
   * 长度
   */
  private Long length;

  /**
   * 精度
   */
  private Integer precision;

  /**
   * 序号
   */
  private Integer order;

  /**
   * 默认值
   */
  private String defaultValue;

  /**
   * 描述
   */
  private String description;
}
