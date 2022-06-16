package com.onework.tools.domain.tree;

import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.domain.tree.vo.TreeNodeEntity;

import java.util.List;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.tree
 * @Description: 描述
 * @date Date : 2022年06月15日 16:48
 */
public abstract class TreeNodeHandler<T extends TreeNodeEntity> {

    /**
     * parent id 默认值
     */
    public static final String DEFAULT_PARENT_ID_VALUE = "";

    /**
     * parent id 默认值
     */
    public static final String DEFAULT_PARENT_NAME_VALUE = "";

    /**
     * 根据id获取实体
     *
     * @param id ID
     * @return
     */
    protected abstract T getNode(String id);

    /**
     * 根据id获取子节点以及子节点的子节点，不包含自己
     *
     * @param id
     * @return
     */
    protected abstract List<T> getAllChildrenNode(String id);

    /**
     * 保存节点
     *
     * @param node
     * @param isNew
     */
    protected abstract void saveNode(T node, Boolean isNew);

    /**
     * 删除节点
     *
     * @param node
     */
    protected abstract void afterDeleteNode(T node);

    /**
     * @param parent
     * @param current
     */
    protected void afterAddNode(T current, T parent) {
        saveNode(current, true);
    }

    /**
     * @param parent
     * @param current
     */
    protected void afterUpdateNode(T current, T parent, List<T> children) {
        saveNode(current, false);
    }

    /**
     * 生成节点id
     *
     * @return
     */
    private String generateNodeId() {
        return IdWorker.getIdStr();
    }

    /**
     * @param node
     */
    protected void addNode(T node) {
        String id = generateNodeId();
        node.setUid(id);

        String parentId = node.getParentId();
        if (parentId == null || parentId.equals(DEFAULT_PARENT_ID_VALUE)) {
            node.setParentId(DEFAULT_PARENT_ID_VALUE);
            node.setParentIds(node.getUid());
            afterAddNode(node, null);
        } else {
            Check.isTrue(Objects.equals(id, parentId),
                new AppException("add tree entity id and parent id cannot be the same"));
            T parent = getNode(parentId);
            String parentIds = String.format("%s.%s", parent.getParentIds(), node.getUid());
            node.setParentIds(parentIds);
            afterAddNode(node, parent);
        }
    }

    /**
     * @param entity
     */
    protected void updateNode(T entity) {
        String id = entity.getUid();
        String parentId = entity.getParentId();

        T dbEntity = getNode(id);
        String dbParentId = dbEntity.getParentId();
        String dbParentIds = dbEntity.getParentIds();

        T parent = null;
        List<T> children = null;
        if (!Objects.equals(dbParentId, parentId)) {
            if (Objects.equals(parentId, DEFAULT_PARENT_ID_VALUE)) {
                entity.setParentId(DEFAULT_PARENT_ID_VALUE);
                entity.setParentIds(entity.getUid());
            } else {
                parent = getNode(parentId);
                String parentIds = String.format("%s.%s", parent.getParentIds(), entity.getUid());
                entity.setParentIds(parentIds);
            }
            children = getAllChildrenNode(id);
            children.forEach(t -> {
                String oldIds = t.getParentIds();
                String newIds = oldIds.replaceAll(dbParentIds, entity.getParentIds());
                t.setParentIds(newIds);
            });

        }
        afterUpdateNode(entity, parent, children);
    }

    /**
     * @param id
     */
    protected void deleteNode(String id) {
        T dbEntity = getNode(id);
        List<T> children = getAllChildrenNode(id);
        children.forEach(this::afterDeleteNode);
        afterDeleteNode(dbEntity);
    }
}
