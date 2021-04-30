/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:09:57
 * @LastEditTime: 2021-03-24 09:12:37
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbTableList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { DeleteOutlined, ImportOutlined, ZoomInOutlined } from '@ant-design/icons';
import { Card, Col, Descriptions, Row } from 'antd';
import React from 'react';
import type { SchemeNode } from '../treeHandle';
import IconButton from '@/components/IconButton';
 

interface Props {
  node: SchemeNode;
  tables: API.DataBase.Table[];
  loadTable: (node: SchemeNode) => Promise<void>;
  syncDatabase: (node: SchemeNode) => Promise<void>;
  showColumn: (node: SchemeNode, table: API.DataBase.Table) => void;
}

const DbTableList = (props: Props) => {
  const { connection } = props.node.source;
  if (!connection) return <></>;
  const renderCard = (t: API.DataBase.Table) => {
    return (
      <Col span={8} key={`${connection.uid}_${t.dbName}_${t.uid}_col`}>
        <Card
          key={`${connection.uid}_${t.dbName}_${t.uid}_card`}
          title={t.name}
          actions={[
            <IconButton
              title="查看字段"
              icon={<ZoomInOutlined />}
              onClick={async () => {
                props.showColumn(props.node, t);
                Promise.resolve();
              }}
            />,
            <IconButton
              title="数据模型"
              icon={<ImportOutlined />}
              onClick={async () => {
                Promise.resolve();
              }}
            />,

            <IconButton
              title="删除"
              icon={<DeleteOutlined />}
              onClick={async () => {
                Promise.resolve();
              }}
            />,
          ]}
        >
          <Descriptions key={`${connection.uid}_${t.dbName}_${t.uid}_descriptions`}>
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
  const renderBody = () => {
    if (!props.node.source.database?.isSync) {
      return (
        <IconButton
          onClick={async () => {
            await props.syncDatabase(props.node);
          }}
          type="primary"
          icon={undefined}
          style={{ border: 1 }}
        >
          同步数据库
        </IconButton>
      );
    }
    if (!props.node.isLoad) {
      return (
        <IconButton
          onClick={async () => {
            await props.loadTable(props.node);
          }}
          type="primary"
          icon={undefined}
          style={{ border: 1 }}
        >
          加载数据库表
        </IconButton>
      );
    }
    return <Row gutter={[16, 16]}>{props.tables.map((t) => renderCard(t))}</Row>;
  };
  return <>{renderBody()}</>;
};

export default DbTableList;
