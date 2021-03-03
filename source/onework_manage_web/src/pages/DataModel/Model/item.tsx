/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-03-03 16:47:34
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\model\item.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useRef, useState } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumns } from '@ant-design/pro-table';
import EditableProTable from '@ant-design/pro-table';
import * as modelItemService from '@/pages/DataModel/services/modelItem';
import { BoolEnum, ItemTypeEnum } from '../common';
import { Button } from 'antd';
import ModelSelect from '../components/modelSelect';
import ModelItemTypeButton from './components/ModelItemTypeButton';
import * as modelItemServices from '@/pages/DataModel/services/modelItem';

export default () => {
  const tabRef = useRef<ActionType>();
  const [searchModelValue, setSearchModelValue] = useState();

  const columns: ProColumns<API.Model.DataModelItem>[] = [
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
      title: '数据模型uid',
      sorter: true,
      dataIndex: 'dataUid',
      hideInTable: true,
    },

    {
      title: '是否标识',
      dataIndex: 'isUnique',
      filters: true,
      valueType: 'select',
      valueEnum: BoolEnum,
      width: 120,
    },
    {
      title: '是否为空',
      dataIndex: 'isNull',
      filters: true,
      valueType: 'select',
      valueEnum: BoolEnum,
      width: 120,
    },
    {
      title: '默认值',
      dataIndex: 'defaultValue',
      width: '10%',
    },
    {
      title: '类型',
      dataIndex: 'itemType',
      valueType: 'select',
      initialValue: 'character',
      filters: true,
      valueEnum: ItemTypeEnum,
      editable: false,
      render: (text, record) => {
        return (
          <ModelItemTypeButton
            data={{
              ...record,
              isUnique: record.isUnique === 'true',
              isNull: record.isNull === 'true',
            }}
            modalFormProps={{
              onFinish: async (values) => {
                const result = await modelItemServices.update({
                  ...record,
                  ...values,
                  isNull: record.isNull === 'true',
                  isUnique: record.isUnique === 'true',
                });
                if (result.success) {
                  tabRef.current?.reload();
                }
                return result.success;
              },
            }}
          />
        );
      },
      width: '10%',
    },
    {
      title: '数据模型',
      dataIndex: 'dataUid',
      render: (text, record) => (
        <Button type="link" onClick={() => {}}>
          {record.dataName}
        </Button>
      ),
      width: '10%',
      editable: false,
    },

    {
      title: '创建时间',
      dataIndex: 'createdAt',
      editable: false,
      valueType: 'date',
      sorter: true,
      width: '10%',
    },
    {
      title: '修改时间',
      dataIndex: 'updatedAt',
      valueType: 'date',
      editable: false,
      sorter: true,
      width: '10%',
    },
    {
      title: '操作',
      valueType: 'option',
      width: '10%',
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
      <EditableProTable<API.Model.DataModelItem>
        rowKey="uid"
        actionRef={tabRef}
        postData={(data: API.Model.DataModelItem[]) => {
          return data.map((t) => {
            return {
              ...t,
              isNull: (t.isNull ?? false).toString(),
              isUnique: (t.isUnique ?? false).toString(),
            };
          });
        }}
        options={{
          density: true,
          search: (
            <ModelSelect
              showSearch
              onChange={(value) => {
                setSearchModelValue(value);
                tabRef.current?.reload();
              }}
              showArrow
              style={{ width: '220px' }}
              allowClear
              placeholder="请输入数据模型"
              autoFocus
            />
          ),
        }}
        debounceTime={800}
        editable={{
          type: 'multiple',
          onSave: (_key, row) => {
            const updateData = {
              ...row,
              objectRef: row.objectRef === '' || !row.objectRef ? null : row.objectRef,
              isNull: row.isNull === 'true',
              isUnique: row.isUnique === 'true',
            };
            return modelItemService.update(updateData);
          },
          onDelete: (_, row: API.Model.DataModelItem) => {
            return modelItemService.remove([row.uid]);
          },
        }}
        search={false}
        columns={columns}
        bordered
        pagination={{ pageSize: 10 }}
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
          const newFilter = { ...filter, dataUid: searchModelValue };
          const result = await modelItemService.getlist(query, newFilter);
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
