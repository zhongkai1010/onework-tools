import React from 'react';
import { Loading, connect, Dispatch } from 'umi';
import { Row, Col, Button, Table, message } from 'antd';
import { DriverPageState } from '@/models/driver';
import { Driver } from '@/models/user.d';
import { FormInstance } from 'antd/lib/form';
import styles from './Index.less';
import { PlusOutlined, FormOutlined, DeleteOutlined } from '@ant-design/icons';
import { TableColumns } from './Config';
import FromModal from './components/FromModal/Index';
import TableSearch from './components/TableSearch/Index';

export interface IAppProps {
  dispatch: Dispatch;
  driver: DriverPageState;
  loading: Loading;
}
export interface IAppState {
  page: number;
  limit: number;
  order: number;
  sort: 'desc';
  createModalvisible: boolean;
  slectDriver?: Driver;
  work_id?: string;
  name?: string;
  user_type?: string;
  work_group?: string;
  teacher_group?: string;
  addOperation: boolean;
}

class Index extends React.Component<IAppProps, IAppState> {
  formRef = React.createRef<FormInstance>();
  constructor(props: IAppProps) {
    super(props);
    this.state = {
      page: 1,
      limit: 10,
      order: 0,
      sort: 'desc',
      createModalvisible: false,
      addOperation: false,
    };
  }
  componentDidMount() {
    const { dispatch } = this.props;
    const { page, limit, order, sort } = this.state;
    dispatch({
      type: 'driver/load',
      payload: {
        page,
        limit,
        order,
        sort,
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
    const { page, limit, order, sort } = this.state;
    this.setState(
      {
        work_id: formData.work_id,
        name: formData.name,
        user_type: formData.user_type,
        work_group: formData.work_group,
        teacher_group: formData.teacher_group,
      },
      () => {
        dispatch({
          type: 'driver/load',
          payload: {
            page: page,
            limit: limit,
            order: order,
            sort: sort,
            ...formData,
          },
        });
      },
    );
  };
  tableOnSelect = (selected: any, _selectedRows: any, _nativeEvent: any) => {
    this.setState({
      slectDriver: selected,
    });
  };
  paginationOnChange = (page: number, pageSize?: number) => {
    const { dispatch } = this.props;
    const { order, sort } = this.state;
    dispatch({
      type: 'driver/load',
      payload: {
        page,
        limit: pageSize,
        order,
        sort,
        work_id: this.state.work_id,
        name: this.state.name,
        user_type: this.state.user_type,
        work_group: this.state.work_group,
        teacher_group: this.state.teacher_group,
      },
    });
  };
  createButtonOnClick = () => {
    this.setState({
      addOperation: true,
      createModalvisible: true,
    });
  };
  updateButtonOnClick = () => {
    const { slectDriver } = this.state;
    if (!slectDriver) {
      message.info('请选择一行数据进行操作。');
    } else {
      this.setState({
        addOperation: false,
        createModalvisible: true,
      });
    }
  };
  deleteButtonOnClick = () => {
    const { slectDriver } = this.state;
    if (!slectDriver) {
      message.info('请选择一行数据进行操作。');
    } else {
      const { dispatch } = this.props;
      dispatch({
        type: 'driver/load',
        payload: {
          page: this.state.page,
          limit: this.state.limit,
          order: this.state.order,
          sort: this.state.sort,
          work_id: this.state.work_id,
          name: this.state.name,
          user_type: this.state.user_type,
          work_group: this.state.work_group,
          teacher_group: this.state.teacher_group,
        },
      });
    }
  };
  public render() {
    const { effects } = this.props.loading;
    const { data, dataTotal } = this.props.driver;
    const { createModalvisible, slectDriver, addOperation } = this.state;
    return (
      <>
        <FromModal
          addOperation={addOperation}
          onConfirm={() => {
            this.setState({
              createModalvisible: false,
            });
            // dispatch({
            //   type: 'driver/add',
            //   payload: { ...fromData, username: fromData.work_id },
            // }).then(() => {
            //   this.setState(
            //     {
            //       createModalvisible: false,
            //     },
            //     () => {
            //       message.info('创建成功');
            //       dispatch({
            //         type: 'driver/load',
            //         payload: {
            //           page: this.state.page,
            //           limit: this.state.limit,
            //           order: this.state.order,
            //           sort: this.state.sort,
            //           work_id: this.state.work_id,
            //           name: this.state.name,
            //           user_type: this.state.user_type,
            //           work_group: this.state.work_group,
            //           teacher_group: this.state.teacher_group,
            //         },
            //       });
            //     },
            //   );
            // });
          }}
          visible={createModalvisible}
          data={slectDriver}
          destroyOnClose={true}
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
              icon={<PlusOutlined style={{ color: '#4391DA' }} />}
              onClick={this.createButtonOnClick}
            >
              添加司机
            </Button>

            <Button
              style={{ marginRight: '10px' }}
              size="large"
              icon={<FormOutlined style={{ color: '#FDD281' }} />}
              onClick={this.updateButtonOnClick}
            >
              修改
            </Button>
            <Button
              size="large"
              icon={<DeleteOutlined style={{ color: '#7667C8' }} />}
              onClick={this.deleteButtonOnClick}
            >
              删除
            </Button>
          </Col>
          <Col span={24} className={styles.search_container}>
            <TableSearch onSearchChange={this.onSearchChange} />
          </Col>
          <Col span={24} className={styles.table_container}>
            <Table
              rowKey="id"
              columns={TableColumns}
              scroll={{ y: '45vh', scrollToFirstRowOnChange: true }}
              loading={effects['driver/load']}
              dataSource={data}
              rowSelection={{
                onSelect: this.tableOnSelect,
                type: 'radio',
              }}
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
export default connect(
  ({ index, driver, loading }: { index: any; driver: any; loading: Loading }) => ({
    loading: loading,
    driver: driver,
    index: index,
  }),
)(Index);
