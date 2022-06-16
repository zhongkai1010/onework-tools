package com.onework.tools.domain.tree.vo;

import com.onework.tools.domain.entity.Entity;
import com.onework.tools.domain.tree.TreeNodeHandler;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.tree
 * @Description: 描述
 * @date Date : 2022年06月15日 15:16
 */
public interface TreeNodeEntity extends Entity {

    /**
     * 获取节点上级id,默认值为：""
     *
     * @return
     */
    default String getParentId() {
        return TreeNodeHandler.DEFAULT_PARENT_ID_VALUE;
    }

    /**
     * 设置上级节点id
     *
     * @param parentId
     */
    void setParentId(String parentId);

    /**
     * 获取上级节点路径，以”.“分割
     *
     * @return
     */
    default String getParentIds() {
        return "";
    }

    /**
     * 设置上级节点路径，以”.“分割
     *
     * @param parentIds
     */
    void setParentIds(String parentIds);

    /**
     * 设置Id
     *
     * @param uid
     */
    void setUid(String uid);
}
