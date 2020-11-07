/*
 * @Author: 钟凯
 * @Date: 2020-10-31 08:32:34
 * @Last Modified by: 钟凯
 * @Last Modified time: 2020-10-31 08:55:37
 */
import * as React from 'react';
import { Row, Col, Descriptions, Progress, Button, Table } from 'antd';
import { Loading, connect, Dispatch } from 'umi';
import { IndexPageState } from '@/models/index';
import styles from './Index.less';
import { BorderOutlined, CaretRightOutlined, DownloadOutlined } from '@ant-design/icons';
const io = require('socket.io-client');

export interface IAppProps {
  dispatch: Dispatch;
  index: IndexPageState;
}
export interface IAppState {
  imgState: boolean; //图片状态
  analysisTime: string;
}

class Index extends React.Component<IAppProps, IAppState> {
  constructor(props: IAppProps) {
    super(props);
    this.state = {
      imgState: false,
      analysisTime: '00:00',
    };
  }
  componentDidMount() {
    const { task } = this.props.index;
    console.log('componentDidMount', task);
    let socket = io('http://127.0.0.1:7001', {
      query: {
        taskId: `${task.id}_results`,
        userId: `client_${Math.random()}`,
      },
      //path:'/',
      transports: ['websocket'],
    });
    const log = console.log;
    // 接收在线用户信息
    socket.on('online', (msg:any) => {
      log('#online,', msg);
    });

    // 系统事件
    socket.on('disconnect', (msg:any) => {
      log('#disconnect', msg);
    });

    socket.on('disconnecting', () => {
      log('#disconnecting');
    });

    socket.on('error', () => {
      log('#error');
    });
  }
  imgOnClick = () => {
    const { imgState } = this.state;
    this.setState({
      imgState: !imgState,
    });
  };
  public render() {
    const { task } = this.props.index;
    const { imgState, analysisTime } = this.state;
    const columns = [
      {
        title: '时间',
        dataIndex: 'name',
        key: 'name',
        render: (text: any) => <a>{text}</a>,
      },
      {
        title: '公里数',
        dataIndex: 'age',
        key: 'age',
      },
      {
        title: '违规类型',
        dataIndex: 'address',
        key: 'address',
      },
      {
        title: '视频回放',
        key: 'tags',
        dataIndex: 'tags',
      },
      {
        title: '签认',
        key: 'action',
        dataIndex: 'action',
      },
    ];
    const data = [
      {
        key: '1',
        name: 'John Brown',
        age: 32,
        address: 'New York No. 1 Lake Park',
        tags: ['nice', 'developer'],
      },
      {
        key: '2',
        name: 'Jim Green',
        age: 42,
        address: 'London No. 1 Lake Park',
        tags: ['loser'],
      },
      {
        key: '3',
        name: 'Joe Black',
        age: 32,
        address: 'Sidney No. 1 Lake Park',
        tags: ['cool', 'teacher'],
      },
    ];
    const renderState = () => {
      switch (task.taskStatus) {
        case 1:
          return (
            <span className={styles.analysis_state} style={{ color: '#20C5F5' }}>
              排队中
            </span>
          );
        case 2:
          return (
            <span className={styles.analysis_state} style={{ color: '#000000' }}>
              分析中
            </span>
          );
        case 3:
          return (
            <span className={styles.analysis_state} style={{ color: '#D82525' }}>
              已停止
            </span>
          );
        case 4:
          return (
            <span className={styles.analysis_state} style={{ color: '#7FD154' }}>
              已完成
            </span>
          );
        default:
          return <span className={styles.analysis_state}> - </span>;
      }
    };
    return (
      <Row gutter={[12, 12]}>
        <Col span={12}>
          <Row style={{ border: '1px solid #EEF1F6', borderRadius: '5px' }}>
            <Col span={24} className={styles.description_container}>
              <Descriptions title={task.videoName}>
                <Descriptions.Item label="司机">{task.driverName} </Descriptions.Item>
                <Descriptions.Item label="副司机">{task.coDriverName}</Descriptions.Item>
                <Descriptions.Item label="机车号">{task.locomotiveNo}</Descriptions.Item>
                <Descriptions.Item label="车次">{task.trainNo}</Descriptions.Item>
                <Descriptions.Item label="线路">{task.lineName}</Descriptions.Item>
              </Descriptions>
            </Col>
            <Col span={24} className={styles.image_container}>
              {imgState ? (
                <>
                  <img
                    src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
                    style={{ height: '54vh', width: '100%' }}
                    onClick={this.imgOnClick}
                  />
                </>
              ) : (
                <>
                  <Row>
                    <Col span={12} className={styles.video_img_h}>
                      <img
                        className={styles.video_img}
                        onClick={this.imgOnClick}
                        src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
                      />
                    </Col>
                    <Col span={12} className={styles.video_img_h}>
                      <img
                        className={styles.video_img}
                        onClick={this.imgOnClick}
                        src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
                      />
                    </Col>
                  </Row>
                  <Row>
                    <Col span={12} className={styles.video_img_h}>
                      <img
                        className={styles.video_img}
                        onClick={this.imgOnClick}
                        src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
                      />
                    </Col>
                    <Col span={12} className={styles.video_img_h}>
                      <img
                        className={styles.video_img}
                        onClick={this.imgOnClick}
                        src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
                      />
                    </Col>
                  </Row>
                </>
              )}
            </Col>
            <Col span={24}>
              <Row>
                <Col span={2} style={{ textAlign: 'right', paddingRight: '5px' }}>
                  111
                </Col>
                <Col span={20}>
                  <Progress percent={30} showInfo={false} />
                </Col>
                <Col span={2} style={{ paddingLeft: '5px' }}>
                  222
                </Col>
              </Row>
              <Row>
                <Col span={2} style={{ textAlign: 'right', paddingRight: '5px' }}>
                  111
                </Col>
                <Col span={20}>
                  <Progress percent={50} status="active" showInfo={false} />
                </Col>
                <Col span={2} style={{ paddingLeft: '5px' }}>
                  222
                </Col>
              </Row>
            </Col>
          </Row>
        </Col>
        <Col span={12}>
          <Row>
            <Col span={24} className={styles.state_container}>
              {renderState()}
              <span>已用时间：{analysisTime}</span>
              <div className={styles.state_container_tools}>
                <Button size="large" icon={<BorderOutlined style={{ color: '#AC1818' }} />}>
                  停止
                </Button>
                <Button
                  size="large"
                  icon={<CaretRightOutlined style={{ color: 'rgb(127, 209, 84)' }} />}
                >
                  开始
                </Button>
                <Button size="large" icon={<DownloadOutlined style={{ color: '#35C9BA' }} />}>
                  下载报告
                </Button>
              </div>
            </Col>
            <Col span={24}>
              <Table
                columns={columns}
                dataSource={data}
                style={{ height: '100%' }}
                pagination={false}
              />
            </Col>
          </Row>
        </Col>
      </Row>
    );
  }
}
export default connect(({ index, loading }: { index: any; loading: Loading }) => ({
  loading: loading,
  index: index,
}))(Index);
