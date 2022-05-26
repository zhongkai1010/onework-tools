package com.onework.tools.modularity.file.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.file.entity
 * @Description: 描述
 * @date Date : 2022年04月25日 14:28
 */
@Data
public class FileVo implements Entity {

    /**
     * Id
     */
    private String uid;

    /**
     * 类别Id
     */
    private String categoryId;
    /**
     * 类别名称
     */
    private String categoryName;
    /**
     * 文件名称，包括后缀
     */
    private String name;

    /**
     * 文件大小
     */
    private long size;

    /**
     * 后缀
     */
    private String ext;
    /**
     * 物理路径
     */
    private String physicalPath;
}
