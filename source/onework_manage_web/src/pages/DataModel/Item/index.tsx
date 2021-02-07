/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-02-07 17:45:26
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Item\index.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';
import type { Item } from '@/types/models/model.d';
import { getItemList } from './service';
import { Button } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import { ModalForm, ProFormText, ProFormSelect } from '@ant-design/pro-form';
import { Translate } from '@/utils/translate';

const typeValueEnum = {
  character: { text: '字符串' },
  integer: { text: '整型' },
  digital: { text: '数字' },
  boolean: { text: '布尔' },
  enumerate: { text: '枚举' },
  date: { text: '日期' },
  datetime: { text: '日期时间' },
};

const statusValueEnum = {
  enable: { text: '启用' },
  disable: { text: '停用' },
};

export default () => {
  const columns: ProColumns<Item>[] = [
    {
      title: '编码',
      sorter: true,
      dataIndex: 'code',
    },
    {
      title: '名称',
      sorter: true,
      dataIndex: 'name',
    },
    {
      title: '类型',
      dataIndex: 'type',
      valueType: 'select',
      sorter: true,
      initialValue: 'character',
      filters: true,
      width: 150,
      valueEnum: typeValueEnum,
    },
    {
      title: '创建时间',
      dataIndex: 'created',
      valueType: 'date',
      sorter: true,
      width: 150,
    },
    {
      title: '修改时间',
      dataIndex: 'updated',
      valueType: 'date',
      sorter: true,
      width: 150,
    },
    {
      title: '状态',
      dataIndex: 'status',
      valueType: 'select',
      filters: true,
      valueEnum: statusValueEnum,
      width: 100,
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
      <ProTable<Item>
        headerTitle="查询表格"
        rowKey="id"
        options={{
          density: true,
          search: true,
        }}
        search={false}
        debounceTime={500}
        toolBarRender={() => [
          <ModalForm
            title="新建数据项"
            layout="horizontal"
            trigger={
              <Button type="primary">
                <PlusOutlined />
                新建
              </Button>
            }
          >
            <ProFormText label="名称" name="name" />
            <ProFormText label="编码" name="code" />
            <ProFormSelect
              label="类型"
              name="type"
              options={[
                {
                  value: 1,
                  label: '字符串',
                },
                {
                  value: 2,
                  label: '整型',
                },
                {
                  value: 3,
                  label: '数字',
                },
                {
                  value: 4,
                  label: '布尔',
                },
                {
                  value: 5,
                  label: '枚举',
                },
                {
                  value: 6,
                  label: '日期',
                },
                {
                  value: 7,
                  label: '日期时间',
                },
              ]}
            />
          </ModalForm>,
          <Button
            onClick={() => {
              Translate.to('高度').then((data) => {
                console.log(data);
              });
            }}
          >
            测试
          </Button>,
        ]}
        columns={columns}
        request={() => getItemList()}
      />
    </PageContainer>
  );
};
