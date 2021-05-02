/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:10:17
 * @LastEditTime: 2021-03-19 10:16:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\DbColumnList.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import React, { useEffect } from 'react';
import * as schemeServices from '../services/scheme';
import { useRequest } from 'umi';
import type { ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';
import type TreeHandle from '../treeHandle';
import type { SchemeNode } from '../treeHandle';

interface Props {
  node: SchemeNode;
  treeHandle: TreeHandle;
}

const DbColumnList = (props: Props) => {
  const { loading, run, data } = useRequest(schemeServices.getTableColumns, {
    manual: true,
  });
  const columns: ProColumns<API.DataBase.Column>[] = [
    {
      title: '名称',
      dataIndex: 'name',
    },
    {
      title: '编码',
      dataIndex: 'code',
    },
    {
      title: '类型',
      dataIndex: 'type',
    },
    {
      title: '默认值',
      dataIndex: 'defaultValue',
    },
    {
      title: '是否为空',
      dataIndex: 'isNull',
    },
    {
      title: '是否主键',
      dataIndex: 'isUnique',
    },
    {
      title: '长度',
      dataIndex: 'length',
    },
    {
      title: '精度',
      dataIndex: 'precision',
    },
   
  ];
  useEffect(() => {
    run({ uid: props.node.source.table?.uid });
  }, [props.node]);
  return (
    <ProTable<API.DataBase.Column>
      rowKey="uid"
      pagination={false}
      search={false}
      loading={loading}
      dataSource={data}
      columns={columns}
    />
  );
};

export default DbColumnList;
