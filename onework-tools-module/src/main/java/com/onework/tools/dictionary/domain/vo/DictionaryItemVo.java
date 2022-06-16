package com.onework.tools.dictionary.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 15:44
 */
@Data
public class DictionaryItemVo implements Entity {

    private String uid;
    private String groupId;
    private String groupName;
    private String name;
    private String value;
}
