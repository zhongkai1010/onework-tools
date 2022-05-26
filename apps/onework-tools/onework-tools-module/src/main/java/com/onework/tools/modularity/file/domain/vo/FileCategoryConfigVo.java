package com.onework.tools.modularity.file.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.entity
 * @Description: 描述
 * @date Date : 2022年05月26日 9:40
 */
@Data
public class FileCategoryConfigVo implements Entity {

    private String uid;
    private String categoryId;
    private FileCategoryConfigType type;
    private String value;
}
