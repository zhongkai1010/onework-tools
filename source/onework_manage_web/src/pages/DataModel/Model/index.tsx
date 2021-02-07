import type { ReactNode } from 'react';
import React, { useRef } from 'react';
import { Switch } from 'antd';
import type { ProColumns, ActionType } from '@ant-design/pro-table';
import { EditableProTable } from '@ant-design/pro-table';
import request from 'umi-request';
import type { Item } from '@/types/models/model.d';

const columns: ProColumns<Item>[] = [
  {
    title: '名称',
    dataIndex: 'name',
  },
  {
    title: '编码',
    dataIndex: 'code',
  },
  {
    title: '类型',
    dataIndex: 'type',
    valueEnum: {
      0: { text: '字符串', value: 0 },
      1: { text: '整型', value: 1 },
      2: { text: '数字', value: 2 },
      3: { text: '布尔', value: 3 },
      4: { text: '枚举', value: 4 },
      5: { text: '日期', value: 5 },
      6: { text: '日期时间', value: 6 },
      7: { text: '对象', value: 7 },
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
    title: '默认值',
    dataIndex: 'defaultValue',
  },
  {
    title: '是否允许空',
    dataIndex: 'allowNull',
    render: (text: ReactNode, record: Item) => {
      return (
        <Switch
          checkedChildren="是"
          unCheckedChildren="否"
          defaultChecked={record.allowNull}
          disabled
        />
      );
    },
  },
  {
    title: '启用状态',
    dataIndex: 'isEnable',
    valueType: 'text',
    render: (text: ReactNode, record: Item) => {
      return (
        <Switch
          checkedChildren="是"
          unCheckedChildren="否"
          defaultChecked={record.allowNull}
          disabled
        />
      );
    },
  },
  {
    title: '操作',
    valueType: 'option',
    width: 200,
    render: (text, record, _, action) => [
      <a
        key="editable"
        onClick={() => {
          action.startEditable?.(record.id);
        }}
      >
        编辑
      </a>,
      <a key="delete" onClick={() => {}}>
        删除
      </a>,
    ],
  },
];

export default () => {
  const actionRef = useRef<ActionType>();
  return (
    <EditableProTable<Item>
      columns={columns}
      recordCreatorProps={{
        newRecordType: 'dataSource',
        position: 'top',
        record: () => ({
          id: '12',
          name: '', // 名称
          code: '', // 编码
          type: 1, // 类型
          allowNull: false, // 是否允许空
          rule: null, // 规则
          length: 255, // 长度
          precision: null, // 精度
          defaultValue: null, // 默认值
          description: '', // 描述
          isEnable: true, // 启用状态
          isDelete: false,
        }),
      }}
      actionRef={actionRef}
      request={async (params = {}) =>
        request<{
          data: Item[];
        }>('/api/model/public_data_item/getlist', {
          params,
        })
      }
      editable={{
        type: 'multiple',
      }}
      rowKey="id"
      pagination={{
        pageSize: 10,
      }}
      headerTitle="高级表格"
    />
  );
};
