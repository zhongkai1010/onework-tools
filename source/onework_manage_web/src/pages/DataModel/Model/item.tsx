/*
 * @Author: 钟凯
 * @Date: 2021-02-05 21:27:44
 * @LastEditTime: 2021-02-26 17:17:54
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\item.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useRef, useState } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumns } from '@ant-design/pro-table';
import EditableProTable from '@ant-design/pro-table';
import * as modelItemService from '@/services/model/modelItem';
import TableDetails from './components/TableDetails';
import AddDataModelModal from './components/AddDataModelModal';
import { EditDataModelModal } from './components/EditDataModelModal';
import { ItemTypeEnum, ModelUseEnum, StatusEnum } from '../common';

export default () => {
  const tabRef = useRef<ActionType>();
  const [currentModal, setCurrentModal] = useState<API.Model.DataModel | undefined>();
  const [visible, setVisible] = useState(false);
  const columns: ProColumns<API.Model.DataModel>[] = [
    {
      title: '数据模型',
      sorter: true,
      dataIndex: 'dataName',
    },
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
      dataIndex: 'itemType',
      valueType: 'select',
      sorter: true,
      initialValue: 'character',
      filters: true,
      valueEnum: ItemTypeEnum,
    },
    // {
    //   title: '子类型',
    //   sorter: true,
    //   dataIndex: 'subType',
    //   valueEnum: ItemTypeEnum,
    // },
    {
      title: '是否为空',
      sorter: true,
      dataIndex: 'isNull',
    },
    {
      title: '是否标识',
      sorter: true,
      dataIndex: 'isUnique',
    },
    // {
    //   title: '对象引用',
    //   sorter: true,
    //   dataIndex: 'objectRef',
    // },
    {
      title: '创建时间',
      dataIndex: 'createdAt',
      editable: false,
      valueType: 'date',
      sorter: true,
    },
    {
      title: '修改时间',
      dataIndex: 'updatedAt',
      valueType: 'date',
      editable: false,
      sorter: true,
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
            setCurrentModal(record);
            setVisible(true);
          }}
        >
          查看详情
        </a>,
      ],
    },
  ];
  return (
    <PageContainer content="构建数据模型集成元素">
      <EditableProTable<API.Model.DataModel>
        rowKey="uid"
        actionRef={tabRef}
        options={{
          density: true,
          
        }}
       
        debounceTime={800}
        editable={{
          type: 'multiple',
          onSave: (_key, row) => {
            return modelItemService.update(row);
          },
          onDelete: (_, row: API.Model.DataModel) => {
            return modelItemService.remove([row.uid]);
          },
        }}
        toolBarRender={() => [
          // <AddDataModelModal
          //   onFinish={async (values) => {
          //     let items = values.items || [];
          //     let behaviors = values.behaviors || [];
          //     items = items.map((t: any) => {
          //       return {
          //         ...t,
          //         isNull: t.isNull === 'true',
          //         isUnique: t.isUnique === 'true',
          //       };
          //     });
          //     behaviors = behaviors.map((t: any) => {
          //       return {
          //         ...t,
          //         inputs: t.inputType ? [{ type: t.inputType, value: t.inputValue }] : undefined,
          //       };
          //     });
          //     const result = await modelService.insert({ ...values, items, behaviors });
          //     if (result.success) {
          //       tabRef.current?.reload();
          //     }
          //     return result.success;
          //   }}
          // />,
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

          const result = await modelItemService.getlist(query, filter);
          return {
            data: result.data.rows,
            success: result.success,
            total: result.data.total,
          };
        }}
      />
      <EditDataModelModal
        visible={visible}
        model={currentModal}
        onClose={() => {
          setVisible(false);
        }}
        onFinish={() => {
          setVisible(false);
          tabRef.current?.reload();
        }}
      />
    </PageContainer>
  );
};
