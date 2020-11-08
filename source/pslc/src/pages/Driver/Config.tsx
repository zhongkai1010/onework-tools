import React from 'react';
import { Driver, DriverType } from '@/models/user.d';
import { ColumnsType } from 'antd/es/table';
import { UserOutlined } from '@ant-design/icons';

/**
 * @description
 * @author 钟凯
 * @date 05/11/2020
 * @param {number} status
 * @return {*}
 */
const renderUserType = (value: DriverType) => {
  switch (value) {
    case DriverType.A:
      return (
        <>
          <UserOutlined style={{ color: '#20C5F5' }} />
          <span>主司机</span>
        </>
      );
    case DriverType.B:
      return (
        <>
          <UserOutlined style={{ color: '#7FD154' }} />
          <span>副司机</span>
        </>
      );
    default:
      return <span>其他</span>;
  }
};

export const TableColumns: ColumnsType<Driver> = [
  {
    title: '工号',
    dataIndex: 'work_id',
    key: 'work_id',
  },
  {
    title: '姓名',
    dataIndex: 'name',
    key: 'name',
  },
  {
    title: '职称',
    dataIndex: 'user_type',
    key: 'user_type',
    render: (value) => renderUserType(value),
  },
  {
    title: '车队',
    dataIndex: 'work_group',
    key: 'work_group',
  },
  {
    title: '指导组',
    dataIndex: 'teacher_group',
    key: 'teacher_group',
  },
];
