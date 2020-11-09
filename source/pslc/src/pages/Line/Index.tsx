import React, { useState } from 'react';
import { useRequest } from 'umi';
import { Row, Col, Button, Table, message, Modal, Form, Input, InputNumber } from 'antd';
import { PlusOutlined, CopyOutlined, HddOutlined, DeleteOutlined } from '@ant-design/icons';
import { Line } from '@/models/line.d';
import { TableColumns } from './Config';
import styles from './Index.less';
import * as services from '@/services/line';
import { FormInstance } from 'antd/lib/form';

const Index = () => {
  let formRef = React.createRef<FormInstance>();
  const [selectLine, setSelectLine] = useState<Line | null>(null);
  const [createvisible, setCreatevisible] = useState<boolean | undefined>(false);
  const { loading, data, run } = useRequest((params = { page: 1, limit: 10 }) => {
    return services.lineGetList(params);
  });
  const [pageState, setPageState] = useState<any>({ page: 1, limit: 10 });
  const createOperate = useRequest(services.lineCreate, { manual: true });
  const copyOperate = useRequest(services.lineCopy, { manual: true });
  const deleteOperate = useRequest(services.lineDelete, { manual: true });
  const tableOnSelect = (value: Line) => {
    setSelectLine(value);
  };
  const paginationOnChange = (page: number, pageSize?: number) => {
    setPageState((value: any) => {
      value.page = page;
      value.limit = pageSize;
      return value;
    });
    run(pageState);
  };
  const onCreateButtonClick = () => {
    setCreatevisible(true);
  };
  const onCopyButtonClick = () => {
    if (selectLine == null) {
      message.info('请选择一行数据进行操作。');
    } else {
      copyOperate.run({ id: selectLine.id }).then(() => {
        message.info('复制成功。');
        run(pageState);
      });
    }
  };
  const onDeleteButtonClick = () => {
    if (selectLine == null) {
      message.info('请选择一行数据进行操作。');
    } else {
      deleteOperate.run({ id: selectLine.id }).then(() => {
        message.info('删除成功。');
        run(pageState);
      });
      setSelectLine(null);
    }
  };
  const onShowButtonClick = () => {
    if (selectLine == null) {
      message.info('请选择一行数据进行操作。');
    }
  };
  const onOk = () => {
    if (formRef.current) {
      const fromData = formRef.current.getFieldsValue();
      createOperate.run(fromData).then(() => {
        message.info('新增成功。');
        setCreatevisible(false);
        run(pageState);
      });
    }
  };
  const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 20 },
  };
  return (
    <>
      <Modal
        destroyOnClose={true}
        title="新增线路"
        visible={createvisible}
        onCancel={() => setCreatevisible(false)}
        onOk={onOk}
      >
        <Form {...layout} name="basic" initialValues={{ remember: true }} ref={formRef}>
          <Form.Item
            label="起始站"
            name="initial_station"
            rules={[{ required: true, message: '请填写起始站。' }]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            label="终点站"
            name="terminal_station"
            rules={[{ required: true, message: '请填写终点站。' }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            label="全长(km)"
            name="mileage"
            rules={[{ required: true, message: '请填写总里程。' }]}
          >
            <InputNumber />
          </Form.Item>
        </Form>
      </Modal>
      <Row>
        <Col span={24} className={styles.tools_container}>
          <Button
            size="large"
            icon={<PlusOutlined style={{ color: '#ccc' }} />}
            onClick={onCreateButtonClick}
          >
            新线路
          </Button>
          <Button
            style={{ marginRight: '10px' }}
            size="large"
            icon={<CopyOutlined style={{ color: '#7FD154' }} />}
            onClick={onCopyButtonClick}
          >
            复制
          </Button>
          <Button
            size="large"
            icon={<DeleteOutlined style={{ color: '#7667C8' }} />}
            onClick={onDeleteButtonClick}
          >
            删除
          </Button>
          <Button
            size="large"
            icon={<HddOutlined style={{ color: '#35C9BA' }} />}
            onClick={onShowButtonClick}
          >
            查看详情
          </Button>
        </Col>
        <Col span={24} className={styles.table_container}>
          <Table
            rowKey="id"
            columns={TableColumns}
            scroll={{ y: '45vh', scrollToFirstRowOnChange: true }}
            loading={loading}
            rowSelection={{
              onSelect: tableOnSelect,
              type: 'radio',
            }}
            dataSource={data ? data.data : []}
            pagination={{
              showSizeChanger: true,
              showQuickJumper: true,
              total: data ? data.total : 0,
              showTotal: (total) => `共${total}条`,
              onChange: paginationOnChange,
            }}
          />
        </Col>
      </Row>
    </>
  );
};

export default Index;
