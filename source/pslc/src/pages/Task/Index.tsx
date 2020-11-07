import React from 'react';
import { Loading, connect, Dispatch, request } from 'umi';
import { Row, Col, Button, Form, Input, Table, DatePicker, Select } from 'antd';
import { TaskPageState } from '@/models/task';
import { Task, TaskStatus } from '@/models/task.d';
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
import { formatDate } from '@/utils/utils';

const { RangePicker } = DatePicker;
const { Option } = Select;

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
  order: 0;
  sort: string;
  createModalvisible: boolean;
  createModalStep: number;
  createModelTask: Task | any;
  createModelFiles: Array<RcFile>;
  createConfirmLoading: boolean;
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
      order: 0,
      sort: 'desc',
      createModalvisible: false,
      createConfirmLoading: false,
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
    const { page, pageSize, order, sort } = this.state;
    dispatch({
      type: 'task/load',
      payload: {
        page: page,
        limit: pageSize,
        order: order,
        sort: sort,
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
    const { dispatch } = this.props;
    const { page, pageSize, order, sort } = this.state;
    if (this.formRef.current) {
      let query: any = {};
      const data = this.formRef.current.getFieldsValue();
      console.log(data);
      if (data.createdAt) {
        query.startCreateTime = `${data.createdAt[0].format('YYYY-MM-DD')} 00:00:00`;
        query.endCreateTime = `${data.createdAt[1].format('YYYY-MM-DD')} 23:59:59`;
      }
      if (data.locomotiveNo && data.locomotiveNo.length > 0) {
        query.train_number = data.locomotiveNo;
      }
      if (data.trainNo && data.trainNo.length > 0) {
        query.train_id = data.trainNo;
      }
      if (data.driverName && data.driverName.length > 0) {
        query.driver_name = data.driverName;
      }
      if (data.departureDate) {
        query.startMtime = `${data.departureDate[0].format('YYYY-MM-DD')} 00:00:00`;
        query.endMtime = `${data.departureDate[1].format('YYYY-MM-DD')} 23:59:59`;
      }
      if (data.taskStatus != undefined) {
        query.status_code = data.taskStatus;
      }
      console.log(query);
      dispatch({
        type: 'task/load',
        payload: {
          page: page,
          limit: pageSize,
          order: order,
          sort: sort,
          ...query,
        },
      });
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
    this.setState(
      {
        page,
        pageSize: pageSize || 10,
      },
      () => {
        dispatch({
          type: 'task/load',
          payload: {
            page,
            limit: pageSize,
            order: 0,
            sort: 'desc',
          },
        });
      },
    );
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
    const renderStatus = (status: TaskStatus) => {
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
    /** @type {*}  */
    const columns: ColumnsType<Task> = [
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
    const { effects } = this.props.loading;
    const { data: listData, dataTotal } = this.props.task;
    const { createModalvisible, createModalStep, createModelTask, createModelFiles } = this.state;

    return (
      <>
        <TaskCreateModal
          visible={createModalvisible}
          onOneStep={(task, files) => {
            this.setState({
              createModelFiles: files,
              createModalStep: 1,
              createModelTask: task,
            });

            const formData = new FormData();
            files.forEach((file) => {
              formData.append('files[]', file);
            });
            request('/api/v1/task/fileupload', {
              method: 'post',
              headers: {
              
                token:
                  'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjEsImlhdCI6MTYwNDc0MTAzNiwiZXhwIjoxNjA2NDY5MDM2fQ.dL9xvrzACrJC_sXzgSSjL70QcV-ERVqddkhxUFFwS_w',
              },
              params: { id: task.id, total: files.length },
              requestType: 'form',
              responseType: 'json',
              data: formData,
            }).then((value) => {
              console.log(value);
            });
          }}
          onClaseModel={() => {
            this.setState({
              createModalvisible: false,
            });
          }}
          files={createModelFiles}
          task={createModelTask}
          onTwoStep={() => {}}
          onThreeStep={() => {}}
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
                  <RangePicker
                    onChange={debounce(this.inputOnChange, 1000)}
                    style={{ width: '220px' }}
                    allowClear={true}
                  />
                  {/* <Input
                    className={styles.from_input}
                    onChange={debounce(this.inputOnChange, 1000)}
                  /> */}
                </Form.Item>
                <Form.Item label="机车号" name="locomotiveNo">
                  <Input
                    className={styles.from_input}
                    style={{ width: '100px' }}
                    allowClear={true}
                    onChange={debounce(this.inputOnChange, 1000)}
                  />
                </Form.Item>
                <Form.Item label="车次" name="trainNo">
                  <Input
                    className={styles.from_input}
                    allowClear={true}
                    style={{ width: '100px' }}
                    onChange={debounce(this.inputOnChange, 1000)}
                  />
                </Form.Item>
                <Form.Item label="司机" name="driverName">
                  <Input
                    className={styles.from_input}
                    style={{ width: '100px' }}
                    allowClear={true}
                    onChange={debounce(this.inputOnChange, 1000)}
                  />
                </Form.Item>
                <Form.Item label="发车时间" name="departureDate">
                  <RangePicker
                    allowClear={true}
                    onChange={debounce(this.inputOnChange, 1000)}
                    style={{ width: '220px' }}
                  />
                </Form.Item>
                <Form.Item label="任务状态" name="taskStatus">
                  <Select
                    onChange={debounce(this.inputOnChange, 1000)}
                    style={{ width: '120px' }}
                    allowClear={true}
                  >
                    <Option value={TaskStatus.A}>文件上传完成</Option>
                    <Option value={TaskStatus.B}>文件转换完成</Option>
                    <Option value={TaskStatus.C}>排队中</Option>
                    <Option value={TaskStatus.D}>分析中</Option>
                    <Option value={TaskStatus.E}>任务结束</Option>
                    <Option value={TaskStatus.F}>已停止</Option>
                    <Option value={TaskStatus.G}>异常中止</Option>
                  </Select>
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
                  disabled: record.status_code == TaskStatus.A,
                }),
              }}
              dataSource={listData}
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
