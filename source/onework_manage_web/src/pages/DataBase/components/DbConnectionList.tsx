/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:18:05
 * @LastEditTime: 2021-03-14 10:55:17
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbConnectionList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { EditOutlined, EllipsisOutlined, SettingOutlined } from '@ant-design/icons';
import { Card, Col, Descriptions, Row } from 'antd';
import React from 'react';
import type { SchemeNode } from '../treeHandleHook';

interface Props {
  data: SchemeNode[];
}

const DbConnectionList = (props: Props) => {
  const render = (connection: API.DataBase.Connection) => {
    return (
      <Col span={8}>
        <Card
          title={connection.name}
          actions={[
            <SettingOutlined key="setting" />,
            <EditOutlined key="edit" />,
            <EllipsisOutlined key="ellipsis" />,
          ]}
        >
          <Descriptions>
            <Descriptions.Item label="主机" span={3}>
              {connection.host}
            </Descriptions.Item>
            <Descriptions.Item label="端口" span={3}>
              {connection.port}
            </Descriptions.Item>
            <Descriptions.Item label="账户" span={3}>
              {connection.username}
            </Descriptions.Item>
            <Descriptions.Item label="密码" span={3}>
              {connection.password}
            </Descriptions.Item>
            <Descriptions.Item label="类型" span={3}>
              {connection.dbType}
            </Descriptions.Item>
          </Descriptions>
        </Card>
      </Col>
    );
  };

  return (
    <Row gutter={[16, 16]}>
      {props.data.map((t) => (t.source.connection ? render(t.source.connection) : <></>))}
    </Row>
  );
};

export default DbConnectionList;
