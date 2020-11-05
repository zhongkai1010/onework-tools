import * as React from 'react';
import { Modal, Form, Row, Col, Steps, Descriptions, Upload, Button } from 'antd';
import UserSelect from '@/pages/Task/components/UserSelect/Index';
import { ModalProps } from 'antd/es/modal';
import { Task } from '@/models/task';
import { UploadOutlined } from '@ant-design/icons';
import { FormInstance } from 'antd/lib/form';

const { Step } = Steps;

interface IAppProps {
  onCloseButton: (e: React.MouseEvent<HTMLElement>) => void; //关闭按钮事件
  onConfirmButton: (e: React.MouseEvent<HTMLElement>) => any; //确认按钮事件
  task: Task | any; //新增后的任务详情
  step: number; //步骤数
}

const App: React.FC<IAppProps & ModalProps> = (props) => {
  let formRef = React.createRef<FormInstance>();
  const handleOk = (e: any) => {
    props.onConfirmButton(e);
  };
  const task = props.task || {};
  return (
    <Modal
      title="新建任务"
      onOk={handleOk}
      onCancel={props.onCloseButton}
      maskClosable={false}
      {...props}
    >
      <Row>
        <Col span={24} style={{ marginBottom: '20px' }}>
          <Steps current={props.step}>
            <Step title="基本信息" />
            <Step title="上传文件" />
          </Steps>
        </Col>
        {props.step == 0 ? (
          <Col span={24}>
            <Form
              labelCol={{ span: 4 }}
              wrapperCol={{ span: 20 }}
              ref={formRef}
              name="task-create—form"
            >
              <Form.Item label="司机" name="driverId1" initialValue="1">
                <UserSelect key="driverId1" />
              </Form.Item>
            </Form>
            <Form labelCol={{ span: 4 }} wrapperCol={{ span: 20 }}>
              <Form.Item label="副司机" name="driverId2">
                <UserSelect key="driverId2" />
              </Form.Item>
            </Form>
            <Form labelCol={{ span: 4 }} wrapperCol={{ span: 20 }}>
              <Form.Item label="线路" name="driverId3">
                <UserSelect key="driverId3" />
              </Form.Item>
            </Form>
          </Col>
        ) : (
          <>
            <Col span={24}>
              <Descriptions>
                <Descriptions.Item label="任务编号">{task.id}</Descriptions.Item>
                <Descriptions.Item label="当前状态">{task.taskStatus}</Descriptions.Item>
                <Descriptions.Item label="车辆编号">{task.trainNo}</Descriptions.Item>
                <Descriptions.Item label="车次">{task.locomotiveNo}</Descriptions.Item>
                <Descriptions.Item label="发车时间">{task.departureDate}</Descriptions.Item>
              </Descriptions>
            </Col>
            <Col span={24}>
              <Upload
                action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                listType="picture"
                multiple={true}
              >
                <Button icon={<UploadOutlined />}>Upload</Button>
              </Upload>
            </Col>
          </>
        )}
      </Row>
    </Modal>
  );
};

export default App;
