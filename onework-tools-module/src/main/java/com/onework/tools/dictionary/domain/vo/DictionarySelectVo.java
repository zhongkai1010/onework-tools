package com.onework.tools.dictionary.domain.vo;

import com.onework.tools.domain.tree.vo.TreeNameNodeEntity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 15:46
 */
@Data
public class DictionarySelectVo implements TreeNameNodeEntity {

    private String uid;
    private String groupId;
    private String groupName;
    private String name;
    private String value;
    private String parentId;
    private String parentName;
    private String parentIds;
}

