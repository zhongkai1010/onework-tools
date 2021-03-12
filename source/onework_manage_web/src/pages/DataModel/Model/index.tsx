/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-03-12 10:06:25
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\model\index.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useRef } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumns } from '@ant-design/pro-table';
import EditableProTable from '@ant-design/pro-table';
import * as modelService from '@/pages/DataModel/services/dataModel';
import ModelTableDetails from './components/ModelTableDetails';
import AddDataModelModal from './components/AddDataModelModal';
import { ModelUseEnum, StatusEnum } from '../common';
import { EditDataModelModal } from './components/EditDataModelModal';

export default () => {
  const tabRef = useRef<ActionType>();
  const columns: ProColumns<API.Model.DataModel>[] = [
    {
      title: '名称',
      sorter: true,
      dataIndex: 'name',
      width: 150,
    },
    {
      title: '编码',
      sorter: true,
      dataIndex: 'code',
      width: 150,
    },
    {
      title: '用途',
      dataIndex: 'use',
      valueType: 'select',
      sorter: true,
      initialValue: 'clsss',
      filters: true,
      width: 120,
      valueEnum: ModelUseEnum,
    },
    {
      title: '状态',
      dataIndex: 'status',
      valueType: 'select',
      filters: true,
      valueEnum: StatusEnum,
      width: 100,
    },
    {
      title: '描述',
      dataIndex: 'description',
      editable: false,
      ellipsis: true,
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
        <EditDataModelModal
          key={`${record.uid}_EditDataModelModal`}
          data={record}
          uid={record.uid}
          modalFormProps={{
            onFinish: async (values) => {
              if (Object.keys(values).length > 0) {
                const dataModel = { ...record, ...values };
                const result = await modelService.update(dataModel);
                if (result.success) {
                  tabRef.current?.reload();
                }
                return result.success;
              }
              return Promise.resolve(true);

              // if (isEditState) {
              //   const values = await form.validateFields();

              //   const dataModel = { ...props.data, ...values };
              //   const result = await modelServices.update(dataModel);
              //   if (result.success) {
              //     setIsEditState(false);
              //     props.onSuccessFinish();
              //   }
              //   return result.success;
              // }
            },
          }}
        />,
      ],
    },
  ];
  return (
    <PageContainer content="构建数据模型集成元素">
      <EditableProTable<API.Model.DataModel>
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
        expandable={{
          expandedRowRender: (record) => <ModelTableDetails data={record} />,
        }}
        search={false}
        debounceTime={800}
        editable={{
          type: 'multiple',
          onSave: (_key, row) => {
            return modelService.update(row);
          },
          onDelete: (_, row: API.Model.DataModel) => {
            return modelService.remove([row.uid]);
          },
        }}
        toolBarRender={() => [
          <AddDataModelModal
            onFinish={async (values) => {
              const items = values.items || [];
              let behaviors = values.behaviors || [];
              behaviors = behaviors.map((t: any) => {
                return {
                  ...t,
                  inputs: t.inputType ? [{ type: t.inputType, value: t.inputValue }] : undefined,
                };
              });
              const result = await modelService.insert({ ...values, items, behaviors });
              if (result.success) {
                tabRef.current?.reload();
              }
              return result.success;
            }}
          />,
        ]}
        columns={columns}
        request={async (params, sort = {}, filter) => {
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

          const result = await modelService.getlist(query, filter);
          return {
            data: result.data.rows,
            success: result.success,
            total: result.data.count,
          };
        }}
      />
    </PageContainer>
  );
};
