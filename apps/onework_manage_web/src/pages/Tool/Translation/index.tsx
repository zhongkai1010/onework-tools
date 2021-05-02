/*
 * @Author: 钟凯
 * @Date: 2021-03-24 09:35:28
 * @LastEditTime: 2021-03-26 09:37:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\Tool\Translation\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import React, { useRef } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';
import { translationGetlist } from '../services';
import { useRequest } from 'umi';

export default () => {
  const tabRef = useRef<ActionType>();
  const translationGetlistOperate = useRequest(translationGetlist, {
    manual: true,
    throwOnError: true,
  });
  const columns: ProColumns<API.Tool.TranslationRecord>[] = [
    {
      title: '文本',
      sorter: true,
      dataIndex: 'text',
    },
    {
      title: '译文',
      sorter: true,
      dataIndex: 'translation',
    },
    {
      title: '文本语言',
      sorter: true,
      dataIndex: 'from',
    },
    {
      title: '译文语言',
      sorter: true,
      dataIndex: 'to',
    },
    {
      title: '创建时间',
      sorter: true,
      valueType: 'dateRange',
      dataIndex: 'createdAt',
    },
  ];
  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <ProTable<API.Tool.TranslationRecord>
        tableStyle={{ paddingBottom: 16 }}
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
        pagination={{
          defaultPageSize: 10,
        }}
      
        debounceTime={800}
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
            page: params.current || 1,
            limit: params.pageSize || 10,
            order: orderValue,
            sort: sortValue,
            keyword: params.keyword,
          };
          const result = await translationGetlistOperate.run(query, filter);
          return {
            data: result.rows,
            success: true,
            total: result.total,
          };
        }}
      />
    </PageContainer>
  );
};
