package com.onework.tools.model.domain.vo;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model.dao
 * @Description: 描述
 * @date Date : 2022年04月18日 15:30
 */
@Data
public class ModelDataItemVo {

    private String code;
    private String name;
    private ModelItemType type;
    private String dataCode;
    private String dataName;
    private String refCode;
    private String arrayCode;
    private String defaultValue;
    private String extData;
}
