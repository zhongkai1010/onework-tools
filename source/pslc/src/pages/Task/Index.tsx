import React from 'react';
import { Loading, connect, Dispatch } from 'umi';
import { Row, Col, Button, Form, Input, Table } from 'antd';
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
import TaskCreateModal from '@/pages/Task/components/TaskCreateModal/Index';
import { IndexPageState } from '@/models/index';
import { RcFile } from 'antd/lib/upload';

/**
 * @description
 * @author 钟凯
 * @date 05/11/2020
 * @export
 * @interface IAppProps
 */
export interface IAppProps {
  dispatch: Dispatch;
  task: TaskPageState;
  loading: Loading;
  index: IndexPageState;
}
/**
 * @description
 * @author 钟凯
 * @date 05/11/2020
 * @export
 * @interface IAppState
 */
export interface IAppState {
  page: number;
  pageSize: number;
  createModalvisible: boolean;
  createModalStep: number;
  createModelTask: Task | any;
  createModelFiles: Array<RcFile>;
}

/**
 * @description
 * @author 钟凯
 * @date 05/11/2020
 * @class Index
 * @extends {React.Component<IAppProps, IAppState>}
 */
class Index extends React.Component<IAppProps, IAppState> {
  formRef = React.createRef<FormInstance>();
  constructor(props: IAppProps) {
    super(props);
    this.state = {
      page: 1,
      pageSize: 10,
      createModalvisible: false,
      createModalStep: 0,
      createModelTask: {},
      createModelFiles: [],
    };
  }

  /**
   * @description 初始化页面加载任务列表
   * @author 钟凯
   * @date 05/11/2020
   * @memberof Index
   */
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
  /**
   * @description 填写搜索表单筛选列表
   * @author 钟凯
   * @date 05/11/2020
   * @memberof Index
   */
  inputOnChange = () => {
    if (this.formRef.current) {
      console.log(this.formRef.current.getFieldsValue());
    }
  };
  /**
   * @description 标签切换
   * @author 钟凯
   * @date 05/11/2020
   * @param {*} record
   * @param {*} _selected
   * @param {*} _selectedRows
   * @param {*} _nativeEvent
   * @memberof Index
   */
  tableOnSelect = (record: any, _selected: any, _selectedRows: any, _nativeEvent: any) => {
    const { dispatch } = this.props;

    dispatch({
      type: 'index/enableAnalysisTab',
      payload: record,
    });
  };

  /**
   * @description 列表分页事件
   * @author 钟凯
   * @date 05/11/2020
   * @param {number} page
   * @param {number} [pageSize]
   * @memberof Index
   */
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
  /**
   * @description 新建任务
   * @author 钟凯
   * @date 05/11/2020
   * @memberof Index
   */
  createButtonOnClick = () => {
    this.setState({
      createModalvisible: true,
    });
  };
  public render() {
    /**
     * @description
     * @author 钟凯
     * @date 05/11/2020
     * @param {number} status
     * @return {*}
     */
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

    /** @type {*}  */
    const columns: ColumnsType<Task> = [
      {
        title: '序号',
        render: (_text, _record, index) => `${index + 1}`,
        width: 80,
      },

      {
        title: '创建时间',
        dataIndex: 'createdAt',
        key: 'createdAt',
        width: 160,
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
        key: 'coDriverName',
        dataIndex: 'coDriverName',
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
        key: 'departureDate',
        dataIndex: 'departureDate',
        width: 160,
      },
      {
        title: '任务状态',
        key: 'taskStatus',
        dataIndex: 'taskStatus',
        render: (value: any, _record, _index) => renderStatus(value),
      },
    ];
    const { effects } = this.props.loading;
    const { data, dataTotal } = this.props.task;
    const { createModalvisible, createModalStep, createModelTask, createModelFiles } = this.state;
    return (
      <>
        <TaskCreateModal
          visible={createModalvisible}
          onCloseButton={() => {
            //操作完成
            this.setState({
              createModalvisible: false,
              createModelTask: {},
              createModalStep: 0,
            });
          }}
          files={createModelFiles}
          task={createModelTask}
          onConfirmButton={(e, files) => {
            if (createModalStep == 0) {
              // 调用后端任务新建接口，创建任务，等到任务id
              this.setState({
                createModalStep: createModalStep + 1,
                createModelTask: {},
                createModelFiles: files,
              });
              console.log('onConfirmButton', files);
            }
            if (createModalStep == 1) {
              // 调用后端任务上传文件
              this.setState({
                createModalStep: createModalStep + 1,
              });
            }
            if (createModalStep == 2) {
              //操作完成，清空表单数据，关闭弹框
              this.setState({
                createModalvisible: false,
                createModelTask: {},
                createModalStep: 0,
              });
            }
          }}
          step={createModalStep}
        />
        <Row>
          <Col span={24} className={styles.tools_container}>
            <Button
              size="large"
              icon={<PlusOutlined style={{ color: '#ccc' }} />}
              onClick={this.createButtonOnClick}
            >
              新建任务
            </Button>

            <Button
              style={{ marginRight: '10px' }}
              size="large"
              icon={<BorderOutlined style={{ color: '#AC1818' }} />}
            >
              停止
            </Button>
            <Button
              size="large"
              icon={<CaretRightOutlined style={{ color: 'rgb(127, 209, 84)' }} />}
            >
              开始
            </Button>
            <Button size="large" icon={<HddOutlined style={{ color: 'blue' }} />}>
              查看详情
            </Button>
            <Button size="large" icon={<DownloadOutlined style={{ color: '#35C9BA' }} />}>
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
      </>
    );
  }
}
export default connect(({ index, task, loading }: { index: any; task: any; loading: Loading }) => ({
  loading: loading,
  task: task,
  index: index,
}))(Index);
