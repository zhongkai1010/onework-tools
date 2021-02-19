/*
 * @Author: 钟凯
 * @Date: 2021-02-19 09:51:03
 * @LastEditTime: 2021-02-19 10:45:01
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\EditDataModelModal.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import { ProFormSelect, ProFormText } from '@ant-design/pro-form';
import type { ModalProps } from 'antd';
import { Descriptions } from 'antd';
import { Button, Space } from 'antd';
import { Form, Input, InputNumber, Modal, Select } from 'antd';
import type { FormListFieldData } from 'antd/lib/form/FormList';
import type { LabeledValue } from 'antd/lib/select';
import React, { useState } from 'react';
import { Translate } from '@/utils/translate';
import CollectionSelect from '@/pages/DataModel/components/collectionSelect';
import * as modelServices from '@/services/model/dataModel';
import { useRequest } from 'umi';
import type { ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';

interface Props {
  model: API.Model.DataModel | undefined;
  onClose: () => void;
  onFinish: () => void;
}

export const EditDataModelModal = (props: Props & ModalProps) => {
  const [isEditState, setIsEditState] = useState(false);
  const updateOperate = useRequest(modelServices.update, { manual: true });
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
          <Input allowClear />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '编码' : undefined}
          name={[field.name, 'itemCode']}
          rules={[{ required: true, message: '请选择数据项编码' }]}
          fieldKey={[field.name, 'itemCode']}
        >
          <Input allowClear />
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
          <Select style={{ width: 120 }} allowClear>
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
          <Input allowClear />
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
          label={index === 0 ? '输入类型' : undefined}
          name={[field.name, 'inputType']}
          rules={[{ required: false, message: '请选择行为输入类型' }]}
          initialValue={'void'}
          options={[
            {
              label: '无',
              value: 'void',
            },
            {
              label: '值',
              value: 'value',
            },
            {
              label: '对象',
              value: 'object',
            },
          ]}
        />
        <Form.Item
          {...field}
          label={index === 0 ? '输入类型值' : undefined}
          name={[field.name, 'inputValue']}
          rules={[{ required: false, message: '请填写行为输入类型值' }]}
          fieldKey={[field.name, 'inputValue']}
        >
          <Input allowClear />
        </Form.Item>
        <ProFormSelect
          {...field}
          allowClear
          width={120}
          label={index === 0 ? '输出类型' : undefined}
          name={[field.name, 'outputType']}
          rules={[{ required: false, message: '请选择行为输出类型' }]}
          initialValue={'void'}
          options={[
            {
              label: '无',
              value: 'void',
            },
            {
              label: '值',
              value: 'value',
            },
            {
              label: '对象',
              value: 'object',
            },
          ]}
        />
        <Form.Item
          {...field}
          label={index === 0 ? '输出类型值' : undefined}
          name={[field.name, 'outputValue']}
          rules={[{ required: false, message: '请填写行为输出类型具体值' }]}
          fieldKey={[field.name, 'outputValue']}
        >
          <Input allowClear />
        </Form.Item>
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
  const typeValueEnum = {
    character: { text: '文本' },
    integer: { text: '整型' },
    digital: { text: '数字' },
    boolean: { text: '布尔' },
    enumerate: { text: '枚举' },
    date: { text: '日期' },
  };
  const outputTypeEnum = {
    void: { text: '无' },
    value: { text: '值' },
    object: { text: '对象' },
  };
  const itemColumns: ProColumns<API.Model.DataModelItem>[] = [
    {
      title: '编码',
      dataIndex: 'itemCode',
    },
    {
      title: '名称',
      dataIndex: 'itemName',
    },
    {
      title: '类型',
      dataIndex: 'itemType',
      valueEnum: typeValueEnum,
    },
    {
      title: '是否为空',
      dataIndex: 'isNull',
      renderText: (text: any) => {
        return text ? '是' : '否';
      },
    },
    {
      title: '长度',
      dataIndex: 'length',
    },
    {
      title: '精度',
      dataIndex: 'precision',
    },
  ];
  const behaviorColumns: ProColumns<API.Model.DataModelBehavior>[] = [
    {
      title: '名称',
      dataIndex: 'behaviorName',
    },
    {
      title: '名称',
      dataIndex: 'behaviorCode',
    },
    {
      title: '输入类型',
      dataIndex: 'outputType',
      render: (text: any, record: any) => {
        const inputs = record.inputs || [];
        if (inputs === 0) return null;
        return outputTypeEnum[inputs[0].type].text;
      },
    },
    {
      title: '输入类型值',
      dataIndex: 'outputValue',
      render: (text: any, record: any) => {
        const inputs = record.inputs || [];
        if (inputs === 0) return null;
        return inputs[0].value;
      },
    },
    {
      title: '输出类型',
      dataIndex: 'outputType',
      valueEnum: outputTypeEnum,
    },
    {
      title: '输出类型值',
      dataIndex: 'outputValue',
    },
    {
      title: '描述',
      ellipsis: true,
      dataIndex: 'description',
    },
  ];
  return (
    <Modal
      {...props}
      width="80%"
      title={isEditState ? '编辑数据模型' : '查看详情'}
      onCancel={() => {
        props.onClose();
        setIsEditState(false);
      }}
      okButtonProps={{
        loading: updateOperate.loading,
      }}
    >
      {isEditState ? (
        <Form {...props} title="新建数据模型" layout="vertical" form={form}>
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
          <Form.Item label="行为">
            <Form.List name="behaviors">
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
                      onClick={() => add({ items: [] })}
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
                  ...props.model,
                  // items: props.collection?.items.map((t) => t.uid),
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
            {props.model?.name}
          </Descriptions.Item>
          <Descriptions.Item label="编码" span={3}>
            {props.model?.code}
          </Descriptions.Item>
          <Descriptions.Item label="描述" span={3}>
            {props.model?.description}
          </Descriptions.Item>
          <Descriptions.Item label="数据项" span={3}>
            <ProTable<API.Model.DataModelItem>
              key={`${props.model?.uid}_items`}
              dataSource={props.model?.items || []}
              pagination={false}
              options={false}
              search={false}
              columns={itemColumns}
            />
          </Descriptions.Item>
          <Descriptions.Item label="行为" span={3}>
            <ProTable<API.Model.DataModelBehavior>
              key={`${props.model?.uid}_behaviors`}
              dataSource={props.model?.behaviors || []}
              pagination={false}
              options={false}
              search={false}
              columns={behaviorColumns}
            />
          </Descriptions.Item>
        </Descriptions>
      )}
    </Modal>
  );
};
