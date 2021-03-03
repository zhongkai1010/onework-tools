/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:06:46
 * @LastEditTime: 2021-03-03 16:32:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { PageContainer } from '@ant-design/pro-layout';
import { Card, Col, Row } from 'antd';
import React from 'react';
import { useRequest } from 'umi';

const DataBase = () => {
  
  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <Row gutter={16}>
        <Col span={4}>
          <Card title="数据库连接" bordered={false} loading={true}>
            Card content
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
