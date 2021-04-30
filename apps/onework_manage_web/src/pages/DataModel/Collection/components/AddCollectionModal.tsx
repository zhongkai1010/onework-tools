/*
 * @Author: 钟凯
 * @Date: 2021-02-18 12:09:51
 * @LastEditTime: 2021-03-12 09:55:05
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\collection\components\AddCollectionModal.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import type { ModalFormProps } from '@ant-design/pro-form';
import { ModalForm } from '@ant-design/pro-form';
import React from 'react';

import { Button, Form, Input } from 'antd';
import { Translate } from '@/utils/translate';
import ItemSelect from '@/pages/DataModel/components/ItemSelect';
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';

const AddCollectionModal = (props: ModalFormProps) => {
  const [form] = Form.useForm();
  return (
    <ModalForm
      {...props}
      title="新建数据集"
      layout="horizontal"
      name="dynamic_form_item"
      modalProps={{
        onCancel: () => {
          form.setFieldsValue({
            name: null,
            code: null,
            items: [],
          });
        },
      }}
      labelCol={{ span: 3 }}
      wrapperCol={{ span: 20 }}
      form={form}
      trigger={<Button type="primary">新建</Button>}
    >
      <Form.Item label="名称" name="name" rules={[{ required: true, message: '请输入数据集名称' }]}>
        <Input.Search
          placeholder="请输入数据集名称"
          autoFocus
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
      <Form.Item label="编码" name="code" rules={[{ required: true, message: '请输入数据集编码' }]}>
        <Input placeholder="请输入数据集编码" />
      </Form.Item>

      <Form.List name="itemUids">
        {(fields, { add, remove }) => (
          <>
            {fields.map((field, index) => (
              <Form.Item label={index === 0 ? '数据项' : '数据项'} required={true} key={field.key}>
                <Form.Item {...field} rules={[{ required: true, message: '请选择数据项' }]} noStyle>
                  <ItemSelect key={field.key} style={{ width: '90%' }} placeholder="请选择数据项" />
                </Form.Item>
                {fields.length > 1 ? (
                  <MinusCircleOutlined
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
    </ModalForm>
  );
};

export default AddCollectionModal;
