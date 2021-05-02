/*
 * @Author: 钟凯
 * @Date: 2021-02-17 13:01:56
 * @LastEditTime: 2021-03-03 16:40:55
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\item\components\FastFormModal.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */

import { Translate } from '@/utils/translate';
import { MinusCircleOutlined, PlusCircleOutlined } from '@ant-design/icons';
import { Button, Col, Form, Input, Modal, Row, Select, Space } from 'antd';
import React, { useState } from 'react';
import * as itemService from '@/pages/DataModel/services/item';
import { useRequest } from 'umi';
import { ItemTypeOption, StatusEnum } from '../../common';

interface Props {
  onSubmit: (data: any) => void;
}

const FastFormModal = (props: Props) => {
  const [form] = Form.useForm();
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [generateLoding, setGenerateLoding] = useState(false);
  const saveOperate = useRequest(itemService.save, { manual: true, throwOnError: true });
  const onAddClick = () => {
    setIsModalVisible(true);
  };
  return (
    <>
      <Button onClick={onAddClick}>快速新建</Button>
      <Modal
        title="快速新建数据项"
        visible={isModalVisible}
        width={950}
        okButtonProps={{
          loading: saveOperate.loading,
        }}
        onCancel={() => {
          form.setFieldsValue({ names: null, items: [] });
          setIsModalVisible(false);
        }}
        onOk={() => {
          form.validateFields().then((values) => {
            saveOperate.run(values.items).then((data) => {
              form.setFieldsValue({ names: null, items: [] });
              setIsModalVisible(false);
              props.onSubmit(data);
            });
          });
        }}
      >
        <Form name="dynamic_form_item" form={form}>
          <Form.Item
            label="数据项"
            name="names"
            rules={[{ required: true, message: '请输入数据项名称，多条数据以换行进行添加' }]}
          >
            <Row gutter={8}>
              <Col span={20}>
                <Input.TextArea
                  autoFocus
                  allowClear
                  placeholder="请输入数据项名称，多条数据以换行进行添加"
                />
              </Col>
              <Col span={4}>
                <Button
                  loading={generateLoding}
                  icon={<PlusCircleOutlined />}
                  onClick={() => {
                    const value = form.getFieldValue('names') as string;
                    if (value && value.length > 0) {
                      setGenerateLoding(true);
                      const names = value.split('\n').filter((t) => t.trim().length > 0);
                      const values = names.join('\n');
                      Translate.to(values).then((data) => {
                        if (data.trans_result) {
                          const items = data.trans_result.map((t) => {
                            return {
                              name: t.src,
                              code: t.dst,
                              type: ItemTypeOption[0].value,
                              status: StatusEnum.enable.value,
                            } as API.Model.AddItem;
                          });
                          form.setFieldsValue({ items });
                          setGenerateLoding(false);
                        }
                      });
                    }
                  }}
                >
                  生成
                </Button>
              </Col>
            </Row>
          </Form.Item>
          <Form.List name="items">
            {(fields, { remove }) => (
              <>
                {fields.map((field) => (
                  <Space key={field.key} align="baseline">
                    <Form.Item
                      {...field}
                      label="名称"
                      name={[field.name, 'name']}
                      fieldKey={[field.fieldKey, 'name']}
                      rules={[{ required: true }]}
                    >
                      <Input />
                    </Form.Item>
                    <Form.Item
                      {...field}
                      label="编码"
                      name={[field.name, 'code']}
                      fieldKey={[field.fieldKey, 'code']}
                      rules={[{ required: true }]}
                    >
                      <Input />
                    </Form.Item>
                    <Form.Item
                      {...field}
                      label="类型"
                      name={[field.name, 'type']}
                      fieldKey={[field.fieldKey, 'type']}
                      rules={[{ required: true }]}
                    >
                      <Select style={{ width: 180 }} options={ItemTypeOption} />
                    </Form.Item>
                    <MinusCircleOutlined onClick={() => remove(field.name)} />
                  </Space>
                ))}
              </>
            )}
          </Form.List>
        </Form>
      </Modal>
    </>
  );
};

export default FastFormModal;
