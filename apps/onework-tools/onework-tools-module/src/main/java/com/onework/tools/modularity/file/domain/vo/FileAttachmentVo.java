package com.onework.tools.modularity.file.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月26日 9:53
 */
@Data
public class FileAttachmentVo implements Entity {

    /**
     *
     */
    private String uid;

    /**
     *
     */
    private String fileId;

    /**
     *
     */
    private String fileName;

    /**
     *
     */
    private String categoryId;

    /**
     *
     */
    private String objectId;

    /**
     * 版本
     */
    private Integer version;
}
