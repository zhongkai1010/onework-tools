/*
 * @Author: 钟凯
 * @Date: 2021-02-18 12:10:16
 * @LastEditTime: 2021-02-18 21:55:07
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Collection\components\EditModal.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import React, { useState } from 'react';
import type { ModalProps } from 'antd';
import { Form, Input } from 'antd';
import { Button, Descriptions, Modal } from 'antd';
import ProTable from '@ant-design/pro-table';
import { Translate } from '@/utils/translate';
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import ItemSelect from '@/pages/DataModel/components/ItemSelect';
import * as collectionServices from '@/services/model/collection';
import { useRequest } from 'umi';

interface Props {
  collection: API.Model.Collection | undefined;
  onClose: () => void;
  onFinish: () => void;
}

const typeValueEnum = {
  character: { text: '文本' },
  integer: { text: '整型' },
  digital: { text: '数字' },
  boolean: { text: '布尔' },
  enumerate: { text: '枚举' },
  date: { text: '日期' },
};

const EditModal = (props: Props & ModalProps) => {
  const [isEditState, setIsEditState] = useState(false);
  const updateOperate = useRequest(collectionServices.update, { manual: true });
  const [form] = Form.useForm();
  return (
    <Modal
      {...props}
      width="60%"
      title={isEditState ? '编辑数据集' : '查看详情'}
      onCancel={() => {
        props.onClose();
        setIsEditState(false);
      }}
      okButtonProps={{
        loading: updateOperate.loading,
      }}
      onOk={() => {
        if (isEditState) {
          form.validateFields().then((values) => {           
            updateOperate.run({ ...props.collection, ...values }).then(() => {
              setIsEditState(false);
              props.onClose();             
              props.onFinish();
            });
          });
        } else {
          props.onClose();
          setIsEditState(false);
        }
      }}
    >
      {isEditState ? (
        <Form
          layout="horizontal"
          name="collection_edit_form"
          labelCol={{ span: 3 }}
          wrapperCol={{ span: 20 }}
          form={form}
        >
          <Form.Item
            label="名称"
            name="name"
            rules={[{ required: true, message: '请输入数据集名称' }]}
          >
            <Input.Search
              onSearch={(value) => {
                Translate.to(value).then((data) => {
                  if (data.trans_result) {
                    const code = data.trans_result.length > 0 ? data.trans_result[0].dst : '';
                    const values = form.getFieldsValue();
                    form.setFieldsValue({ ...values, code });
                  }
                });
              }}
              autoComplete="new-password"
            />
          </Form.Item>
          <Form.Item
            label="编码"
            name="code"
            rules={[{ required: true, message: '请输入数据集编码' }]}
          >
            <Input />
          </Form.Item>
          <Form.List name="items">
            {(fields, { add, remove }) => (
              <>
                {fields.map((field, index) => (
                  <Form.Item
                    label={index === 0 ? '数据项' : '数据项'}
                    required={true}
                    key={field.key}
                  >
                    <Form.Item
                      {...field}
                      rules={[{ required: true, message: '请选择数据项' }]}
                      noStyle
                    >
                      <ItemSelect
                        style={{ width: '90%' }}
                        options={props.collection?.items.map((t) => {
                          return { label: t.name, value: t.uid };
                        })}
                      />
                    </Form.Item>
                    {fields.length > 1 ? (
                      <MinusCircleOutlined
                        key={`${field.key}_button`}
                        style={{
                          position: 'relative',
                          top: 4,
                          margin: '0 8px',
                          color: '#999',
                          fontSize: 24,
                          cursor: 'pointer',
                          transition: 'all 0.3s',
                        }}
                        onClick={() => remove(field.name)}
                      />
                    ) : null}
                  </Form.Item>
                ))}
                <Form.Item label="数据项">
                  <Button
                    type="dashed"
                    style={{ width: '100%' }}
                    onClick={() => add()}
                    icon={<PlusOutlined />}
                  >
                    添加数据项
                  </Button>
                </Form.Item>
              </>
            )}
          </Form.List>
          <Form.Item label="描述" name="description" rules={[{ required: false }]}>
            <Input.TextArea />
          </Form.Item>
        </Form>
      ) : (
        <Descriptions
          title="数据集"
          bordered
          extra={
            <Button
              type="primary"
              onClick={() => {
                form.setFieldsValue({
                  ...props.collection,
                  items: props.collection?.items.map((t) => t.uid),
                });
                setIsEditState(true);
              }}
            >
              编辑
            </Button>
          }
          labelStyle={{ width: '120px' }}
        >
          <Descriptions.Item label="名称" span={3}>
            {props.collection?.name}
          </Descriptions.Item>
          <Descriptions.Item label="编码" span={3}>
            {props.collection?.code}
          </Descriptions.Item>
          <Descriptions.Item label="描述" span={3}>
            {props.collection?.description}
          </Descriptions.Item>
          <Descriptions.Item label="数据项">
            <ProTable<API.Model.Item>
              key={props.collection?.uid}
              dataSource={props.collection?.items || []}
              pagination={false}
              options={false}
              search={false}
              columns={[
                {
                  title: '编码',
                  dataIndex: 'code',
                },
                {
                  title: '名称',
                  dataIndex: 'name',
                },
                {
                  title: '类型',
                  dataIndex: 'type',
                  valueType: 'select',
                  width: 150,
                  valueEnum: typeValueEnum,
                },
              ]}
            />
          </Descriptions.Item>
        </Descriptions>
      )}
    </Modal>
  );
};

export default EditModal;
