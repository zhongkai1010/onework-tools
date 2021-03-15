/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:06:46
 * @LastEditTime: 2021-03-15 17:55:17
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { PageContainer } from '@ant-design/pro-layout';
import { Card, Col, Row, Space } from 'antd';
import React, { useState } from 'react';
import type { SchemeNode } from './treeHandleHook';
import { handleConnection } from './treeHandleHook';
import EditConnectionModal from './components/EditConnectionModal';
import RefreshConnectionButton from './components/RefreshConnectionButton';
import DbDataBaseList from './components/DbDataBaseList';
import DbTableList from './components/DbTableList';
import DbColumnList from './components/DbColumnList';
import DbConnectionList from './components/DbConnectionList';
import SchemeTree from './components/SchemeTree';
import treeHandleHook from './treeHandleHook';
import * as connectionServices from './services/connection';
import { useRequest } from 'umi';

const DataBase = () => {
  const treeHandle = treeHandleHook();
  const updateConnectionOperate = useRequest(connectionServices.update, { manual: true });
  const addConnectionOperate = useRequest(connectionServices.insert, {
    manual: true,
    throwOnError: true,
  });
  const [selectNode, setSelectNode] = useState<SchemeNode>();
  const renderList = () => {
    const type = selectNode ? selectNode.type : '';
    if (type === 'connection') {
      if (!selectNode?.source.connection) return <></>;
      const connection = selectNode?.source.connection;
      const schemeNodes = (selectNode.children || []) as SchemeNode[];
      const databases = [];
      for (let i = 0; i < schemeNodes.length; i += 1) {
        const node = schemeNodes[i];
        if (node.source.database) {
          databases.push(node.source.database);
        }
      }
      return <DbDataBaseList connection={connection} databases={databases} />;
    }
    if (type === 'database') {
      if (!selectNode?.source.database) return <></>;
      if (!selectNode?.source.connection) return <></>;
      const connection = selectNode?.source.connection;
      const database = selectNode?.source.database;
      const schemeNodes = (selectNode.children || []) as SchemeNode[];
      const tables = [];
      for (let i = 0; i < schemeNodes.length; i += 1) {
        const node = schemeNodes[i];
        if (node.source.table) {
          tables.push(node.source.table);
        }
      }
      return <DbTableList database={database} connection={connection} tables={tables} />;
    }
    if (type === 'table') {
      if (!selectNode?.source?.table) return <></>;
      return <DbColumnList table={selectNode.source?.table} />;
    }
    // 节点集合中读取连接集合
    const connectionNodes = treeHandle.nodeList.filter((t) => t.type === 'connection');
    const connections = [];
    for (let i = 0; i < connectionNodes.length; i += 1) {
      const node = connectionNodes[i];
      if (node.source.connection) {
        connections.push(node.source.connection);
      }
    }
    return (
      <DbConnectionList
        connections={connections}
        onEditd={async (data) => {
          const connection = await updateConnectionOperate.run(data);
          const schemeNode = treeHandle.nodeList.find((t) => t.key === connection.uid);
          if (!schemeNode) throw new Error('connection node no find');
          treeHandle.closeConnection(schemeNode);
          return Promise.resolve(true);
        }}
        onRemove={() => {}}
        onSysnc={() => {}}
      />
    );
  };
  const getCardTitle = () => {
    if (!selectNode) return '数据库连接';
    if (selectNode.type === 'connection') return `${selectNode.source.connection?.name} - 数据库`;
    if (selectNode.type === 'database') return `${selectNode.source.database?.name} - 表`;
    if (selectNode.type === 'table') return `${selectNode.source.table?.name} - 字段`;
    return '数据库连接';
  };
  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <Row gutter={18}>
        <Col span={6} onContextMenu={(e) => e.preventDefault()}>
          <Card
            title="数据库连接"
            bordered={false}
            loading={treeHandle.loading}
            extra={
              <Space>
                <EditConnectionModal
                  onFinish={async (data) => {
                    const result = await addConnectionOperate.run(data);
                    const schemeNode = handleConnection(result);
                    await treeHandle.addConnection(schemeNode);
                    return Promise.resolve(true);
                  }}
                />
                <RefreshConnectionButton
                  disabled={treeHandle.loading}
                  onClick={async () => {
                    setSelectNode(undefined);
                    await treeHandle.refreshConnection();
                  }}
                />
              </Space>
            }
          >
            <SchemeTree
              treeHandle={treeHandle}
              onNodeSelect={(node) => {
                setSelectNode(node);
              }}
            />
          </Card>
        </Col>
        <Col span={18}>
          <Card title={getCardTitle()} loading={treeHandle.loading}>
            {renderList()}
          </Card>
        </Col>
      </Row>
    </PageContainer>
  );
};

export default DataBase;
