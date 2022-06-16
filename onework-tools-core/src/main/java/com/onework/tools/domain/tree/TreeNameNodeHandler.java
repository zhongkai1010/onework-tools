package com.onework.tools.domain.tree;

import com.onework.tools.domain.tree.vo.TreeNameNodeEntity;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.tree
 * @Description: 描述
 * @date Date : 2022年06月15日 16:46
 */
public abstract class TreeNameNodeHandler<T extends TreeNameNodeEntity> extends TreeNodeHandler<T> {

    /**
     * 更新子节点
     *
     * @param childNode
     */
    protected abstract void updateChildNode(T childNode);

    @Override
    protected void afterAddNode(T current, T parent) {
        if (parent == null) {
            current.setParentName(TreeNodeHandler.DEFAULT_PARENT_NAME_VALUE);
        } else {
            current.setParentName(parent.getName());
        }
        saveNode(current,true);
    }

    @Override
    protected void afterUpdateNode(T current, T parent, List<T> children) {

        if (parent != null) {
            current.setParentName(parent.getName());
        }

        if (children != null) {
            children.forEach(t -> {
                if (t.getParentId().equals(current.getUid())) {
                    t.setParentName(parent.getName());
                    updateChildNode(t);
                    saveNode(t,false);
                }
            });
        }
        saveNode(current,false);
    }
}
