import React from 'react';
import { Loading, connect, Dispatch } from 'umi';
import { Row, Col, Button, Form, Input, Table } from 'antd';
import { TaskPageState } from '@/models/task';
import { Task } from '../../models/task';
import { ColumnsType } from 'antd/es/table';
import { FormInstance } from 'antd/lib/form';
import debounce from 'debounce';
import styles from '@/pages/Task/Index.less';

export interface IAppProps {
  dispatch: Dispatch;
  task: TaskPageState;
  loading: Loading;
}
export interface IAppState {
  page: number;
  pageSize: number;
}

class Index extends React.Component<IAppProps, IAppState> {
  formRef = React.createRef<FormInstance>();
  constructor(props: IAppProps) {
    super(props);
    this.state = {
      page: 1,
      pageSize: 10,
    };
  }
  componentDidMount() {
    const { dispatch } = this.props;
    dispatch({
      type: 'task/load',
      payload: {
        page: 1,
        pageSize: 10,
      },
    });
  }
  componentWillReceiveProps(nextProps: IAppProps) {}

  inputOnChange = () => {
    if (this.formRef.current) {
      console.log(this.formRef.current.getFieldsValue());
    }
  };
  tableOnSelect = (record: any, selected: any, selectedRows: any, nativeEvent: any) => {
    const { dispatch } = this.props;
    console.log('tableOnSelect',record)
    dispatch({
      type: 'index/enableAnalysisTab',
      payload: record,
    });
  };
  public render() {
    const columns: ColumnsType<Task> = [
      {
        title: '序号',
        render: (text, record, index) => `${index + 1}`,
      },

      {
        title: '创建时间',
        dataIndex: 'createdAt',
        key: 'createdAt',
      },
      {
        title: '机车号',
        dataIndex: 'locomotiveNo',
        key: 'locomotiveNo',
      },
      {
        title: '车次',
        dataIndex: 'trainNo',
        key: 'trainNo',
      },
      {
        title: '司机',
        key: 'driverName',
        dataIndex: 'driverName',
      },
      {
        title: '副司机',
        key: 'coDriverName',
        dataIndex: 'coDriverName',
      },
      {
        title: '发车时间',
        key: 'departureDate',
        dataIndex: 'departureDate',
      },
      {
        title: '任务状态',
        key: 'taskStatus',
        dataIndex: 'taskStatus',
      },
    ];
    // const { page, pageSize } = this.state;
    const { effects } = this.props.loading;
    const { data, dataTotal } = this.props.task;
    const paginationOnChange = (page: number, pageSize?: number) => {
      const { dispatch } = this.props;
      dispatch({
        type: 'task/load',
        payload: {
          page,
          pageSize,
        },
      });
    };

    return (
      <Row className={styles.container}>
        <Col span={24} className={styles.tools_container}>
          <Button type="primary" style={{ marginRight: '10px' }} size="large">
            新建任务
          </Button>
          <Button type="primary" style={{ marginRight: '10px' }} size="large">
            停止
          </Button>
          <Button type="primary" style={{ marginRight: '10px' }} size="large">
            开始
          </Button>
          <Button type="primary" style={{ marginRight: '10px' }} size="large">
            查看详情
          </Button>
          <Button type="primary" style={{ marginRight: '10px' }} size="large">
            下载报告
          </Button>
        </Col>
        <Col span={24} className={styles.search_container}>
          <div className={styles.from_container}>
            <Form layout="inline" ref={this.formRef} name="control-ref">
              <Form.Item label="创建时间" name="createdAt">
                <Input
                  className={styles.from_input}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="机车号" name="locomotiveNo">
                <Input
                  className={styles.from_input}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="车次" name="trainNo">
                <Input
                  className={styles.from_input}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="司机" name="driverName">
                <Input
                  className={styles.from_input}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="发车时间" name="departureDate">
                <Input
                  className={styles.from_input}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="任务状态" name="taskStatus">
                <Input
                  className={styles.from_input}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
            </Form>
          </div>
        </Col>
        <Col span={24} className={styles.table_container}>
          <Table
            style={{ height: '100%' }}
            rowKey="id"
            columns={columns}
            scroll={{ y: 400 }}
            loading={effects['task/load']}
            rowSelection={{ onSelect: this.tableOnSelect, type: 'radio' }}
            dataSource={data}
            pagination={{
              showSizeChanger: true,
              showQuickJumper: true,
              total: dataTotal,
              showTotal: (total) => `共${total}条`,
              onChange: paginationOnChange,
            }}
          />
        </Col>
      </Row>
    );
  }
}
export default connect(({ index, task, loading }: { index: any; task: any; loading: Loading }) => ({
  loading: loading,
  task: task,
  index: index,
}))(Index);
