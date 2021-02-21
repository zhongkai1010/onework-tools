/*
 * @Author: 钟凯
 * @Date: 2021-02-18 21:41:50
 * @LastEditTime: 2021-02-21 22:57:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\AddDataModelModal.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import type { ModalFormProps } from '@ant-design/pro-form';
import { ModalForm, ProFormSelect, ProFormText } from '@ant-design/pro-form';
import { Button, Form, Input, InputNumber, Select, Space } from 'antd';
import { Translate } from '@/utils/translate';
import CollectionSelect from '@/pages/DataModel/components/collectionSelect';
import React from 'react';
import type { LabeledValue } from 'antd/lib/select';
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import type { FormListFieldData } from 'antd/lib/form/FormList';
import {
  BehaviorOperationTypeEnum,
  BehaviorOperationTypeOption,
  BoolTypeOption,
  ItemTypeOption,
  ModelUseOption,
} from '../../common';

const AddDataModelModal = (props: ModalFormProps) => {
  const [form] = Form.useForm();
  const renderItem = (field: FormListFieldData, index: number) => {
    return (
      <>
        <Form.Item
          {...field}
          label={index === 0 ? '名称' : undefined}
          name={[field.name, 'name']}
          rules={[{ required: true, message: '请填写数据项名称' }]}
          fieldKey={[field.name, 'name']}
        >
          <Input allowClear autoFocus placeholder="请填写数据项名称" />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '编码' : undefined}
          name={[field.name, 'code']}
          rules={[{ required: true, message: '请填写数据项编码' }]}
          fieldKey={[field.name, 'code']}
        >
          <Input allowClear placeholder="请填写数据项编码" />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '类型' : undefined}
          rules={[{ required: true, message: '请选择数据项类型' }]}
          name={[field.name, 'itemType']}
          fieldKey={[field.name, 'itemType']}
        >
          <Select style={{ width: 120 }} options={ItemTypeOption} placeholder="请选择数据项类型" />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '是否为空' : undefined}
          rules={[{ required: false, message: '请选择数据项是否为空' }]}
          name={[field.name, 'isNull']}
          fieldKey={[field.name, 'isNull']}
        >
          <Select style={{ width: 120 }} allowClear options={BoolTypeOption} />
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
          <Input allowClear />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '是否标识' : undefined}
          name={[field.name, 'isUnique']}
          fieldKey={[field.name, 'isUnique']}
        >
          <Select style={{ width: 120 }} allowClear options={BoolTypeOption} />
        </Form.Item>
      </>
    );
  };
  const renderBehavior = (field: FormListFieldData, index: number) => {
    return (
      <>
        <Form.Item
          {...field}
          label={index === 0 ? '名称' : undefined}
          name={[field.name, 'name']}
          rules={[{ required: true, message: '请选择行为名称' }]}
          fieldKey={[field.name, 'name']}
        >
          <Input allowClear />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '编码' : undefined}
          name={[field.name, 'code']}
          rules={[{ required: true, message: '请填写行为编码' }]}
          fieldKey={[field.name, 'code']}
        >
          <Input allowClear />
        </Form.Item>

        <ProFormSelect
          {...field}
          allowClear
          width={120}
          label={index === 0 ? '操作类型' : undefined}
          name={[field.name, 'operationType']}
          rules={[{ required: false, message: '请选择行为操作类型' }]}
          initialValue={'void'}
          options={BehaviorOperationTypeOption}
        />

        <Form.Item
          {...field}
          label={index === 0 ? '描述' : undefined}
          name={[field.name, 'description']}
          rules={[{ required: false, message: '请填写行为描述' }]}
          fieldKey={[field.name, 'description']}
        >
          <Input allowClear />
        </Form.Item>
      </>
    );
  };
  return (
    <ModalForm
      {...props}
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
        rules={[{ required: true, message: '请输入数据模型名称' }]}
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
          autoFocus
          placeholder="请输入数据模型名称"
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
        placeholder="请填写数据模型编码"
      />
      <ProFormSelect
        label="类型"
        name="use"
        rules={[
          {
            required: true,
            message: '请选择数据模型类型',
          },
        ]}
        placeholder="请选择数据模型类型"
        initialValue={ModelUseOption[0].value}
        options={ModelUseOption}
      />
      <Form.Item label="数据集">
        <CollectionSelect
          mode="multiple"
          onChange={(_value, option: any) => {
            const values = form.getFieldsValue();
            const items = values.items || [];
            // 获取选中的数据集
            const collections = option as (API.Model.Collection & LabeledValue)[];
            for (let i = 0; i < collections.length; i += 1) {
              const collection = collections[i];
              // 遍历选中的数据集中的数据项
              for (let j = 0; j < collection.items.length; j += 1) {
                const item = collection.items[j];
                // 判断表单中数据项名称是否出现重复，不重复加入表单中
                if (items.filter((t: any) => t.name === item.name).length === 0) {
                  items.push({
                    name: item.name,
                    code: item.code,
                    itemType: item.type,
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
                  onClick={() =>
                    add({
                      itemType: ItemTypeOption[0].value,
                      isNull: BoolTypeOption[0].value,
                      length: 0,
                      precision: 0,
                      isUnique: BoolTypeOption[1].value,
                    })
                  }
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
      <Form.Item label="行为">
        <Form.List
          name="behaviors"
          initialValue={[
            { name: '查询', code: 'GetList', operationType: BehaviorOperationTypeEnum.read.value },
            { name: '新增', code: 'Insert', operationType: BehaviorOperationTypeEnum.add.value },
            { name: '修改', code: 'Update', operationType: BehaviorOperationTypeEnum.update.value },
            { name: '移除', code: 'Remove', operationType: BehaviorOperationTypeEnum.delete.value },
          ]}
        >
          {(fields, { add, remove }) => (
            <>
              {fields.map((field, index) => (
                <Space key={field.key} align="baseline">
                  {renderBehavior(field, index)}
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
                  onClick={() => add({ operationType: BehaviorOperationTypeOption[0].value })}
                  block
                  icon={<PlusOutlined />}
                >
                  添加行为
                </Button>
              </Form.Item>
            </>
          )}
        </Form.List>
      </Form.Item>
    </ModalForm>
  );
};

export default AddDataModelModal;
