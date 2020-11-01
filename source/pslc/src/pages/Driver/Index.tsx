import React from 'react';
import { Loading, connect, Dispatch } from 'umi';
import { Row, Col, Button, Form, Input, Table, Modal } from 'antd';
import { TaskPageState } from '@/models/task';
import { Task } from '../../models/task';
import { ColumnsType } from 'antd/es/table';
import { FormInstance } from 'antd/lib/form';
import styles from './Index.less';
import debounce from 'debounce';
import {
  PlusOutlined,
  BorderOutlined,
  CaretRightOutlined,
  HddOutlined,
  DownloadOutlined,
  UserOutlined,
} from '@ant-design/icons';

export interface IAppProps {
  dispatch: Dispatch;
  task: TaskPageState;
  loading: Loading;
}
export interface IAppState {
  page: number;
  pageSize: number;
  createModalvisible: boolean;
}

class Index extends React.Component<IAppProps, IAppState> {
  formRef = React.createRef<FormInstance>();
  constructor(props: IAppProps) {
    super(props);
    this.state = {
      page: 1,
      pageSize: 10,
      createModalvisible: false,
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
  componentWillReceiveProps(_nextProps: IAppProps) {}

  inputOnChange = () => {
    if (this.formRef.current) {
      console.log(this.formRef.current.getFieldsValue());
    }
  };
  tableOnSelect = (record: any, _selected: any, _selectedRows: any, _nativeEvent: any) => {
    const { dispatch } = this.props;

    dispatch({
      type: 'index/enableAnalysisTab',
      payload: record,
    });
  };
  paginationOnChange = (page: number, pageSize?: number) => {
    const { dispatch } = this.props;
    dispatch({
      type: 'task/load',
      payload: {
        page,
        pageSize,
      },
    });
  };
  createButtonOnClick = () => {
    this.setState({
      createModalvisible: true,
    });
  };
  handleOk = (e: any) => {
    this.setState({
      createModalvisible: false,
    });
  };

  handleCancel = (e: any) => {
    this.setState({
      createModalvisible: false,
    });
  };
  public render() {
    const renderStatus = (status: number) => {
      switch (status) {
        case 1:
          return <span style={{ color: '#20C5F5' }}>排队中</span>;
        case 2:
          return <span style={{ color: '#000000' }}>分析中...</span>;
        case 3:
          return <span style={{ color: '#D82525' }}>已停止</span>;
        case 4:
          return <span style={{ color: '#7FD154' }}>已完成</span>;
        default:
          return <span></span>;
      }
    };
    const columns: ColumnsType<Task> = [
      {
        title: '序号',
        render: (_text, _record, index) => `${index + 1}`,
        width: 80,
      },

      {
        title: '工号',
        dataIndex: 'createdAt',
        key: 'createdAt',
      },
      {
        title: '姓名',
        dataIndex: 'locomotiveNo',
        key: 'locomotiveNo',
      },
      {
        title: '职称',
        dataIndex: 'trainNo',
        key: 'trainNo',
      },
    ];
    const { effects } = this.props.loading;
    const { data, dataTotal } = this.props.task;
    const { createModalvisible } = this.state;

    return (
      <div>
        <Modal
          title="Basic Modal"
          visible={createModalvisible}
          onOk={this.handleOk}
          onCancel={this.handleCancel}
          maskClosable={false}
        >
          <p>Some contents...</p>
          <p>Some contents...</p>
          <p>Some contents...</p>
        </Modal>
        <Row>
          <Col span={24} className={styles.tools_container}>
            <Button
              size="large"
              icon={<PlusOutlined style={{ color: '#ccc' }} />}
              onClick={this.createButtonOnClick}
            >
              添加司机
            </Button>

            <Button
              style={{ marginRight: '10px' }}
              size="large"
              icon={<BorderOutlined style={{ color: '#AC1818' }} />}
            >
              修改
            </Button>
            <Button
              size="large"
              icon={<CaretRightOutlined style={{ color: 'rgb(127, 209, 84)' }} />}
            >
              删除
            </Button>
          </Col>
          <Col span={24} className={styles.search_container}>
            <div className={styles.from_container}>
              <Form layout="inline" ref={this.formRef} name="control-ref">
                <Form.Item label="工号" name="createdAt">
                  <Input
                    className={styles.from_input}
                    onChange={debounce(this.inputOnChange, 1000)}
                  />
                </Form.Item>
                <Form.Item label="修改" name="locomotiveNo">
                  <Input
                    className={styles.from_input}
                    onChange={debounce(this.inputOnChange, 1000)}
                  />
                </Form.Item>
                <Form.Item label="删除" name="trainNo">
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
              rowKey="id"
              columns={columns}
              scroll={{ y: '45vh', scrollToFirstRowOnChange: true }}
              loading={effects['task/load']}
              rowSelection={{
                onSelect: this.tableOnSelect,
                type: 'radio',
                getCheckboxProps: (record) => ({
                  disabled: record.taskStatus === 2,
                }),
              }}
              dataSource={data}
              pagination={{
                showSizeChanger: true,
                showQuickJumper: true,
                total: dataTotal,
                showTotal: (total) => `共${total}条`,
                onChange: this.paginationOnChange,
              }}
            />
          </Col>
        </Row>
      </div>
    );
  }
}
export default connect(({ index, task, loading }: { index: any; task: any; loading: Loading }) => ({
  loading: loading,
  task: task,
  index: index,
}))(Index);
