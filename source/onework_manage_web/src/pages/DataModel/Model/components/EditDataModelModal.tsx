/*
 * @Author: 钟凯
 * @Date: 2021-02-19 09:51:03
 * @LastEditTime: 2021-02-22 17:25:19
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
import {
  BehaviorOperationTypeEnum,
  BehaviorOperationTypeOption,
  BoolTypeOption,
  ItemTypeEnum,
  ItemTypeOption,
  ModelUseOption,
} from '../../common';

interface Props {
  model: API.Model.DataModel | undefined;
  onClose: () => void;
  onFinish: () => void;
}

export const EditDataModelModal = (props: Props & ModalProps) => {
  const [isEditState, setIsEditState] = useState(false);
  const updateOperate = useRequest(modelServices.update, { manual: true, throwOnError: true });
  const [form] = Form.useForm();
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
    {
      title: '是否标识',
      dataIndex: 'isUnique',
      renderText: (text: any) => {
        return text ? '是' : '否';
      },
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
    <Modal
      {...props}
      width="80%"
      title={isEditState ? '编辑数据模型' : '查看详情'}
      onCancel={() => {
        props.onClose();
        setIsEditState(false);
      }}
      onOk={() => {
        if (isEditState) {
          form.validateFields().then((values) => {
            const dataModel = { ...props.model, ...values };

            dataModel.items = values.items.map((t: any) => {
              return { ...t, isNull: t.isNull === 'true', isUnique: t.isUnique === 'true' };
            });
            dataModel.behaviors = values.behaviors.map((t: any) => {
              return {
                ...t,
              };
            });
            updateOperate.run(dataModel).then(() => {
              setIsEditState(false);
              props.onFinish();
            });
          });
        } else {
          props.onClose();
        }
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
            rules={[{ required: true, message: '请输入数据模型名称' }]}
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
            name="description"
            rules={[
              {
                required: false,
                message: '请填写数据模型描述',
              },
            ]}
            placeholder="请填写数据模型描述"
          />
        </Form>
      ) : (
        <Descriptions
          title="数据模型"
          bordered
          extra={
            <Button
              type="primary"
              onClick={() => {
                let items = props.model?.items as any[];
                items = items?.map((t) => {
                  return { ...t, isNull: String(t.isNull), isUnique: String(t.isUnique) };
                });
                form.setFieldsValue({
                  ...props.model,
                  items,
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
              rowKey="uid"
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
              rowKey="uid"
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
