/*
 * @Author: 钟凯
 * @Date: 2021-02-27 10:44:26
 * @LastEditTime: 2021-02-27 22:59:23
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\Model\components\ModelItemTypeButton.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import type { ModalFormProps } from '@ant-design/pro-form';
import { ModalForm } from '@ant-design/pro-form';
import type { ButtonProps } from 'antd';
import { Input } from 'antd';
import { InputNumber } from 'antd';
import { Form, Select } from 'antd';
import { Button } from 'antd';
import React, { useState } from 'react';
import { ItemTypeEnum, ItemTypeOption } from '../../common';
import ModelSelect from '../../components/modelSelect';

interface Props {
  data: API.Model.DataModelItem;
  buttonProps?: ButtonProps;
  modalFormProps: ModalFormProps<API.Model.DataModelItem>;
}

const ModelItemTypeButton = (props: Props & ButtonProps) => {
  const [itemType, setItemType] = useState<API.Model.ItemType>(props.data.itemType);
  const [arrayType, setArrayType] = useState<API.Model.ItemType>(props.data.arrayType || 'string');
  const renderButton = (record: API.Model.DataModelItem) => {
    let { text } = ItemTypeEnum[record.itemType];
    switch (record.itemType) {
      case 'object':
        text = `${ItemTypeEnum[record.itemType].text}(${record.objectRefName || ''})`;
        break;
      case 'array':
        text = ItemTypeEnum[record.itemType].text;
        // eslint-disable-next-line no-case-declarations
        let name;
        // eslint-disable-next-line no-case-declarations
        let start = '[';
        // eslint-disable-next-line no-case-declarations
        let end = ']';
        if (record.arrayType === 'object') {
          name = record.objectRefName;
        } else if (record.arrayType === 'other') {
          name = record.typeValue;
        } else if (record.arrayType) {
          name = ItemTypeEnum[record.arrayType].text;
        } else {
          name = '';
        }
        for (let i = 0; i < (record.arrayDepth ?? 0); i += 1) {
          start += '[';
          end += ']';
        }
        text = `${text}${start}${name}${end}`;
        break;
      case 'number':
        text = `${ItemTypeEnum[record.itemType].text}(${record.precision ?? 0})`;
        break;
      case 'string':
        if (record.length != null && record.length > 0)
          text = `${ItemTypeEnum[record.itemType].text}(${record.length})`;
        break;
      case 'other':
        text = `${ItemTypeEnum[record.itemType].text}(${record.typeValue})`;
        break;
      default:
        break;
    }
    return (
      <Button {...props.buttonProps} type="link">
        {text}
      </Button>
    );
  };

  return (
    <ModalForm<API.Model.DataModelItem>
      {...props.modalFormProps}
      trigger={renderButton(props.data)}
      labelCol={{ span: 4 }}
      title="类型设置"
      layout="horizontal"
    >
      <Form.Item
        label="类型"
        name="itemType"
        rules={[{ required: true, message: '请选择类型!' }]}
        initialValue={itemType}
      >
        <Select
          options={ItemTypeOption}
          autoFocus
          placeholder="请选择类型"
          onChange={(value) => {
            setItemType(value);
          }}
          value={itemType}
        />
      </Form.Item>
      {itemType === 'array' ? (
        <>
          <Form.Item
            label="数组类型"
            name="arrayType"
            initialValue={arrayType}
            rules={[{ required: true, message: '请选择数组类型!' }]}
          >
            <Select
              options={ItemTypeOption}
              placeholder="请选择数组类型"
              onChange={(value) => {
                setArrayType(value);
              }}
              value={arrayType}
            />
          </Form.Item>
          <Form.Item
            label="数组层级"
            name="arrayDepth"
            initialValue={props.data.arrayDepth || 0}
            rules={[{ required: true, message: '请填写数组层级!' }]}
          >
            <InputNumber placeholder="请填写数组层级" style={{ width: '100%' }} />
          </Form.Item>
        </>
      ) : (
        <></>
      )}
      {itemType === 'object' || arrayType === 'object' ? (
        <>
          {props.data.objectRef != null && props.data.objectRefName != null ? (
            <Form.Item
              label="对象类型"
              name="objectRef"
              initialValue={props.data.objectRef}
              rules={[{ required: true, message: '请选择关联数据模型!' }]}
            >
              <ModelSelect
                placeholder="请选择关联数据模型"
                options={[{ label: props.data.objectRefName, value: props.data.objectRef }]}
              />
            </Form.Item>
          ) : (
            <Form.Item
              label="对象类型"
              name="objectRef"
              initialValue={props.data.objectRef}
              rules={[{ required: true, message: '请选择关联数据模型!' }]}
            >
              <ModelSelect placeholder="请选择关联数据模型" />
            </Form.Item>
          )}
        </>
      ) : (
        <></>
      )}
      {itemType === 'number' || arrayType === 'number' ? (
        <>
          <Form.Item
            label="数字精度"
            name="precision"
            initialValue={props.data.precision || 0}
            rules={[{ required: true, message: '请填写数字精度!' }]}
          >
            <InputNumber placeholder="请填写数字精度" style={{ width: '100%' }} />
          </Form.Item>
        </>
      ) : (
        <></>
      )}
      {itemType === 'string' || arrayType === 'string' ? (
        <>
          <Form.Item
            label="文本长度"
            name="length"
            initialValue={props.data.length || 0}
            rules={[{ required: true, message: '请填写文本长度!' }]}
          >
            <InputNumber placeholder="请填写文本长度" style={{ width: '100%' }} />
          </Form.Item>
        </>
      ) : (
        <></>
      )}
      {itemType === 'other' || arrayType === 'other' ? (
        <>
          <Form.Item
            label="自定义类型"
            name="typeValue"
            initialValue={props.data.typeValue}
            rules={[{ required: true, message: '请填自定义类型!' }]}
          >
            <Input placeholder="请填自定义类型" />
          </Form.Item>
        </>
      ) : (
        <></>
      )}
    </ModalForm>
  );
};

export default ModelItemTypeButton;
