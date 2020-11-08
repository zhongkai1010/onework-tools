import * as React from 'react';
import { Modal, Form, Row, Col, Steps, Descriptions, Upload, Button } from 'antd';
import UserSelect from '@/pages/Task/components/UserSelect/Index';
import RouteSelect from '@/pages/Task/components/RouteSelect/Index';
import { ModalProps } from 'antd/es/modal';
import { Task } from '@/models/task.d';
import { UploadOutlined } from '@ant-design/icons';
import { FormInstance } from 'antd/lib/form';
import { RcFile } from 'antd/lib/upload';
import { useRequest } from 'umi';
import './Index.less';
import * as services from '@/services/task';

const { Step } = Steps;

interface IAppProps {
  onOneStep: (task: any, files: Array<RcFile>) => void; //第一步骤
  onTwoStep: () => void; //第二步骤
  onThreeStep: () => void;
  onClaseModel: () => void;
  task: Task; //任务
  step: number; //步骤数
  files: Array<RcFile>; //附件
}

const App: React.FC<IAppProps & ModalProps> = (props) => {
  let formRef = React.createRef<FormInstance>();
  let files: Array<RcFile> = [];
  let confirmFiles: Array<RcFile> = [];
  const { loading, run } = useRequest(services.taskCreate, { manual: true });
  const onOk = (e: React.MouseEvent<HTMLElement>) => {
    //新建任务
    if (props.step == 0) {
      if (formRef.current) {
        var formData = formRef.current.getFieldsValue();
        run(formData).then((value) => {
          props.onOneStep(value, files);
        });
      }
    }
    //上传文件
    if (props.step == 1) {
      console.log(confirmFiles);
      //props.onTwoStep();
    }
    //验证是否上传完成
    if (props.step == 2) {
      props.onThreeStep();
    }
  };
  const onCancel = (e: React.MouseEvent<HTMLElement>) => {
    props.onClaseModel();
  };
  const task = props.task || {};
  const normFile = (e: any) => {
    //console.log('Upload event:', e);
    if (Array.isArray(e)) {
      return e;
    }
    return e && e.fileList;
  };
  return (
    <Modal
      title="新建任务"
      onOk={onOk}
      onCancel={onCancel}
      maskClosable={false}
      confirmLoading={loading}
      closable={false}
      {...props}
      width={800}
    >
      <Row>
        <Col span={24} style={{ marginBottom: '20px' }}>
          <Steps current={props.step}>
            <Step title="填写任务信息" />
            <Step title="上传录像信息" />
            <Step title="创建任务" />
          </Steps>
        </Col>
        {props.step == 0 ? (
          <>
            <Col span={24}>
              <Form
                labelCol={{ span: 4 }}
                wrapperCol={{ span: 20 }}
                ref={formRef}
                name="task-create—form"
              >
                <Form.Item label="司机" name="driverId" required={true}>
                  <UserSelect key="driverId" />
                </Form.Item>
                <Form.Item label="副司机" name="coDriverId" required={true}>
                  <UserSelect key="coDriverId" />
                </Form.Item>
                <Form.Item label="线路" name="routeId" required={true}>
                  <RouteSelect key="routeId" />
                </Form.Item>
                <Form.Item
                  required={true}
                  label="录像文件"
                  name="routeId1"
                  valuePropName="fileList"
                  getValueFromEvent={normFile}
                >
                  <Upload
                    directory={true}
                    beforeUpload={(file) => {
                      files.push(file);
                      return false;
                    }}
                  >
                    <Button icon={<UploadOutlined />}>选择文件</Button>
                  </Upload>
                </Form.Item>
              </Form>
            </Col>
          </>
        ) : (
          <Col>
            <Col span={24}>
              <Descriptions>
                <Descriptions.Item label="任务编号">{task.id}</Descriptions.Item>
                <Descriptions.Item label="当前状态">准备中...</Descriptions.Item>
                <Descriptions.Item label=""> </Descriptions.Item>
                <Descriptions.Item label="车辆编号"> - </Descriptions.Item>
                <Descriptions.Item label="车次"> - </Descriptions.Item>
                <Descriptions.Item label="发车时间"> - </Descriptions.Item>
              </Descriptions>
            </Col>
            <Col span={24}>
              <Upload
                directory
                defaultFileList={props.files}
                beforeUpload={(file) => {
                  confirmFiles.push(file);
                  return false;
                }}
              ></Upload>
            </Col>
          </Col>
        )}
      </Row>
    </Modal>
  );
};

export default App;
