/*
 * @Author: 钟凯
 * @Date: 2021-02-18 18:10:26
 * @LastEditTime: 2021-02-19 09:47:58
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\TableDetails.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React from 'react';
import { Col, Row } from 'antd';
import type { ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';

interface Props {
  data: API.Model.DataModel;
}

const typeValueEnum = {
  character: { text: '文本' },
  integer: { text: '整型' },
  digital: { text: '数字' },
  boolean: { text: '布尔' },
  enumerate: { text: '枚举' },
  date: { text: '日期' },
};
const outputTypeEnum = {
  void: { text: '无' },
  value: { text: '值' },
  object: { text: '对象' },
};

const TableDetails = (props: Props) => {
  const itemColumns: ProColumns<API.Model.DataModelItem>[] = [
    {
      title: '编码',
      dataIndex: 'itemCode',
    },
    {
      title: '名称',
      dataIndex: 'itemName',
    },
    {
      title: '类型',
      dataIndex: 'itemType',
      valueEnum: typeValueEnum,
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
  ];
  const behaviorColumns: ProColumns<API.Model.DataModelBehavior>[] = [
    {
      title: '名称',
      dataIndex: 'behaviorName',
    },
    {
      title: '名称',
      dataIndex: 'behaviorCode',
    },
    {
      title: '输入类型',
      dataIndex: 'outputType',
      render: (text: any, record: any) => {
        const inputs = record.inputs || [];
        if (inputs === 0) return null;
        return outputTypeEnum[inputs[0].type].text;
      },
    },
    {
      title: '输入类型值',
      dataIndex: 'outputValue',
      render: (text: any, record: any) => {
        const inputs = record.inputs || [];
        if (inputs === 0) return null;
        return inputs[0].value;
      },
    },
    {
      title: '输出类型',
      dataIndex: 'outputType',
      valueEnum: outputTypeEnum,
    },
    {
      title: '输出类型值',
      dataIndex: 'outputValue',
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
