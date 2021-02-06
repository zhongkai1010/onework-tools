/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-02-06 18:22:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Item\index.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { PageContainer } from '@ant-design/pro-layout';
import type { ProColumns } from '@ant-design/pro-table';
import { EditableProTable } from '@ant-design/pro-table';
import React, { useState } from 'react';
import { DataItemType } from '@/pages/DataModel/data.d';
import type { Item } from '@/pages/DataModel/data.d';
import { getItemList } from './service';
import { DataStatus } from '../data.d';
import type { FormInstance } from 'antd';
import { Button } from 'antd';
import { Input } from 'antd';
import { PlusOutlined } from '@ant-design/icons';

const translateaa = require('google-translate-api');

const typeValueEnum = {
  1: { text: '字符串' },
  2: { text: '整型' },
  3: { text: '数字' },
  4: { text: '布尔' },
  5: { text: '枚举' },
  6: { text: '日期' },
  7: { text: '日期时间' },
  8: { text: '对象' },
};

const statusValueEnum = {
  1: { text: '启用' },
  2: { text: '停用' },
};

const defaultItem = {
  id: 0, // Id
  uuid: '',
  name: '', // 名称
  code: '', // 编码
  type: DataItemType.Character, // 类型
  allowNull: true, // 是否允许空
  rule: null, // 规则
  length: 0, // 长度
  precision: 0, // 精度
  defaultValue: null, // 默认值
  description: '', // 描述
  status: DataStatus.Enable, // 启用状态
  updatedAt: null,
  createdAt: null,
};
const onNameChange = (record: Item | undefined, form: FormInstance<any>) => {
  form.setFieldsValue({ ...record, code: '123' });
};

export default () => {
  const [editableKeys, setEditableRowKeys] = useState<React.Key[]>([]);
  const [dataSource, setDataSource] = useState<Item[]>([]);
  const onClick = () => {
    translateaa('Ik spreek Engels', { to: 'en' })
      .then((res) => {
        console.log(res.text);
        //=> I speak English
        console.log(res.from.language.iso);
        //=> nl
      })
      .catch((err) => {
        console.error(err);
      });
  };
  const columns: ProColumns<Item>[] = [
    {
      title: '编码',
      dataIndex: 'code',
    },
    {
      title: '名称',
      dataIndex: 'name',
      renderFormItem: (_, { record, isEditable }, form) => {
        return isEditable ? (
          <Input
            onChange={() => {
              onNameChange(record, form);
            }}
          />
        ) : (
          record?.name
        );
      },
    },
    {
      title: '类型',
      dataIndex: 'type',
      valueType: 'select',
      initialValue: [1],
      filters: true,
      width: 150,
      valueEnum: typeValueEnum,
    },

    {
      title: '时间',
      dataIndex: 'updatedAt',
      valueType: 'date',
      width: 150,
      renderFormItem: () => {
        return '';
      },
    },
    {
      title: '编辑人',
      dataIndex: 'createdAt',
      valueType: 'date',
      width: 150,
      renderFormItem: () => {
        return '';
      },
    },
    {
      title: '状态',
      dataIndex: 'status',
      valueType: 'select',
      filters: true,
      hideInForm: false,
      valueEnum: statusValueEnum,
      width: 100,
      renderFormItem: () => {
        return <span style={{ color: 'green' }}>启用</span>;
      },
      render: (dom, item) => {
        return item.status === DataStatus.Enable ? (
          <span style={{ color: 'green' }}>启用</span>
        ) : (
          <span style={{ color: 'red' }}>停用</span>
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

  return (
    <PageContainer content="欢迎使用 ProLayout 组件">
      <EditableProTable<Item>
        headerTitle="查询表格"
        rowKey="id"
        options={{
          density: true,
          search: true,
        }}
        search={false}
        recordCreatorProps={{
          newRecordType: 'dataSource',
          position: 'bottom',
          record: defaultItem,
        }}
        debounceTime={500}
        maxLength={20000}
        toolBarRender={() => [
          <Button key="button" icon={<PlusOutlined />} type="primary" onClick={onClick}>
            新建
          </Button>,
        ]}
        value={dataSource}
        onChange={setDataSource}
        columns={columns}
        request={() => getItemList()}
        editable={{
          type: 'multiple',
          editableKeys,
          onChange: setEditableRowKeys,
          onSave: (key, row, newLine) => {
            console.log(key);
            console.log(row);
            console.log(newLine);
            return new Promise((resolve) => {
              resolve(newLine);
            });
          },
        }}
      />
    </PageContainer>
  );
};
