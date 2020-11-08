import React from 'react';
import { Loading, connect, Dispatch } from 'umi';
import { Row, Col, Button, Table } from 'antd';
import { TaskPageState } from '@/models/task';
import { TaskStatus } from '@/models/task.d';
import { FormInstance } from 'antd/lib/form';
import styles from './Index.less';
import {
  PlusOutlined,
  BorderOutlined,
  CaretRightOutlined,
  HddOutlined,
  DownloadOutlined,
} from '@ant-design/icons';
import TaskCreateModal from './components/TaskCreateModal/Index';
import { IndexPageState } from '@/models/index';
import TableSearch from './components/TableSearch/Index';
import { Tablecolumns } from './Config';

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
  onSearchChange = (formData: any) => {
    const { dispatch } = this.props;
    const { page, pageSize, order, sort } = this.state;
    dispatch({
      type: 'task/load',
      payload: {
        page: page,
        limit: pageSize,
        order: order,
        sort: sort,
        ...formData,
      },
    });
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
    const { effects } = this.props.loading;
    const { data: listData, dataTotal } = this.props.task;
    const { createModalvisible } = this.state;
    return (
      <>
        <TaskCreateModal
          visible={createModalvisible}
          onClaseModel={() => {
            this.setState({
              createModalvisible: false,
            });
          }}
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
            <TableSearch onSearchChange={this.onSearchChange} />
          </Col>
          <Col span={24} className={styles.table_container}>
            <Table
              rowKey="id"
              columns={Tablecolumns}
              scroll={{ y: '45vh', scrollToFirstRowOnChange: true }}
              loading={effects['task/load']}
              rowSelection={{
                onSelect: this.tableOnSelect,
                type: 'radio',
                getCheckboxProps: (record) => ({
                  disabled: record.status_code != TaskStatus.A,
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
