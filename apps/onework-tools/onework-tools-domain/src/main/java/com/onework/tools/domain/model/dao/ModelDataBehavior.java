package com.onework.tools.domain.model.dao;

import com.onework.tools.domain.model.BehaviorOperationType;
import com.onework.tools.domain.model.ModelItemType;
import lombok.Data;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model.dao
 * @Description: 描述
 * @date Date : 2022年04月18日 15:31
 */
@Data
public class ModelDataBehavior {

    private String code;
    private ModelItemType retrunType;
    private ModelItemType retrunCode;
    private ModelItemType retrunName;
    private String dataCode;
    private String dataName;
    private Map<String, ModelItemType> inputs;
    private Map<String, String> inputRefs;
    private String description;
    private BehaviorOperationType operationType;
}
