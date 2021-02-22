/*
 * @Author: 钟凯
 * @Date: 2021-02-18 18:10:26
 * @LastEditTime: 2021-02-22 16:40:25
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\TableDetails.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React from 'react';
import { Col, Row } from 'antd';
import type { ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';
import { BehaviorOperationTypeEnum, ItemTypeEnum } from '../../common';

interface Props {
  data: API.Model.DataModel;
}

const TableDetails = (props: Props) => {
  const itemColumns: ProColumns<API.Model.DataModelItem>[] = [
    {
      title: '编码',
      dataIndex: 'code',
    },
    {
      title: '名称',
      dataIndex: 'name',
    },
    {
      title: '类型',
      dataIndex: 'itemType',
      valueEnum: ItemTypeEnum,
    },
    {
      title: '是否为空',
      dataIndex: 'isNull',
      renderText: (text: any) => {
        return text ? '是' : '否';
      },
    },
    {
      title: '长度',
      dataIndex: 'length',
    },
    {
      title: '精度',
      dataIndex: 'precision',
    },
    {
      title: '是否标识',
      dataIndex: 'isUnique',
      renderText: (text: any) => {
        return text ? '是' : '否';
      },
    },
  ];
  const behaviorColumns: ProColumns<API.Model.DataModelBehavior>[] = [
    {
      title: '名称',
      dataIndex: 'name',
    },
    {
      title: '名称',
      dataIndex: 'code',
    },
    {
      title: '操作类型',
      dataIndex: 'operationType',
      valueEnum: BehaviorOperationTypeEnum,
    },
    {
      title: '描述',
      ellipsis: true,
      dataIndex: 'description',
    },
  ];
  return (
    <Row gutter={[16, 16]} style={{ padding: 10 }}>
      <Col span={24}>
        <ProTable<API.Model.DataModelItem>
          key={`${props.data.id}_item_table`}
          rowKey="uid"
          tableStyle={{ padding: 10 }}
          size="middle"
          headerTitle="数据项"
          dataSource={props.data.items}
          columns={itemColumns}
          pagination={false}
          bordered
          options={false}
          search={false}
        />
      </Col>
      <Col span={24}>
        <ProTable<API.Model.DataModelBehavior>
          tableStyle={{ padding: 10 }}
          rowKey="uid"
          key={`${props.data.id}_behavior_table`}
          headerTitle="行为"
          dataSource={props.data.behaviors || []}
          size="middle"
          bordered
          columns={behaviorColumns}
          pagination={false}
          options={false}
          search={false}
        />
      </Col>
    </Row>
  );
};

export default TableDetails;
