import * as React from 'react';
import { Modal, Form, Row, Col, Steps } from 'antd';
import UserSelect from '@/pages/Task/components/UserSelect/Index';
import { ModalProps } from 'antd/es/modal';

const { Step } = Steps;

interface IAppProps {
  closeModal: (e: React.MouseEvent<HTMLElement>) => void;
}

const App: React.FC<IAppProps & ModalProps> = (props) => {
  const handleOk = (e: any) => {};
  const onOk = () => {};
  return (
    <Modal
      title="新建任务"
      onOk={handleOk}
      onCancel={props.closeModal}
      maskClosable={false}
      {...props}
    >
      <Row>
        <Col span={24}>
          <Steps current={0}>
            <Step title="基本信息" />
            <Step title="上传文件" />
          </Steps>
        </Col>
        <Col span={24} style={{ marginTop: '20px' }}>
          <Form labelCol={{ span: 4 }} wrapperCol={{ span: 20 }}>
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
        <Col></Col>
      </Row>
    </Modal>
  );
};

export default App;
