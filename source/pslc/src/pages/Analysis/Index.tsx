import * as React from 'react';
import { Row, Col, Descriptions, Progress, Button, Tag, Space, Table, Image } from 'antd';
import { Loading, connect, Dispatch } from 'umi';
import { IndexPageData } from '@/models/index';
import styles from './Index.less';

export interface IAppProps {
  dispatch: Dispatch;
  index: IndexPageData;
}
export interface IAppState {}

class Index extends React.Component<IAppProps, IAppState> {
  constructor(props: IAppProps) {
    super(props);
    this.state = {};
  }
  imgOnClick = () => {
    alert('1');
  };
  public render() {
    const columns = [
      {
        title: 'Name',
        dataIndex: 'name',
        key: 'name',
        render: (text: any) => <a>{text}</a>,
      },
      {
        title: 'Age',
        dataIndex: 'age',
        key: 'age',
      },
      {
        title: 'Address',
        dataIndex: 'address',
        key: 'address',
      },
      {
        title: 'Tags',
        key: 'tags',
        dataIndex: 'tags',
        render: (tags: any) => (
          <>
            {tags.map((tag: any) => {
              let color = tag.length > 5 ? 'geekblue' : 'green';
              if (tag === 'loser') {
                color = 'volcano';
              }
              return (
                <Tag color={color} key={tag}>
                  {tag.toUpperCase()}
                </Tag>
              );
            })}
          </>
        ),
      },
      {
        title: 'Action',
        key: 'action',
        render: (text: any, record: any) => (
          <Space size="middle">
            <a>Invite {record.name}</a>
            <a>Delete</a>
          </Space>
        ),
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
    const { task } = this.props.index;
    console.log(this.props);
    return (
      <Row gutter={[12, 12]}>
        <Col span={12}>
          <Row style={{ border: '1px solid #EEF1F6' }}>
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
              {/* <Row>
                <Col span={24}>
                  <Image
                    src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
                    preview={false}
                    className={styles.video_img}
                  />
                </Col>
              </Row> */}
              <Row>
                <Col span={12} className={styles.video_img_h}>
                  <img className={styles.video_img} onClick={this.imgOnClick} />
                </Col>
                <Col span={12} className={styles.video_img_h}>
                  <img className={styles.video_img} />
                </Col>
              </Row>
              <Row>
                <Col span={12} className={styles.video_img_h}>
                  <img className={styles.video_img} />
                </Col>
                <Col span={12} className={styles.video_img_h}>
                  <img className={styles.video_img} />
                </Col>
              </Row>
            </Col>
            <Col span={24}>
              <Progress percent={30} />
              <Progress percent={50} status="active" />
            </Col>
          </Row>
        </Col>
        <Col span={12}>
          <Row>
            <Col
              span={24}
              style={{
                border: '1px solid #EEF1F6',
                height: '8vh',
                lineHeight: '8vh',
                backgroundColor: 'rgb(243, 243, 244)',
                paddingLeft: '20px',
                marginBottom: '10px',
                borderRadius: '5px',
              }}
            >
              <span style={{ marginRight: '20px' }}>分析中</span>
              <span>已用时间：12:13</span>
              <div style={{ display: 'inline-block', position: 'absolute', right: 0 }}>
                <Button type="primary" style={{ marginRight: '10px' }} size="large">
                  新建任务
                </Button>
                <Button type="primary" style={{ marginRight: '10px' }} size="large">
                  停止
                </Button>
                <Button type="primary" style={{ marginRight: '10px' }} size="large">
                  开始
                </Button>
              </div>
            </Col>
            <Col span={24}>
              <Table columns={columns} dataSource={data} style={{ height: '100%' }} />
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
