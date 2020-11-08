import React from 'react';
import { Task, TaskStatus } from '@/models/task.d';
import { ColumnsType } from 'antd/es/table';
import { UserOutlined } from '@ant-design/icons';
import { formatDate } from '@/utils/utils';

/**
 * @description
 * @author 钟凯
 * @date 05/11/2020
 * @param {number} status
 * @return {*}
 */
export const renderStatus = (status: TaskStatus) => {
  switch (status) {
    case TaskStatus.A:
      return <span style={{ color: '#20C5F5' }}>文件上传完成</span>;
    case TaskStatus.B:
      return <span style={{ color: '#000000' }}>文件转换完成</span>;
    case TaskStatus.C:
      return <span style={{ color: '#D82525' }}>排队中</span>;
    case TaskStatus.D:
      return <span style={{ color: '#7FD154' }}>分析中</span>;
    case TaskStatus.E:
      return <span style={{ color: '#7FD154' }}>任务结束</span>;
    case TaskStatus.F:
      return <span style={{ color: '#7FD154' }}>已停止</span>;
    case TaskStatus.G:
      return <span style={{ color: '#7FD154' }}>异常中止</span>;
    default:
      return <span>准备中</span>;
  }
};

export const Tablecolumns: ColumnsType<Task> = [
  {
    title: '创建时间',
    dataIndex: 'createdAt',
    key: 'createdAt',

    render: (value) => formatDate(value),
  },
  {
    title: '机车号',
    dataIndex: 'train_number',
    key: 'train_number',
  },
  {
    title: '车次',
    dataIndex: 'train_id',
    key: 'train_id',
  },
  {
    title: '司机',
    key: 'main_driver_name',
    dataIndex: 'main_driver_name',
    render: (value) => {
      return (
        <div>
          <UserOutlined style={{ color: '#20C5F5' }} />
          <span>{value}</span>
        </div>
      );
    },
  },
  {
    title: '副司机',
    key: 'sub_driver_name',
    dataIndex: 'sub_driver_name',
    render: (value) => {
      return (
        <div>
          <UserOutlined style={{ color: '#7FD154' }} />
          <span>{value}</span>
        </div>
      );
    },
  },
  {
    title: '发车时间',
    key: 'm_time',
    dataIndex: 'm_time',
    width: 160,
    render: (value) => formatDate(value),
  },
  {
    title: '任务状态',
    key: 'status_code',
    dataIndex: 'status_code',
    render: (value: TaskStatus, _record, _index) => renderStatus(value),
  },
];
