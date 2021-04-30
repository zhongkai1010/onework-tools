/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:10:43
 * @LastEditTime: 2021-03-15 16:07:09
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbDataBaseList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { EllipsisOutlined, SyncOutlined, TableOutlined } from '@ant-design/icons';
import { Button, Card, Col, Descriptions, Row, Tooltip } from 'antd';
import React from 'react';
import * as schemeServices from '../services/scheme';
import { useRequest } from 'umi';

interface Props {
  connection: API.DataBase.Connection;
  databases: API.DataBase.Database[];
}

const DbDataBaseList = (props: Props) => {
  const syncDataBaseOperate = useRequest(schemeServices.syncDataBase, { manual: true });
  const renderCard = (t: API.DataBase.Database) => {
    return (
      <Col span={8} key={`${props.connection.uid}_${t.name}_col`}>
        <Card
          key={`${props.connection.uid}_${t.name}_card`}
          title={t.name}
          actions={[
            <Tooltip title="同步表结构">
              <Button
                icon={<SyncOutlined />}
                type="text"
                onClick={async () => {
                  const data = await syncDataBaseOperate.run({
                    uid: props.connection.uid,
                    database: t.name,
                  });
                  console.log(data)
                }}
                loading={syncDataBaseOperate.loading}
                style={{ backgroundColor: 'transparent' }}
              />
            </Tooltip>,
            <Tooltip title="查看数据表">
              <TableOutlined key="loading" />
            </Tooltip>,
            <EllipsisOutlined key="ellipsis" />,
          ]}
        >
          <Descriptions key={`${props.connection.uid}_${t.name}_descriptions`}>
            <Descriptions.Item label="数据库名" span={3}>
              {t.name}
            </Descriptions.Item>
          </Descriptions>
        </Card>
      </Col>
    );
  };

  return <Row gutter={[16, 16]}>{props.databases.map((t) => renderCard(t))}</Row>;
};

export default DbDataBaseList;
