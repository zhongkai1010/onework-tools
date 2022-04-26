package com.onework.tools.domain.model.entity;

import com.onework.tools.domain.model.BehaviorOperationType;
import com.onework.tools.domain.model.ModelItemType;
import lombok.Data;

import java.util.List;

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
    private ModelDataBehaviorOutput output;
    private String dataCode;
    private String dataName;
    private List<ModelDataBehaviorInput> inputs;
    private String description;
    private BehaviorOperationType operationType;

    @Data
    public class ModelDataBehaviorInput {
        private String code;
        private String name;
        private ModelItemType type;
        private String refCode;
        private String arrayCode;
    }

    @Data
    public class ModelDataBehaviorOutput {
        private String code;
        private String name;
        private ModelItemType type;
        private String refCode;
        private String arrayCode;
    }
}

