import * as React from 'react';
import { Row, Col, Button, Collapse, Badge, Card, List, Typography } from 'antd';
import { Map } from 'react-amap';
import { HomeOutlined, PieChartOutlined, EyeOutlined } from '@ant-design/icons';
import styles from './Index.less';
const { Panel } = Collapse;
interface Props {}

export const LineDetails = (props: Props) => {
  const data = [
    'Racing car sprays burning fuel into crowd.',
    'Japanese princess to wed commoner.',
    'Australian walks 100km after outback crash.',
    'Man charged over missing wedding girl.',
    'Los Angeles battles huge wildfires.',
  ];

  return (
    <>
      <Row>
        <Col span={24} className={styles.tools_container}>
          <div className={styles.tools_container_botton}>
            <Button size="large">保存</Button>
            <Button size="large">返回</Button>
          </div>
        </Col>
      </Row>
      <Row gutter={[16, 8]}>
        <Col span={16} style={{ height: '75vh', padding: '0px 8px' }}>
          <Row gutter={[0, 8]}>
            <Col span={24} style={{ height: '50vh', borderRadius: '5px' }}>
              <Map amapkey="d774b4bea136dfceb70bb08b383798fa" />
            </Col>
          </Row>
          <Row>
            <Col
              span={24}
              style={{
                backgroundColor: '#EEF1F6',
                height: '25vh',
                borderRadius: '5px',
                padding: '20px',
              }}
            >
              <Row>
                <Col span={24}>全局检测设置</Col>
              </Row>
              <Row>
                <Col span={8}>列车临时起步时，手比信号</Col>
                <Col span={8}>时间范围：</Col>
                <Col span={8}>最少次数：</Col>
              </Row>
              <Row>
                <Col span={8}>列车临时起步时，探身瞭望</Col>
                <Col span={8}>时间范围：</Col>
                <Col span={8}>最少次数：</Col>
              </Row>
              <Row>
                <Col span={8}>列车临时停车时，手比信号</Col>
                <Col span={8}>时间范围：</Col>
                <Col span={8}>最少次数：</Col>
              </Row>
              <Row>
                <Col span={8}>列车运行中，双手离开操作台</Col>
                <Col span={8}>最小持续时间：</Col>
                <Col span={8}></Col>
              </Row>
            </Col>
          </Row>
        </Col>
        <Col span={8} className={styles.list_container} style={{ padding: '0px' }}>
          <Card
            title={
              <div style={{ fontWeight: 500 }}>
                <span style={{ marginRight: '5px' }}>线路设施</span> <Badge count={25} />
              </div>
            }
          >
            <Collapse defaultActiveKey={['1']} expandIconPosition="right" accordion>
              <Panel
                header={
                  <div style={{ marginLeft: '20px' }}>
                    <HomeOutlined
                      onClick={() => {
                        alert('1');
                      }}
                    />
                    <span style={{ margin: '0px 10px' }}>车站</span>
                    <Badge count={25} />
                    <EyeOutlined
                      style={{
                        float: 'right',
                        fontSize: '15px',
                        marginLeft: '15px',
                        marginTop: '4px',
                      }}
                    />
                    <PieChartOutlined
                      style={{
                        float: 'right',
                        fontSize: '15px',
                        marginLeft: '15px',
                        marginTop: '4px',
                      }}
                    />
                    <div style={{ clear: 'both' }}></div>
                  </div>
                }
                key="1"
              >
                111
              </Panel>
              <Panel
                header={
                  <div style={{ marginLeft: '20px' }}>
                    <HomeOutlined
                      onClick={() => {
                        alert('1');
                      }}
                    />
                    <span style={{ margin: '0px 10px' }}>信号灯</span>
                    <Badge count={25} />
                  </div>
                }
                key="2"
              >
                22
              </Panel>
              <Panel
                header={
                  <div style={{ marginLeft: '20px' }}>
                    <HomeOutlined
                      onClick={() => {
                        alert('1');
                      }}
                    />
                    <span style={{ margin: '0px 10px' }}>标识</span>
                    <Badge count={25} />
                  </div>
                }
                key="3"
              >
                22
              </Panel>
              <Panel
                key="4"
                header={
                  <div style={{ marginLeft: '20px' }}>
                    <HomeOutlined
                      onClick={() => {
                        alert('1');
                      }}
                    />
                    <span style={{ margin: '0px 10px' }}>岔道</span>
                    <Badge count={25} />
                  </div>
                }
              >
                22
              </Panel>
            </Collapse>
          </Card>
          <Card
            title={
              <div style={{ fontWeight: 500 }}>
                <span style={{ marginRight: '5px' }}>识别顶点</span> <Badge count={25} />
              </div>
            }
          >
            <Collapse defaultActiveKey={['1']} expandIconPosition="right" accordion>
              <Panel header="探身瞭望" key="1">
                <List
                  header={<div>Header</div>}
                  footer={<div>Footer</div>}
                  bordered
                  dataSource={data}
                  renderItem={(item) => (
                    <List.Item>
                      <Typography.Text mark>[ITEM]</Typography.Text> {item}
                    </List.Item>
                  )}
                />
              </Panel>
              <Panel header="手比信号" key="2">
                22
              </Panel>
              <Panel header="副司机防护" key="3">
                22
              </Panel>
            </Collapse>
          </Card>
        </Col>
      </Row>
    </>
  );
};
