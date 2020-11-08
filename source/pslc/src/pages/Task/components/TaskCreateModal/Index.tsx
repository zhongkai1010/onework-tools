import React, { useState } from 'react';
import { Modal, Form, Upload, Button, message } from 'antd';
import UserSelect from '@/pages/Task/components/UserSelect/Index';
import RouteSelect from '@/pages/Task/components/RouteSelect/Index';
import { ModalProps } from 'antd/es/modal';
import { UploadOutlined } from '@ant-design/icons';
import { FormInstance } from 'antd/lib/form';
import { RcFile } from 'antd/lib/upload';
import { request } from 'umi';

import { DriverType } from '@/models/user.d';

interface IAppProps {
  onClaseModel: () => void;
}

const App: React.FC<IAppProps & ModalProps> = (props) => {
  let formRef = React.createRef<FormInstance>();
  let files: Array<RcFile> = [];
  const [loading, setLoading] = useState(false);
  // const { loading, run } = useRequest(services.createAndFile, { manual: true });
  const onOk = () => {
    if (formRef.current) {
      let formData = formRef.current.getFieldsValue();
      const fromFiles = new FormData();
      files.forEach((file) => {
        fromFiles.append('files[]', file);
      });
      setLoading(true);
      request('/api/v1/task/createAndFile', {
        method: 'post',
        headers: {
          token:
            'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjEsImlhdCI6MTYwNDc0MTAzNiwiZXhwIjoxNjA2NDY5MDM2fQ.dL9xvrzACrJC_sXzgSSjL70QcV-ERVqddkhxUFFwS_w',
        },
        params: {
          coDriverId: formData.coDriverId,
          driverId: formData.driverId,
          routeId: formData.routeId,
          total: files.length,
        },
        requestType: 'form',
        responseType: 'json',
        data: fromFiles,
      })
        .then(() => {
          setLoading(false);
          message.info('创建任务成功。');
          props.onClaseModel();
        })
        .catch(() => {
          setLoading(false);
        });
    }
  };
  const onCancel = () => {
    props.onClaseModel();
  };

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
      destroyOnClose={true}
      okText={loading ? '提交中...' : '确认'}
      okButtonProps={{
        loading: loading,
      }}
      closable={false}
      {...props}
      width={800}
      cancelButtonProps={{
        disabled: loading,
      }}
    >
      <Form labelCol={{ span: 4 }} wrapperCol={{ span: 20 }} ref={formRef} name="task-create—form">
        <Form.Item
          label="司机"
          name="driverId"
          required={true}
          rules={[{ required: true, message: '请选择司机！' }]}
        >
          <UserSelect key="driverId" SelectType={DriverType.A} />
        </Form.Item>
        <Form.Item
          label="副司机"
          name="coDriverId"
          required={true}
          rules={[{ required: true, message: '请选择副司机！' }]}
        >
          <UserSelect key="coDriverId" SelectType={DriverType.B} />
        </Form.Item>
        <Form.Item
          label="线路"
          name="routeId"
          required={true}
          rules={[{ required: true, message: '请选择副线路！' }]}
        >
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
            multiple={true}
            beforeUpload={(file) => {
              files.push(file);
              return false;
            }}
          >
            <Button icon={<UploadOutlined />}>选择文件</Button>
          </Upload>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default App;
