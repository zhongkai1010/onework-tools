/*
 * @Author: 钟凯
 * @Date: 2021-02-19 09:51:03
 * @LastEditTime: 2021-02-28 01:11:01
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\EditDataModelModal.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import type { ModalFormProps } from '@ant-design/pro-form';
import { ModalForm, ProFormSelect, ProFormText } from '@ant-design/pro-form';
import { Descriptions } from 'antd';
import { Button, Space } from 'antd';
import { Form, Input, Select } from 'antd';
import type { FormListFieldData } from 'antd/lib/form/FormList';
import type { LabeledValue } from 'antd/lib/select';
import React, { useEffect, useState } from 'react';
import { Translate } from '@/utils/translate';
import CollectionSelect from '@/pages/DataModel/components/collectionSelect';
import type { ProColumns } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';
import {
  BehaviorOperationTypeEnum,
  BehaviorOperationTypeOption,
  BoolTypeOption,
  ItemTypeEnum,
  ItemTypeOption,
  ModelUseOption,
} from '../../common';

interface Props {
  data: API.Model.DataModel | undefined;
  modalFormProps: ModalFormProps;
}

export const EditDataModelModal = (props: Props) => {
  const [isEditState, setIsEditState] = useState(false);
  const [form] = Form.useForm();
  useEffect(() => {
    if (isEditState) {
      form.setFieldsValue(props.data);
    }
  }, [form, isEditState, props.data]);

  const renderItem = (field: FormListFieldData, index: number) => {
    return (
      <>
        <Form.Item
          {...field}
          label={index === 0 ? '名称' : undefined}
          name={[field.name, 'name']}
          rules={[{ required: true, message: '请填写数据模型名称' }]}
          fieldKey={[field.name, 'name']}
        >
          <Input allowClear autoFocus placeholder="请填写数据模型名称" />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '编码' : undefined}
          name={[field.name, 'code']}
          rules={[{ required: true, message: '请填写数据模型编码' }]}
          fieldKey={[field.name, 'code']}
        >
          <Input allowClear placeholder="请填写数据模型编码" />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '类型' : undefined}
          rules={[{ required: true, message: '请选择数据项类型' }]}
          name={[field.name, 'itemType']}
          fieldKey={[field.name, 'itemType']}
        >
          <Select style={{ width: 120 }} placeholder="请选择数据项类型" options={ItemTypeOption} />
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
          <Input allowClear placeholder="请选择行为名称" />
        </Form.Item>
        <Form.Item
          {...field}
          label={index === 0 ? '编码' : undefined}
          name={[field.name, 'code']}
          rules={[{ required: true, message: '请填写行为编码' }]}
          fieldKey={[field.name, 'code']}
        >
          <Input allowClear placeholder="请填写行为编码" />
        </Form.Item>
        <ProFormSelect
          {...field}
          allowClear
          width={120}
          label={index === 0 ? '操作类型' : undefined}
          name={[field.name, 'operationType']}
          rules={[{ required: false, message: '请选择行为操作类型' }]}
          initialValue={BehaviorOperationTypeOption[0].value}
          placeholder="请选择行为操作类型"
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
  const itemColumns: ProColumns<API.Model.DataModelItem>[] = [
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
      dataIndex: 'itemType',
      valueEnum: ItemTypeEnum,
    },
  ];
  const behaviorColumns: ProColumns<API.Model.DataModelBehavior>[] = [
    {
      title: '名称',
      dataIndex: 'name',
    },
    {
      title: '编码',
      dataIndex: 'code',
    },
    {
      title: '操作类型',
      dataIndex: 'operationType',
      valueEnum: BehaviorOperationTypeEnum,
    },
    {
      title: '描述',
      ellipsis: true,
      dataIndex: 'description',
    },
  ];

  return (
    <ModalForm
      {...props.modalFormProps}
      trigger={<a key="show">查看详情</a>}
      width="60%"
      title={isEditState ? '编辑数据模型' : '查看详情'}
      layout="vertical"
      form={form}
      onVisibleChange={(visible: boolean) => {
        if (!visible) {
          setIsEditState(false);
        }
      }}
    >
      {isEditState ? (
        <>
         
          <Form.Item
            label="名称"
            name="name"
            rules={[{ required: true, message: '请输入数据模型名称' }]}
            initialValue={props.data?.name}
          >
            <Input.Search
              placeholder="请输入数据模型名称"
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
            initialValue={props.data?.code}
          />
          <ProFormSelect
            label="用途"
            name="use"
            rules={[
              {
                required: true,
                message: '请选择数据模型用途',
              },
            ]}
            placeholder="请选择数据模型用途"
            initialValue={props.data?.use}
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
            <Form.List name="items" initialValue={props.data?.items}>
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
            <Form.List name="behaviors" initialValue={props.data?.behaviors}>
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
          <ProFormText
            label="描述"
            initialValue={props.data?.description}
            name="description"
            rules={[
              {
                required: false,
                message: '请填写数据模型描述',
              },
            ]}
            placeholder="请填写数据模型描述"
          />
        </>
      ) : (
        <Descriptions
          title="数据模型"
          bordered
          extra={
            <Button
              type="primary"
              onClick={() => {
                setIsEditState(true);
              }}
            >
              编辑
            </Button>
          }
          labelStyle={{ width: '120px' }}
        >
          <Descriptions.Item label="名称" span={3}>
            {props.data?.name}
          </Descriptions.Item>
          <Descriptions.Item label="编码" span={3}>
            {props.data?.code}
          </Descriptions.Item>
          <Descriptions.Item label="描述" span={3}>
            {props.data?.description}
          </Descriptions.Item>
          <Descriptions.Item label="数据项" span={3}>
            <ProTable<API.Model.DataModelItem>
              key={`${props.data?.uid}_items`}
              rowKey="uid"
              dataSource={props.data?.items || []}
              pagination={false}
              options={false}
              search={false}
              columns={itemColumns}
            />
          </Descriptions.Item>
          <Descriptions.Item label="行为" span={3}>
            <ProTable<API.Model.DataModelBehavior>
              key={`${props.data?.uid}_behaviors`}
              rowKey="uid"
              dataSource={props.data?.behaviors || []}
              pagination={false}
              options={false}
              search={false}
              columns={behaviorColumns}
            />
          </Descriptions.Item>
        </Descriptions>
      )}
    </ModalForm>
  );
};
