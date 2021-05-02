/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:10:43
 * @LastEditTime: 2021-03-24 16:59:54
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbDataBaseList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { DeleteOutlined, SyncOutlined, TableOutlined } from '@ant-design/icons';
import { Card, Col, Descriptions, Row } from 'antd';
import React from 'react';
import type { SchemeNode } from '../treeHandle';
import IconButton from '@/components/IconButton';
 

interface Props {
  node: SchemeNode;
  databases: API.DataBase.Database[];
  loadDatabase: (node: SchemeNode) => Promise<void>;
  syncDatabase: (
    database: API.DataBase.Database,
    connection: API.DataBase.Connection,
  ) => Promise<void>;
  loadTable: (
    database: API.DataBase.Database,
    connection: API.DataBase.Connection,
  ) => Promise<void>;
  deleteTable: (database: API.DataBase.Database) => Promise<void>;
}

const DbDataBaseList = (props: Props) => {
  const { connection } = props.node.source;
  if (!connection) return <></>;
  const renderCard = (t: API.DataBase.Database) => {
    return (
      <Col span={8} key={`${connection.uid}_${t.name}_col`}>
        <Card
          key={`${connection.uid}_${t.name}_card`}
          title={t.name}
          actions={[
            <IconButton
              title="查看数据表"
              icon={<TableOutlined />}
              onClick={async () => {
                await props.loadTable(t, connection);
              }}
            />,
            <IconButton
              title="删除数据库"
              icon={<DeleteOutlined />}
              onClick={async () => {
                await props.deleteTable(t);
              }}
            />,
            <IconButton
              title="同步表结构"
              icon={<SyncOutlined />}
              onClick={async () => {
                await props.syncDatabase(t, connection);
              }}
            />,
          ]}
        >
          <Descriptions key={`${connection.uid}_${t.name}_descriptions`}>
            <Descriptions.Item label="在线状态" span={3}>
              {t.isOnline ? '在线' : '离线'}
            </Descriptions.Item>
            <Descriptions.Item label="是否同步" span={3}>
              {t.isSync ? '已同步' : '未同步'}
            </Descriptions.Item>
            <Descriptions.Item label="最后同步时间" span={3}>
              {t.lastSyncDate}
            </Descriptions.Item>
          </Descriptions>
        </Card>
      </Col>
    );
  };
  const renderBody = () => {
    if (!props.node.isLoad) {
      return (
        <IconButton
          onClick={async () => {
            await props.loadDatabase(props.node);
          }}
          type="primary"
          icon={undefined}
          style={{ border: 1 }}
        >
          加载连接数据库
        </IconButton>
      );
    }
    return <Row gutter={[16, 16]}>{props.databases.map((t) => renderCard(t))}</Row>;
  };
  return <>{renderBody()}</>;
};

export default DbDataBaseList;
