import { Line } from '@/models/line.d';
import { ColumnsType } from 'antd/es/table';

export const TableColumns: ColumnsType<Line> = [
  {
    title: '线路名称',
    dataIndex: 'name',
    key: 'name',
  },
  {
    title: '起始站',
    dataIndex: 'initial_station',
    key: 'initial_station',
  },
  {
    title: '终点站',
    dataIndex: 'terminal_station',
    key: 'terminal_station',
  },
  {
    title: '全长(km)',
    dataIndex: 'mileage',
    key: 'mileage',
  },
  {
    title: '识别项点数',
    dataIndex: 'pointCount',
    key: 'pointCount',
  },
  {
    title: '修改时间',
    dataIndex: 'update_time',
    key: 'update_time',
  },
];
