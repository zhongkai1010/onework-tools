import * as React from 'react';
import { Row, Col, Descriptions, Progress, Button, Tag, Space, Table } from 'antd';

export interface IAppProps {}

export interface IAppState {}

export default class Line extends React.Component<IAppProps, IAppState> {
  constructor(props: IAppProps) {
    super(props);

    this.state = {};
  }

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
    return (
      <Row gutter={[16, 8]}>
        <Col span={16}>
          <Row style={{ border: '1px solid #ccc' }}>
            <Col span={24} style={{ height: '15vh' }}>
              <Descriptions title="User Info">
                <Descriptions.Item label="UserName">Zhou Maomao</Descriptions.Item>
                <Descriptions.Item label="Telephone">1810000000</Descriptions.Item>
                <Descriptions.Item label="Live">Hangzhou, Zhejiang</Descriptions.Item>
                <Descriptions.Item label="Remark">empty</Descriptions.Item>
                <Descriptions.Item label="Address">
                  No. 18, Wantang Road, Xihu District, Hangzhou, Zhejiang, China
                </Descriptions.Item>
              </Descriptions>
            </Col>
            <Col span={24} style={{ height: '50vh', backgroundColor: '#ccc' }}></Col>
            <Col span={24}>
              <Progress percent={30} />
              <Progress percent={50} status="active" />
            </Col>
          </Row>
        </Col>
        <Col span={8}>
          <Row style={{ border: '1px solid #ccc' }}>
            <Col span={24} style={{ height: '10vh', backgroundColor: '#ccc' }}>
              <Button type="primary" style={{ marginRight: '10px' }} size="large">
                新建任务
              </Button>
              <Button type="primary" style={{ marginRight: '10px' }} size="large">
                停止
              </Button>
              <Button type="primary" style={{ marginRight: '10px' }} size="large">
                开始
              </Button>
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
