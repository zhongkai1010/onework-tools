/* eslint-disable no-console */
/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-03-03 16:43:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\item\index.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useRef } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumns } from '@ant-design/pro-table';
import EditableProTable from '@ant-design/pro-table';
import { Button, Form, Input } from 'antd';
import { Translate } from '@/utils/translate';
import { ModalForm, ProFormText, ProFormSelect } from '@ant-design/pro-form';
import * as itemService from '@/pages/DataModel/services/item';
import FastFormModal from './components/FastFormModal';
import { ItemTypeEnum, ItemTypeOption } from '@/pages/DataModel/common';

export default () => {
  const [form] = Form.useForm();
  const tabRef = useRef<ActionType>();
  const columns: ProColumns<API.Model.Item>[] = [
    {
      title: '名称',
      sorter: true,
      dataIndex: 'name',
    },
    {
      title: '编码',
      sorter: true,
      dataIndex: 'code',
    },
    {
      title: '类型',
      dataIndex: 'type',
      valueType: 'select',
      sorter: true,
      initialValue: 'character',
      filters: true,
      width: 150,
      valueEnum: ItemTypeEnum,
    },
    {
      title: '计数',
      dataIndex: 'cumulate',
      editable: false,
      width: 100,
    },
    {
      title: '创建时间',
      dataIndex: 'createdAt',
      editable: false,
      valueType: 'date',
      sorter: true,
      width: 150,
    },
    {
      title: '修改时间',
      dataIndex: 'updatedAt',
      valueType: 'date',
      editable: false,
      sorter: true,
      width: 150,
    },
    {
      title: '操作',
      valueType: 'option',
      width: 200,
      render: (_text, record, _, action) => [
        <a
          key="editable"
          onClick={() => {
            action.startEditable?.(record.uid);
          }}
        >
          编辑
        </a>,
      ],
    },
  ];
  return (
    <PageContainer content="构建数据模型集成元素">
      <EditableProTable<API.Model.Item>
        rowKey="uid"
        bordered
        actionRef={tabRef}
        options={{
          density: true,
          search: {
            allowClear: true,
            enterButton: true,
          },
        }}
        search={false}
        debounceTime={800}
        editable={{
          type: 'multiple',
          onSave: (_key, row) => {
            return itemService.update(row);
          },
          onDelete: (_, row: API.Model.Item) => {
            return itemService.remove([row.uid]);
          },
        }}
        pagination={{
          defaultPageSize: 10,
        }}
        toolBarRender={() => [
          <ModalForm
            title="新建数据项"
            layout="horizontal"
            form={form}
            onFinish={async (values) => {
              const result = await itemService.insert(values);
              if (result.success) {
                tabRef.current?.reload();
              }
              return result.success;
            }}
            trigger={<Button type="primary">新建</Button>}
          >
            <Form.Item
              label="名称"
              name="name"
              rules={[{ required: true, message: '请输入数据项名称!' }]}
            >
              <Input.Search
                autoFocus
                placeholder="请输入数据项名称"
                onSearch={(value) => {
                  Translate.to(value).then((data) => {
                    if (data.trans_result) {
                      const code = data.trans_result.length > 0 ? data.trans_result[0].dst : '';
                      const values = form.getFieldsValue();
                      form.setFieldsValue({ ...values, code });
                    }
                  });
                }}
                autoComplete="new-password"
              />
            </Form.Item>
            <ProFormText
              label="编码"
              name="code"
              placeholder="请输入数据项名称"
              rules={[
                {
                  required: true,
                  message: '请选择数据项类型',
                },
              ]}
            />
            <ProFormSelect
              label="类型"
              name="type"
              placeholder="请选择数据项类型"
              rules={[
                {
                  required: true,
                  message: '请选择数据项类型',
                },
              ]}
              initialValue={ItemTypeOption[0].value}
              options={ItemTypeOption}
            />
          </ModalForm>,
          <FastFormModal
            onSubmit={() => {
              tabRef.current?.reload();
            }}
          />,
        ]}
        columns={columns}
        request={async (params, sort, filter) => {
          let orderValue = 'createdAt';
          let sortValue = 'desc';
          const entries = Object.entries(sort);
          if (entries.length > 0) {
            orderValue = entries[0][0] as string;
            sortValue = entries[0][1] === 'ascend' ? 'asc' : 'desc';
          }
          const query = {
            page: params.current,
            limit: params.pageSize,
            order: orderValue,
            sort: sortValue,
            keyword: params.keyword,
          };

          const result = await itemService.getlist(query, filter);
          return {
            data: result.data.rows,
            success: result.success,
            total: result.data.total,
          };
        }}
      />
    </PageContainer>
  );
};
