import * as React from 'react';
import { Row, Col, Button, Form, Input, Table, Tag, Space } from 'antd';

export interface IAppProps {}

export interface IAppState {}

export default class Driver extends React.Component<IAppProps, IAppState> {
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
          <Form layout="inline">
            <Form.Item label="创建时间">
              <Input />
            </Form.Item>
            <Form.Item label="机车号">
              <Input />
            </Form.Item>
            <Form.Item label="车次">
              <Input />
            </Form.Item>
            <Form.Item label="司机">
              <Input />
            </Form.Item>
            <Form.Item label="发车时间">
              <Input />
            </Form.Item>
            <Form.Item label="任务状态">
              <Input />
            </Form.Item>
          </Form>
        </Col>
        <Col span={24} style={{ marginBottom: '10px', height: '60vh' }}>
          <Table columns={columns} dataSource={data} style={{ height: '100%' }} />
        </Col>
      </Row>
    );
  }
}
