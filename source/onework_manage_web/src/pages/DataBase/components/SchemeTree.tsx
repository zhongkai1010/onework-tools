/*
 * @Author: 钟凯
 * @Date: 2021-03-05 11:40:24
 * @LastEditTime: 2021-03-15 15:09:21
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\SchemeTree.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import {
  ArrowsAltOutlined,
  CloudOutlined,
  DatabaseOutlined,
  DeleteOutlined,
  EditOutlined,
  PlusOutlined,
  ShrinkOutlined,
  SyncOutlined,
  TableOutlined,
} from '@ant-design/icons';
import { Menu, Tree } from 'antd';
import type { EventDataNode, TreeProps } from 'antd/lib/tree';

import type { CSSProperties } from 'react';
import React, { useState } from 'react';
import type { SchemeNode, TreeHandleHook } from '../treeHandleHook';

interface Props {
  treeHandle: TreeHandleHook;
  onNodeSelect?: (node: SchemeNode) => void;
}

const SchemeTree = (props: Props & TreeProps) => {
  const [menuStyle, setMenuStyle] = useState<CSSProperties>({
    width: '160px',
    position: 'fixed',
    display: 'none',
    border: '1px solid #ccc',
  });
  const [selectNode, setSelectNode] = useState<EventDataNode>();
  const renderIcon = (node: any) => {
    const schemeNode = node as SchemeNode;
    switch (schemeNode.type) {
      case 'connection':
        return <CloudOutlined style={{ color: schemeNode.isLoad ? 'green' : '#000' }} />;
      case 'database':
        return <DatabaseOutlined style={{ color: schemeNode.isLoad ? 'green' : '#000' }} />;
      case 'table':
        return <TableOutlined />;
      default:
        return <></>;
    }
  };
  return (
    <>
      <Tree.DirectoryTree
        showIcon
        expandAction="doubleClick"
        onSelect={async (_keys, { node }) => {
          const schemeNode = (node as unknown) as SchemeNode;
          if (props.onNodeSelect) {
            props.onNodeSelect(schemeNode);
          }
          // 隐藏菜单
          setMenuStyle({ ...menuStyle, display: 'none' });
          // 设置选中
          setSelectNode(node);
          // 选中后，未加载的节点，进行加载
          // if (!schemeNode.isLoad) {
          //   try {
          //     if (schemeNode.type === 'connection') {
          //       await props.treeHandle.loadDatabase(schemeNode);
          //     }
          //     if (schemeNode.type === 'database') {
          //       await props.treeHandle.loadTable(schemeNode);
          //     }
          //   } catch (error) {
          //     props.treeHandle.expandNode(schemeNode, false);
          //   }
          // }
        }}
        selectedKeys={selectNode ? [selectNode.key.toString()] : []}
        expandedKeys={props.treeHandle.getExpandedKeys()}
        loadedKeys={props.treeHandle.getLoadedKeys()}
        onRightClick={({ event, node }) => {
          event.preventDefault();
          setMenuStyle({
            ...menuStyle,
            display: 'block',
            top: event.pageY,
            left: event.pageX,
          });
          setSelectNode(node);
        }}
        icon={renderIcon}
        onExpand={(_expandedKeys, { expanded, node }) => {
          const schemeNode = (node as unknown) as SchemeNode;
          props.treeHandle.expandNode(schemeNode, expanded);
        }}
        loadData={async (node: EventDataNode) => {
          const schemeNode = (node as unknown) as SchemeNode;
          try {
            if (schemeNode.type === 'connection') {
              await props.treeHandle.loadDatabase(schemeNode);
            }
            if (schemeNode.type === 'database') {
              await props.treeHandle.loadTable(schemeNode);
            }
          } catch (error) {
            props.treeHandle.expandNode(schemeNode, false);
          }
        }}
        treeData={props.treeHandle.getTreeData()}
        {...props}
      />
      <Menu style={menuStyle}>
        <Menu.Item style={{ borderBottom: '1px solid #ccc' }} icon={<ShrinkOutlined />}>
          打开连接
        </Menu.Item>
        <Menu.Item style={{ borderBottom: '1px solid #ccc' }} icon={<ArrowsAltOutlined />}>
          关闭连接
        </Menu.Item>
        <Menu.Item style={{ borderBottom: '1px solid #ccc' }} icon={<PlusOutlined />}>
          新建连接
        </Menu.Item>
        <Menu.Item style={{ borderBottom: '1px solid #ccc' }} icon={<SyncOutlined />}>
          同步连接
        </Menu.Item>
        <Menu.Item style={{ borderBottom: '1px solid #ccc' }} icon={<EditOutlined />}>
          修改连接
        </Menu.Item>
        <Menu.Item icon={<DeleteOutlined />}>删除连接</Menu.Item>
      </Menu>
    </>
  );
};

export default SchemeTree;
