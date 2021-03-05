/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:06:46
 * @LastEditTime: 2021-03-05 11:30:46
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import {
  ArrowsAltOutlined,
  CloudOutlined,
  DatabaseOutlined,
  DeleteOutlined,
  EditOutlined,
  PlusOutlined,
  PlusSquareOutlined,
  ShrinkOutlined,
  SyncOutlined,
  TableOutlined,
} from '@ant-design/icons';
import { PageContainer } from '@ant-design/pro-layout';
import { Card, Col, Menu, Row, Tree } from 'antd';
import type { EventDataNode } from 'antd/lib/tree';
import type { CSSProperties } from 'react';
import React, { useState } from 'react';
import type { SchemeNode } from './treeHandle';
import treeHandle from './treeHandle';

const DataBase = () => {
  const { loading, loadDatabase, getTreeData, loadTable } = treeHandle();
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
      <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
        <Row
          gutter={18}
          onClick={() => {
            setMenuStyle({
              ...menuStyle,
              display: 'none',
            });
          }}
          onContextMenu={(e) => {
            e.preventDefault();
           
            return false;
          }}
        >
          <Col span={6}>
            <Card
              title="数据库连接"
              bordered={false}
              loading={loading}
              extra={<PlusSquareOutlined title="添加连接" style={{ cursor: 'pointer' }} />}
            >
              <Tree
                showIcon
                blockNode
                onSelect={(_keys, { node }) => {
                  setMenuStyle({
                    ...menuStyle,
                    display: 'none',
                  });
                  setSelectNode(node);
                }}
                selectedKeys={selectNode ? [selectNode.key.toString()] : []}
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
                loadData={async (node: EventDataNode) => {
                  try {
                    const schemeNode = (node as unknown) as SchemeNode;
                    if (schemeNode.type === 'connection') {
                      await loadDatabase(schemeNode);
                    }
                    if (schemeNode.type === 'database') {
                      await loadTable(schemeNode);
                    }
                  } catch (error) {
                    Promise.resolve();
                  }
                }}
                treeData={getTreeData()}
              />
            </Card>
          </Col>
          <Col span={18}>
            <Card title="数据库" bordered={false}></Card>
          </Col>
        </Row>
      </PageContainer>
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

export default DataBase;
