/*
 * @Author: 钟凯
 * @Date: 2021-03-12 10:35:01
 * @LastEditTime: 2021-03-15 10:48:19
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\EditConnectionModal.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { PlusSquareOutlined } from '@ant-design/icons';
import type { ModalFormProps } from '@ant-design/pro-form';
import { ModalForm } from '@ant-design/pro-form';
import { Col, Form, Input, InputNumber, Row, Select, Button } from 'antd';
import React from 'react';

const { Option } = Select;

interface Props {
  data?: API.DataBase.Connection;
}

const EditConnectionModal = (props: Props & ModalFormProps) => {
  return (
    <ModalForm
      title="新增数据连接"
      trigger={
        <Button
          title="添加连接"
          icon={<PlusSquareOutlined />}
          style={{ cursor: 'pointer', border: 0 }}
        ></Button>
      }
      {...props}
    >
      <Row>
        <Col span={24}>
          <Form.Item
            label="连接名称"
            name="name"
            rules={[{ required: true, message: '请填写数据连接名称！' }]}
            initialValue={props.data?.name}
          >
            <Input autoFocus placeholder="请填写数据连接名称" />
          </Form.Item>
        </Col>
      </Row>
      <Row gutter={8}>
        <Col span={8}>
          <Form.Item
            label="数据库类型"
            name="dbType"
            rules={[{ required: true, message: '请选择数据库类型！' }]}
            initialValue={props.data?.dbType}
          >
            <Select placeholder="请选择数据库类型">
              <Option value="mysql">mysql</Option>
              <Option value="mariadb">mariadb</Option>
              <Option value="postgres">postgres</Option>
              <Option value="mssql">mssql</Option>
            </Select>
          </Form.Item>
        </Col>
        <Col span={8}>
          <Form.Item
            label="主机地址"
            name="host"
            rules={[{ required: true, message: '请填写主机地址!' }]}
            initialValue={props.data?.host}
          >
            <Input placeholder="请填写主机地址" />
          </Form.Item>
        </Col>
        <Col span={8}>
          <Form.Item
            label="端口"
            name="port"
            initialValue={props.data?.port}
            rules={[{ required: true, message: '请填写数据库访问端口!' }]}
          >
            <InputNumber
              placeholder="请填写数据库访问端口"
              precision={0}
              style={{ width: '240px' }}
            />
          </Form.Item>
        </Col>
      </Row>
      <Row gutter={12}>
        <Col span={12}>
          <Form.Item
            label="用户名"
            name="username"
            rules={[{ required: true, message: '请填写数据连接名称！' }]}
            initialValue={props.data?.username}
          >
            <Input />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item
            label="密码"
            name="password"
            rules={[{ required: true, message: '请填写数据连接名称！' }]}
            initialValue={props.data?.password}
          >
            <Input.Password />
          </Form.Item>
        </Col>
      </Row>

      <Row>
        <Col span={24}>
          <Form.Item label="默认数据库" name="database" initialValue={props.data?.database}>
            <Input />
          </Form.Item>
        </Col>
      </Row>

      <Row>
        <Col span={24}>
          <Form.Item label="配置" name="config" initialValue={props.data?.config}>
            <Input.TextArea />
          </Form.Item>
        </Col>
      </Row>
      <Row>
        <Col span={24}>
          <Form.Item label="描述" name="description" initialValue={props.data?.description}>
            <Input.TextArea />
          </Form.Item>
        </Col>
      </Row>
    </ModalForm>
  );
};

export default EditConnectionModal;
