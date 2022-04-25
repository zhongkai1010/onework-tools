package com.onework.tools.domain.model.entity;

import com.onework.tools.domain.model.ModelDataStatus;
import com.onework.tools.domain.model.ModelDataUse;
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
public class ModelData {

    private String code;
    private String name;
    private ModelDataUse use;
    private ModelDataStatus status;
    private String description;
}
