package com.onework.tools.file.domain.vo;

import com.onework.tools.domain.entity.Entity;
import com.onework.tools.domain.entity.NameCodeValue;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.file.entity
 * @Description: 描述
 * @date Date : 2022年04月25日 14:29
 */
@Data
public class FileCategoryVo implements Entity, NameCodeValue {
    /**
     * ID
     */
    private String uid;

    /**
     * 名称
     */
    private String name;

    /**
     * 编码
     */
    private String code;

    /**
     * 文件数量
     */
    private long fileCount;
}
