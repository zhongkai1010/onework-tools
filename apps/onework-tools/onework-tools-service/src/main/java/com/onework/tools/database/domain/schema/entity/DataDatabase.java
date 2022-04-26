package com.onework.tools.database.domain.schema.entity;

import lombok.Data;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database.model
 * @Description: 描述
 * @date Date : 2022年03月24日 13:57
 */
@Data
public class DataDatabase {
    private String dbName;
    private List<DataTable> tables = new ArrayList<>();
}
