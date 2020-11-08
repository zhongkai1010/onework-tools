import React, { useEffect } from 'react';
import { Modal, Form, Input } from 'antd';
import { ModalProps } from 'antd/es/modal';
import { FormInstance } from 'antd/lib/form';
import DriverTypeSelect from '@/pages/Driver/components/DriverTypeSelect/Index';
import { Driver } from '@/models/user.d';
import { useRequest } from 'umi';
import * as services from '@/services/user';

interface IAppProps {
  onClaseModel: () => void;
  onConfirm: (fromData: Driver) => void;
  data?: Driver;
  addOperation: boolean;
}
const FromModal: React.FunctionComponent<IAppProps & ModalProps> = (props) => {
  const formRef = React.createRef<FormInstance>();
  const update1 = useRequest(services.updateDriver, { manual: true });
  const create = useRequest(services.createDriver, { manual: true });
  useEffect(() => {});

  const onCancel = () => {
    props.onClaseModel();
  };

  const onOk = () => {
    if (formRef.current) {
      const fromData = formRef.current.getFieldsValue();
      if (props.addOperation) {
        create.run({ ...fromData, username: fromData.work_id })
        console.log(create.error?.message)
      } else {
        update1.run({ ...fromData, id: fromData.id }).then(() => {
          props.onConfirm(fromData);
        });
      }
    }
  };
  let values = props.addOperation ? {} : props.data ?? {};
  // console.log('FromModal-data', props.data);
  // console.log('FromModal-addOperation', props.addOperation);
  return (
    <Modal title="添加司机" onCancel={onCancel} onOk={onOk} maskClosable={false} {...props}>
      <Form labelCol={{ span: 4 }} wrapperCol={{ span: 20 }} ref={formRef} name="control-ref">
        <Form.Item label="工号" name="work_id" initialValue={values.work_id}>
          <Input />
        </Form.Item>
        <Form.Item label="姓名" name="name" initialValue={values.name}>
          <Input />
        </Form.Item>
        <Form.Item label="职名" name="user_type" initialValue={values.user_type}>
          <DriverTypeSelect />
        </Form.Item>
        <Form.Item label="车队" name="work_group" initialValue={values.work_group}>
          <Input />
        </Form.Item>
        <Form.Item label="指导组" name="teacher_group" initialValue={values.teacher_group}>
          <Input />
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default FromModal;
