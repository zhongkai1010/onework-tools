package com.onework.tools.domain.tree.vo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.tree
 * @Description: 描述
 * @date Date : 2022年06月15日 16:39
 */
public interface TreeNameNodeEntity extends TreeNodeEntity {

    /**
     * 获取节点名称
     *
     * @return
     */
    String getName();

    /**
     * 获取上级节点名称
     *
     * @return
     */
    String getParentName();

    /**
     * 设置上级节点名称
     *
     * @param name
     */
    void setParentName(String name);
}
