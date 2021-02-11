/* eslint-disable no-console */
/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-02-11 17:50:48
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Item\index.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useState } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ProColumns } from '@ant-design/pro-table';
import EditableProTable from '@ant-design/pro-table';
import type { Item } from '@/types/models/model.d';
import { Button, Form } from 'antd';
import { Translate } from '@/utils/translate';
import debounce from 'debounce';
import { ModalForm, ProFormText, ProFormSelect } from '@ant-design/pro-form';
import { getItemList, saveItem } from '@/pages/DataModel/Item/service';
import { useRequest } from 'umi';

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
  const [form] = Form.useForm();
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
  const [nameValue, setNameValue] = useState('');
  const saveItemOperate = useRequest(saveItem, { manual: true });
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
        debounceTime={800}
        editable={{
          onSave: (key, row) => {
            // console.log('row', row);
            return new Promise((reslove) => {
              reslove('');
            });
          },
          onDelete: () => {
            return new Promise((reslove) => {
              reslove('');
            });
          },
        }}
        toolBarRender={() => [
          <ModalForm
            title="新建数据项"
            layout="horizontal"
            form={form}
            onFinish={async (values) => {
              const data = { ...values, name: nameValue };
              saveItemOperate.run(data).then(() => {
                return true;
              });
            }}
            trigger={<Button type="primary">新建</Button>}
          >
            <ProFormText
              label="名称"
              name="name"
              fieldProps={{
                onChange: debounce((e: any) => {
                  const { value } = e.target;
                  const temp = (value as string).trimEnd();
                  let code = '';
                  if (temp.length > 0) {
                    setNameValue(value);
                    Translate.to(value).then((data: any) => {
                      code = data.trans_result.length > 0 ? data.trans_result[0].dst : '';
                      const values = form.getFieldsValue();
                      form.setFieldsValue({ ...values, code });
                    });
                  }
                }, 500),
              }}
            />
            <ProFormText label="编码" name="code" />
            <ProFormSelect
              label="类型"
              name="type"
              options={[
                {
                  value: 'character',
                  label: '字符串',
                },
                {
                  value: 'integer',
                  label: '整型',
                },
                {
                  value: 'digital',
                  label: '数字',
                },
                {
                  value: 'boolean',
                  label: '布尔',
                },
                {
                  value: 'enumerate',
                  label: '枚举',
                },
                {
                  value: 'date',
                  label: '日期',
                },
                {
                  value: 'datetime',
                  label: '日期时间',
                },
              ]}
            />
          </ModalForm>,
        ]}
        columns={columns}
        request={async (params, sort, filter) => {
          const where = {
            page: params.current,
            limit: params.pageSize,
            order: 'createdAt',
            sort: 'desc',
            keyword: params.keyword,
            filter,
          };
          return getItemList(where);
        }}
      />
    </PageContainer>
  );
};
