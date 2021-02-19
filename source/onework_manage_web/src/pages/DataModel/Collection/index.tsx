/* eslint-disable no-console */
/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-02-19 10:06:35
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Collection\index.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useRef, useState } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumns } from '@ant-design/pro-table';
import EditableProTable from '@ant-design/pro-table';
import * as collectionService from '@/services/model/collection';
import AddCollectionModal from './components/AddCollectionModal';
import EditCollectionModal from './components/EditCollectionModal';

export default () => {
  const tabRef = useRef<ActionType>();
  const [currentCollection, setCurrentCollection] = useState<API.Model.Collection | undefined>();
  const [visible, setVisible] = useState(false);
  const columns: ProColumns<API.Model.Collection>[] = [
    {
      title: '编码',
      sorter: true,
      dataIndex: 'code',
      width: 220,
    },
    {
      title: '名称',
      sorter: true,
      dataIndex: 'name',
      width: 220,
    },
    // {
    //   title: '数据项',
    //   sorter: true,
    //   editable: false,
    //   render: (_text, record: API.Model.Collection) => {
    //     return record.items.map((t) => (
    //       <span key={`${t.uid}_name`}>
    //         {t.name}
    //         <br />
    //       </span>
    //     ));
    //   },
    //   dataIndex: 'items',
    //   width: 220,
    // },
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
        <a
          key="show"
          onClick={() => {
            setCurrentCollection(record);
            setVisible(true);
          }}
        >
          查看详情
        </a>,
      ],
    },
  ];
  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <EditableProTable<API.Model.Collection>
        rowKey="uid"
        actionRef={tabRef}
        options={{
          density: true,
          search: {
            allowClear: true,
            enterButton: true,
          },
        }}
        pagination={{
          defaultPageSize:10
        }}
        search={false}
        debounceTime={800}
        editable={{
          type: 'multiple',
          onSave: (_key, row) => {
            return collectionService.update({ ...row, items: row.items.map((t) => t.uid) });
          },
          onDelete: (_, row: API.Model.Collection) => {
            return collectionService.remove([row.uid]);
          },
        }}
        toolBarRender={() => [
          <AddCollectionModal
            onFinish={async (values) => {
              const result = await collectionService.insert(values);
              if (result.success) {
                tabRef.current?.reload();
              }
              return result.success;
            }}
          />,
        ]}
        columns={columns}
        request={async (params, sort, filter) => {
          let orderValue = 'id';
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
          const result = await collectionService.getlist(query, filter);
          return {
            data: result.data.rows,
            success: result.success,
            total: result.data.total,
          };
        }}
      />
      <EditCollectionModal
        visible={visible}
        collection={currentCollection}
        onClose={() => {
          setVisible(false);
        }}
        onFinish={() => {
          tabRef.current?.reload();
        }}
      />
    </PageContainer>
  );
};
