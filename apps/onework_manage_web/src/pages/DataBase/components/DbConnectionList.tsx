/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:18:05
 * @LastEditTime: 2021-03-18 11:12:21
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbConnectionList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { DatabaseOutlined, DeleteOutlined, EditOutlined } from '@ant-design/icons';
import { Button, Card, Col, Descriptions, Row } from 'antd';
import React from 'react';
import EditConnectionModal from './EditConnectionModal';
import IconButton from '@/components/IconButton';
 

interface Props {
  connections: API.DataBase.Connection[];
  loadDatabase: (database: API.DataBase.Connection) => Promise<any>;
  updateDatabase: (data: any) => Promise<boolean>;
  deleteDatabase: (database: API.DataBase.Connection) => Promise<any>;
}

const DbConnectionList = (props: Props) => {
  const renderCard = (connection: API.DataBase.Connection) => {
    return (
      <Col span={8} key={`${connection.uid}_col`}>
        <Card
          key={`${connection.uid}_card`}
          title={connection.name}
          actions={[
            <IconButton
              title="查看数据库"
              icon={<DatabaseOutlined />}
              onClick={async () => {
                await props.loadDatabase(connection);
              }}
            />,
            <EditConnectionModal
              key="edit"
              title="编辑连接"
              trigger={<Button title="修改连接" icon={<EditOutlined />} type="text" />}
              data={connection}
              onFinish={(data) => {
                return props.updateDatabase({ ...connection, ...data });
              }}
            />,
            <IconButton
              title="删除连接"
              icon={<DeleteOutlined />}
              onClick={async () => {
                await props.deleteDatabase(connection);
              }}
            />,
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
