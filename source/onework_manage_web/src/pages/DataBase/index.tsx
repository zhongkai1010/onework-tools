/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:06:46
 * @LastEditTime: 2021-03-14 16:16:11
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { PageContainer } from '@ant-design/pro-layout';
import { Card, Col, Row, Space } from 'antd';
import React, { useState } from 'react';
import type { SchemeNode } from './treeHandleHook';

import AddConnectionModal from './components/AddConnectionModal';
import RefreshConnectionButton from './components/RefreshConnectionButton';
import DbDataBaseList from './components/DbDataBaseList';
import DbTableList from './components/DbTableList';
import DbColumnList from './components/DbColumnList';
import DbConnectionList from './components/DbConnectionList';
import SchemeTree from './components/SchemeTree';
import treeHandleHook from './treeHandleHook';

const DataBase = () => {
  const treeHandle = treeHandleHook();
  const [selectNode, setSelectNode] = useState<SchemeNode>();
  const renderList = () => {
    if (!selectNode) return <DbConnectionList data={treeHandle.nodeList} />;
    switch (selectNode.type) {
      case 'connection':
        return (
          <>
            {selectNode.source?.connection ? (
              <DbDataBaseList data={selectNode.source?.connection} />
            ) : (
              <></>
            )}
          </>
        );
      case 'database':
        return (
          <>
            {selectNode.source?.database ? (
              <DbTableList data={selectNode.source?.database} />
            ) : (
              <></>
            )}
          </>
        );
      case 'table':
        return (
          <>{selectNode.source?.table ? <DbColumnList data={selectNode.source?.table} /> : <></>}</>
        );
      default:
        return <DbConnectionList data={treeHandle.nodeList} />;
    }
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
                <AddConnectionModal />
                <RefreshConnectionButton
                  disabled={treeHandle.loading}
                  onClick={() => {
                    setSelectNode(undefined);
                    treeHandle.refreshConnection();
                  }}
                />
              </Space>
            }
          >
            <SchemeTree treeHandle={treeHandle} />
          </Card>
        </Col>
        <Col span={18}>
          <Card title="数据库" bordered={false}>
            {/* {renderList()} */}
          </Card>
        </Col>
      </Row>
    </PageContainer>
  );
};

export default DataBase;
