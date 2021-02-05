import React, { useRef } from 'react';
import { PlusOutlined, EllipsisOutlined } from '@ant-design/icons';
import { Button, Menu, Dropdown } from 'antd';
import type { ProColumns, ActionType } from '@ant-design/pro-table';
import ProTable, { TableDropdown } from '@ant-design/pro-table';
import request from 'umi-request';
import type { Item } from '@/pages/Model/data.d';

const columns: ProColumns<Item>[] = [
  {
    title: '名称',
    dataIndex: 'name',
    width: 100,
  },
  {
    title: '编码',
    dataIndex: 'code',
    width: 100,
  },
  {
    title: '类型',
    dataIndex: 'type',
    width: 100,
  },
  {
    title: '是否允许空',
    dataIndex: 'allowNull',
    hideInTable: true,
  },
  {
    title: '规则',
    dataIndex: 'rule',
    hideInTable: true,
  },
  {
    title: '长度',
    dataIndex: 'length',
    hideInTable: true,
  },
  {
    title: '精度',
    dataIndex: 'precision',
    hideInTable: true,
  },
  {
    title: '默认值',
    dataIndex: 'defaultValue',
    hideInTable: true,
  },
  {
    title: '描述',
    dataIndex: 'description',
  },
  {
    title: '启用状态',
    dataIndex: 'isEnable',
  },
  {
    title: '是否删除',
    dataIndex: 'isDelete',
  },
  {
    title: '操作',
    valueType: 'option',
    render: (text, record, _, action) => [
      <a
        key="editable"
        onClick={() => {
          action.startEditable?.(record.id);
        }}
      >
        编辑
      </a>,
      <a href="" target="_blank" rel="noopener noreferrer" key="view">
        查看
      </a>,
      <TableDropdown
        key="actionGroup"
        onSelect={() => action.reload()}
        menus={[
          { key: 'copy', name: '复制' },
          { key: 'delete', name: '删除' },
        ]}
      />,
    ],
  },
];
const menu = (
  <Menu>
    <Menu.Item key="1">1st item</Menu.Item>
    <Menu.Item key="2">2nd item</Menu.Item>
    <Menu.Item key="3">3rd item</Menu.Item>
  </Menu>
);
export default () => {
  const actionRef = useRef<ActionType>();
  return (
    <ProTable<Item>
      columns={columns}
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
      search={{
        labelWidth: 'auto',
      }}
      form={{
        // 由于配置了 transform，提交的参与与定义的不同这里需要转化一下
        syncToUrl: (values, type) => {
          if (type === 'get') {
            return {
              ...values,
              created_at: [values.startTime, values.endTime],
            };
          }
          return values;
        },
      }}
      pagination={{
        pageSize: 5,
      }}
      dateFormatter="string"
      headerTitle="高级表格"
      toolBarRender={() => [
        <Button key="button" icon={<PlusOutlined />} type="primary">
          新建
        </Button>,
        <Dropdown key="menu" overlay={menu}>
          <Button>
            <EllipsisOutlined />
          </Button>
        </Dropdown>,
      ]}
    />
  );
};
