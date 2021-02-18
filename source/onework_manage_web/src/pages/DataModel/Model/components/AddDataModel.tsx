/*
 * @Author: 钟凯
 * @Date: 2021-02-18 21:41:50
 * @LastEditTime: 2021-02-19 00:35:29
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\AddDataModel.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { ModalForm, ProFormSelect, ProFormText } from '@ant-design/pro-form';
import { Button, Form, Input, InputNumber, Select, Space } from 'antd';
import { Translate } from '@/utils/translate';
import CollectionSelect from '@/pages/DataModel/components/collectionSelect';
import React from 'react';
import type { LabeledValue } from 'antd/lib/select';
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import type { FormListFieldData } from 'antd/lib/form/FormList';

const AddDataModel = () => {
  const [form] = Form.useForm();

  const renderItem = (field: FormListFieldData, index: number) => {
    return (
      <>
        <Form.Item
          {...field}
          label={index === 0 ? '名称' : undefined}
          name={[field.name, 'itemName']}
          rules={[{ required: true, message: '请选择数据项名称' }]}
          fieldKey={[field.name, 'itemName']}
        >
          <Input />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '编码' : undefined}
          name={[field.name, 'itemCode']}
          rules={[{ required: true, message: '请选择数据项编码' }]}
          fieldKey={[field.name, 'itemCode']}
        >
          <Input />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '类型' : undefined}
          rules={[{ required: true, message: '请选择数据项类型' }]}
          name={[field.name, 'itemType']}
          fieldKey={[field.name, 'itemType']}
        >
          <Select style={{ width: 120 }}>
            <Select.Option value="character">文本</Select.Option>
            <Select.Option value="integer">整数</Select.Option>
            <Select.Option value="digital">数字</Select.Option>
            <Select.Option value="boolean">布尔</Select.Option>
            <Select.Option value="enumerate">枚举</Select.Option>
            <Select.Option value="date">时间</Select.Option>
          </Select>
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '是否为空' : undefined}
          rules={[{ required: true, message: '请选择数据项是否为空' }]}
          name={[field.name, 'isNull']}
          fieldKey={[field.name, 'isNull']}
        >
          <Select style={{ width: 120 }}>
            <Select.Option value="true">是</Select.Option>
            <Select.Option value="false">否</Select.Option>
          </Select>
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '长度' : undefined}
          name={[field.name, 'length']}
          fieldKey={[field.name, 'length']}
        >
          <InputNumber min={0} max={255} precision={0} />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '精度' : undefined}
          name={[field.name, 'precision']}
          fieldKey={[field.name, 'precision']}
        >
          <InputNumber min={0} max={32} precision={0} />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '默认值' : undefined}
          name={[field.name, 'defaultValue']}
          fieldKey={[field.name, 'defaultValue']}
        >
          <Input />
        </Form.Item>
      </>
    );
  };
  return (
    <ModalForm
      title="新建数据模型"
      layout="vertical"
      form={form}
      width="80%"
      modalProps={{
        onCancel: () => {
          form.setFieldsValue({ name: '', code: '', items: [] });
        },
      }}
      trigger={<Button type="primary">新建</Button>}
    >
      <Form.Item
        label="名称"
        name="name"
        rules={[{ required: true, message: '请输入数据模型名称!' }]}
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
      <ProFormText
        label="编码"
        name="code"
        rules={[
          {
            required: true,
            message: '请填写数据模型编码',
          },
        ]}
      />
      <ProFormSelect
        label="类型"
        name="type"
        rules={[
          {
            required: true,
            message: '请选择数据模型类型',
          },
        ]}
        initialValue={'clsss'}
        options={[
          {
            label: '类',
            value: 'clsss',
          },
          {
            label: '抽象',
            value: 'abstract',
          },
          {
            label: '接口',
            value: 'interface',
          },
        ]}
      />
      <Form.Item label="数据集">
        <CollectionSelect
          mode="multiple"
          onChange={(_value, option: any) => {
            const values = form.getFieldsValue();
            const items = values.items || [];
            const collections = option as (API.Model.Collection & LabeledValue)[];
            for (let i = 0; i < collections.length; i += 1) {
              const collection = collections[i];
              for (let j = 0; j < collection.items.length; j += 1) {
                const item = collection.items[j];
                if (items.filter((t: any) => t.itemName === item.name).length === 0) {
                  items.push({
                    itemName: item.name,
                    itemCode: item.code,
                    itemType: item.type,
                    isNull: 'true',
                  });
                }
              }
            }
            form.setFieldsValue({ ...values, items });
          }}
        />
      </Form.Item>
      <Form.Item label="数据项">
        <Form.List name="items">
          {(fields, { add, remove }) => (
            <>
              {fields.map((field, index) => (
                <Space key={field.key} align="baseline">
                  {renderItem(field, index)}
                  <MinusCircleOutlined
                    key={`${field.key}_button`}
                    style={{
                      position: 'relative',
                      top: index === 0 ? 40 : 5,
                      margin: '0 8px',
                      color: '#999',
                      fontSize: 24,
                      cursor: 'pointer',
                      transition: 'all 0.3s',
                    }}
                    onClick={() => remove(field.name)}
                  />
                </Space>
              ))}
              <Form.Item>
                <Button
                  type="dashed"
                  onClick={() => add({ items: [] })}
                  block
                  icon={<PlusOutlined />}
                >
                  添加数据项
                </Button>
              </Form.Item>
            </>
          )}
        </Form.List>
      </Form.Item>
    </ModalForm>
  );
};

export default AddDataModel;
