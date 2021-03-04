/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:06:46
 * @LastEditTime: 2021-03-04 17:42:33
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { CloudOutlined, DatabaseOutlined, TableOutlined } from '@ant-design/icons';
import { PageContainer } from '@ant-design/pro-layout';
import { Card, Col, Row, Tree } from 'antd';
import type { EventDataNode } from 'antd/lib/tree';
import React from 'react';
import type { SchemeNode } from './treeHandle';
import treeHandle from './treeHandle';

const DataBase = () => {
  const { nodeList, loading, loadDatabase, loadTable } = treeHandle();

  const renderIcon = (node: any) => {
    switch (node.type) {
      case 'connection':
        return <CloudOutlined />;
      case 'database':
        return <DatabaseOutlined />;
      case 'table':
        return <TableOutlined />;
      default:
        return <></>;
    }
  };

  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <Row gutter={16}>
        <Col span={4}>
          <Card
            title="数据库连接"
            bordered={false}
            loading={loading}
            // bodyStyle={{ padding: '0px 0px 10px 0px' }}
          >
            <Tree
              showIcon
              icon={renderIcon}
              loadData={async (node: EventDataNode) => {
                const schemeNode = node as SchemeNode;
                if (schemeNode.type === 'connection') {
                  await loadDatabase(schemeNode);
                }
                if (schemeNode.type === 'database') {
                  await loadTable(schemeNode);
                }
                Promise.resolve();
              }}
              treeData={nodeList}
            />
          </Card>
        </Col>
        <Col span={20}>
          <Card title="数据库" bordered={false}>
            Card content
          </Card>
        </Col>
      </Row>
    </PageContainer>
  );
};

export default DataBase;
