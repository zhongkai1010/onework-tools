import React, { useState, useEffect, useReducer } from 'react';
import { useRequest } from 'umi';
import { Row, Col, Button, Table } from 'antd';
import { LineDetails } from './components/LineDetails/Index';
import {
  PlusOutlined,
  BorderOutlined,
  CaretRightOutlined,
  HddOutlined,
  DownloadOutlined,
} from '@ant-design/icons';
import { Line } from '@/models/line.d';
import { TableColumns } from './Config';
import styles from './Index.less';
import * as services from '@/services/line';

interface Props {}

const Index = (props: Props) => {
  const [selectLine, setSelectLine] = useState<Line | null>(null);
  const [pageState, setpageState] = useState({ pgae: 1, limit: 10, total: 0, data: [] });
  const { loading, data, error, run } = useRequest((params = { page: 1, limit: 10 }) =>
    services.lineGetList(params),
  );
  const tableOnSelect = () => {};
  const paginationOnChange = () => {
    console.log('paginationOnChange');
  };

  return (
    <Row>
      <Col span={24} className={styles.tools_container}>
        <Button size="large" icon={<PlusOutlined style={{ color: '#ccc' }} />}>
          新建任务
        </Button>
        <Button
          style={{ marginRight: '10px' }}
          size="large"
          icon={<BorderOutlined style={{ color: '#AC1818' }} />}
        >
          停止
        </Button>
        <Button size="large" icon={<CaretRightOutlined style={{ color: 'rgb(127, 209, 84)' }} />}>
          开始
        </Button>
        <Button size="large" icon={<HddOutlined style={{ color: 'blue' }} />}>
          查看详情
        </Button>
        <Button size="large" icon={<DownloadOutlined style={{ color: '#35C9BA' }} />}>
          下载报告
        </Button>
      </Col>
      <Col span={24} className={styles.table_container}>
        <Table
          rowKey="id"
          columns={TableColumns}
          scroll={{ y: '45vh', scrollToFirstRowOnChange: true }}
          loading={loading}
          rowSelection={{
            onSelect: tableOnSelect,
            type: 'radio',
          }}
          dataSource={[]}
          pagination={{
            showSizeChanger: true,
            showQuickJumper: true,
            total: 0,
            showTotal: (total) => `共${total}条`,
            onChange: paginationOnChange,
          }}
        />
      </Col>
    </Row>
  );
};

export default Index;
