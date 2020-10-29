import React from 'react';
import { Loading, connect, Dispatch } from 'umi';
import { Row, Col, Button, Form, Input, Table } from 'antd';
import { TaskPageState } from '@/models/task';
import { Task } from '../../models/task';
import { ColumnsType } from 'antd/es/table';
import debounce from 'debounce';
import { FormInstance } from 'antd/lib/form';

export interface IAppProps {
  dispatch: Dispatch;
  task: TaskPageState;
  loading: Loading;
}

class Index extends React.Component<IAppProps,IAppState> {
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
      <Row style={{ height: '100%', display: 'block' }}>
        <Col span={24} style={{ marginBottom: '10px', height: '5vh' }}>
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
        <Col span={24} style={{ marginBottom: '10px', height: '5vh' }}>
          <div
            style={{ backgroundColor: 'rgb(243, 243, 241)', padding: '10px', borderRadius: '5px' }}
          >
            <Form layout="inline" ref={this.formRef} name="control-ref">
              <Form.Item label="创建时间" name="createdAt">
                <Input
                  style={{ width: '8vw', borderRadius: '5px' }}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="机车号" name="locomotiveNo">
                <Input
                  style={{ width: '8vw', borderRadius: '5px' }}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="车次" name="trainNo">
                <Input
                  style={{ width: '8vw', borderRadius: '5px' }}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="司机" name="driverName">
                <Input
                  style={{ width: '8vw', borderRadius: '5px' }}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="发车时间" name="departureDate">
                <Input
                  style={{ width: '8vw', borderRadius: '5px' }}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
              <Form.Item label="任务状态" name="taskStatus">
                <Input
                  style={{ width: '8vw', borderRadius: '5px' }}
                  onChange={debounce(this.inputOnChange, 1000)}
                />
              </Form.Item>
            </Form>
          </div>
        </Col>
        <Col span={24} style={{ height: '60vh' }}>
          <Table
            style={{ height: '100%' }}
            rowKey="id"
            columns={columns}
            scroll={{ y: 400 }}
            loading={effects['task/load']}
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
export default connect(({ task, loading }: { task: any; loading: Loading }) => ({
  loading: loading,
  task: task,
}))(Index);
