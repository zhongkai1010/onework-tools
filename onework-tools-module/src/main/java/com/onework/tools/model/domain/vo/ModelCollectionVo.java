package com.onework.tools.model.domain.vo;

import lombok.Data;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model.dao
 * @Description: 描述
 * @date Date : 2022年04月18日 15:28
 */

@Data
public class ModelCollectionVo {

    private String code;
    private String name;
    private List<ModelItemVo> items;
    private String description;
}
