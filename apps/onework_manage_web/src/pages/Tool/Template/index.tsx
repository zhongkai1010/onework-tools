/*
 * @Author: 钟凯
 * @Date: 2021-03-24 09:38:10
 * @LastEditTime: 2021-03-26 09:55:19
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\Tool\Template\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import React, { useEffect, useState } from 'react';
import { PageContainer } from '@ant-design/pro-layout';
import { Row, Col, Tree, Form } from 'antd';
import { templateGetList, addComparison, updateComparison, deleteComparison } from '../services';
import { useRequest } from 'umi';
import IconButton from '@/components/IconButton';
import ProForm, { ProFormList, ProFormText } from '@ant-design/pro-form';
import ProCard from '@ant-design/pro-card';
import { DeleteOutlined, PlusOutlined } from '@ant-design/icons';
import styles from './index.less';

export default () => {
  const templateGetListOperate = useRequest(templateGetList, {
    throwOnError: true,
  });
  const addComparisonOperate = useRequest(addComparison, {
    manual: true,
    throwOnError: true,
  });
  const updateComparisonOperate = useRequest(updateComparison, {
    manual: true,
    throwOnError: true,
  });
  const deleteComparisonOperate = useRequest(deleteComparison, {
    manual: true,
    throwOnError: true,
  });
  const [selectComparison, setSelectComparison] = useState<API.Tool.Template>();
  const [comparisonData, setComparisonData] = useState<API.Tool.Template[]>([]);
  const [form] = Form.useForm();
  useEffect(() => {
    setComparisonData(templateGetListOperate.data || []);
    return () => {
      setComparisonData([]);
    };
  }, [templateGetListOperate.data]);

  useEffect(() => {
    if (selectComparison) {
      form.setFieldsValue(selectComparison);
    } else {
      form.setFieldsValue({ name: '', code: '', datas: [] });
    }
  }, [selectComparison]);

  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <Row gutter={18}>
        <Col span={4}>
          <ProCard
            bordered
            headerBordered
            key="treeCard"
            title="字符模板"
            loading={templateGetListOperate.loading}
            extra={[
              <IconButton
                key="add"
                title="新增"
                icon={<PlusOutlined />}
                onClick={async () => {
                  setSelectComparison(undefined);
                  return Promise.resolve();
                }}
              />,
              <IconButton
                key="load"
                title="刷新"
                onClick={async () => {
                  return await templateGetListOperate.run();
                }}
              />,
            ]}
          >
            <Tree
              blockNode
              defaultCheckedKeys={selectComparison ? [selectComparison.uid] : undefined}
              selectedKeys={selectComparison ? [selectComparison.uid] : undefined}
              onSelect={(_selectedKeys, { node }) => {
                const temp = (node as unknown) as { source: API.Tool.Template };
                setSelectComparison(temp.source);
              }}
              treeData={comparisonData.map((t: API.Tool.Template) => {
                return {
                  key: t.uid,
                  title: t.name,
                  source: t,
                };
              })}
            ></Tree>
          </ProCard>
        </Col>
        <Col span={20}>
          <ProCard
            bordered
            colSpan={24}
            split="vertical"
            headerBordered
            title={selectComparison ? `${selectComparison?.name}` : '新增对照表'}
            extra={
              selectComparison ? (
                <IconButton
                  key="delete"
                  title="删除"
                  icon={<DeleteOutlined />}
                  onClick={async () => {
                    await deleteComparisonOperate.run([selectComparison.uid]);
                    const data = comparisonData.filter((t) => t.uid !== selectComparison.uid);
                    setComparisonData(data);
                    setSelectComparison(undefined);
                    return Promise.resolve();
                  }}
                />
              ) : (
                <></>
              )
            }
          >
            <ProCard>
              <ProForm
                form={form}
                onFinish={async (data: API.Tool.Comparison) => {
                  if (selectComparison) {
                    const newData = await updateComparisonOperate.run({
                      ...selectComparison,
                      ...data,
                    });
                    form.setFieldsValue(newData);
                    /// TODO 需要替换comparisonData旧数据
                  } else {
                    await addComparisonOperate.run({ ...data });
                    /// TODO 需要加入comparisonData旧数据
                  }
                  return Promise.resolve(true);
                }}
              >
                <ProFormText name="name" label="名称" rules={[{ required: true }]} />
                <ProFormText name="code" label="编码" rules={[{ required: true }]} />
                <ProFormList name="datas" copyIconProps={false}>
                  <ProForm.Group size={8}>
                    <ProFormText
                      name="key"
                      label="key值"
                      rules={[{ required: true }]}
                      fieldProps={{
                        className: styles.input,
                      }}
                    />
                    <ProFormText
                      name="value"
                      label="value值"
                      rules={[{ required: true }]}
                      fieldProps={{
                        className: styles.input,
                      }}
                    />
                  </ProForm.Group>
                </ProFormList>
              </ProForm>
            </ProCard>
          </ProCard>
        </Col>
      </Row>
    </PageContainer>
  );
};
