/*
 * @Author: 钟凯
 * @Date: 2021-03-14 10:10:17
 * @LastEditTime: 2021-03-15 17:59:25
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

interface Props {
  table: API.DataBase.Table;
}

const DbColumnList = (props: Props) => {
  const { loading, run, data } = useRequest(schemeServices.getTableColumns, {
    manual: true,
  });
  const columns: ProColumns<API.DataBase.Column>[] = [
    {
      title: '名称',
      sorter: true,
      dataIndex: 'name',
      width: 220,
    },
    {
      title: '编码',
      sorter: true,
      dataIndex: 'code',
      width: 220,
    },
  ];
  useEffect(() => {
    run({ uid: props.table.uid });
  }, [props.table]);
  return (
    <ProTable<API.DataBase.Column>
      pagination={false}
      search={false}
      loading={loading}
      dataSource={data}
      columns={columns}
    />
  );
};

export default DbColumnList;
