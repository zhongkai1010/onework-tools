/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:09:57
 * @LastEditTime: 2021-03-15 16:53:43
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbTableList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { EllipsisOutlined, SyncOutlined, TableOutlined } from '@ant-design/icons';
import { Button, Card, Col, Descriptions, Row, Tooltip } from 'antd';
import React from 'react';

interface Props {
  connection: API.DataBase.Connection;
  database: API.DataBase.Database;
  tables: API.DataBase.Table[];
}

const DbTableList = (props: Props) => {
  const renderCard = (t: API.DataBase.Table) => {
    return (
      <Col span={8} key={`${props.connection.uid}_${t.dbName}_${t.uid}_col`}>
        <Card
          key={`${props.connection.uid}_${t.dbName}_${t.uid}_card`}
          title={t.name}
          actions={[
            <Tooltip title="同步表结构">
              <Button icon={<SyncOutlined />} type="text" />
            </Tooltip>,
            <Tooltip title="查看数据表">
              <TableOutlined key="loading" />
            </Tooltip>,
            <EllipsisOutlined key="ellipsis" />,
          ]}
        >
          <Descriptions key={`${props.connection.uid}_${t.dbName}_${t.uid}_descriptions`}>
            <Descriptions.Item label="数据库名" span={3}>
              {t.dbName}
            </Descriptions.Item>
            <Descriptions.Item label="表名" span={3}>
              {t.code}
            </Descriptions.Item>
            <Descriptions.Item label="描述" span={3}>
              {t.name}
            </Descriptions.Item>
          </Descriptions>
        </Card>
      </Col>
    );
  };

  return <Row gutter={[16, 16]}>{props.tables.map((t) => renderCard(t))}</Row>;
};

export default DbTableList;
