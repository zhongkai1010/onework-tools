/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:18:05
 * @LastEditTime: 2021-03-15 15:56:02
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbConnectionList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { DeleteOutlined, EditOutlined, EllipsisOutlined, SyncOutlined } from '@ant-design/icons';
import { Card, Col, Descriptions, Row, Tooltip } from 'antd';
import React from 'react';
import EditConnectionModal from './EditConnectionModal';

interface Props {
  connections: API.DataBase.Connection[];
  onSysnc: (connection: API.DataBase.Connection) => void;
  onEditd: (connection: API.DataBase.Connection) => Promise<boolean>;
  onRemove: (connection: API.DataBase.Connection) => void;
}

const DbConnectionList = (props: Props) => {
  const renderCard = (connection: API.DataBase.Connection) => {
    return (
      <Col span={8} key={`${connection.uid}_col`}>
        <Card
          key={`${connection.uid}_card`}
          title={connection.name}
          actions={[
            <Tooltip title="加载数据库">
              <SyncOutlined key="loading" onClick={() => props.onSysnc(connection)} />
            </Tooltip>,
            <Tooltip title="修改连接">
              <EditConnectionModal
                key="edit"
                trigger={<EditOutlined key="edit_icon" />}
                data={connection}
                onFinish={async (data) => {
                  const editConnection = { ...connection, ...data } as API.DataBase.Connection;
                  return await props.onEditd(editConnection);
                }}
              />
            </Tooltip>,
            <Tooltip title="删除连接">
              <DeleteOutlined key="remove" onClick={() => props.onRemove(connection)} />
            </Tooltip>,
            <EllipsisOutlined key="ellipsis" />,
          ]}
        >
          <Descriptions key={`${connection.uid}_descriptions`}>
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
  return <Row gutter={[16, 16]}>{props.connections.map((t) => renderCard(t))}</Row>;
};

export default DbConnectionList;
