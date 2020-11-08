import React from 'react';

import { Form, Input, DatePicker, Select } from 'antd';
import { FormInstance } from 'antd/lib/form';
import { TaskStatus } from '@/models/task.d';

import styles from '@/pages/Task/Index.less';
import debounce from 'debounce';

const { RangePicker } = DatePicker;
const { Option } = Select;
export interface IAppProps {
  onSearchChange: (formData: any) => void;
}

export default class TableSearch extends React.Component<IAppProps> {
  inputOnChange = () => {
    if (this.formRef.current) {
      let query: any = {};
      const data = this.formRef.current.getFieldsValue();
      if (data.createdAt) {
        query.startCreateTime = `${data.createdAt[0].format('YYYY-MM-DD')} 00:00:00`;
        query.endCreateTime = `${data.createdAt[1].format('YYYY-MM-DD')} 23:59:59`;
      }
      if (data.locomotiveNo && data.locomotiveNo.length > 0) {
        query.train_number = data.locomotiveNo;
      }
      if (data.trainNo && data.trainNo.length > 0) {
        query.train_id = data.trainNo;
      }
      if (data.driverName && data.driverName.length > 0) {
        query.driver_name = data.driverName;
      }
      if (data.departureDate) {
        query.startMtime = `${data.departureDate[0].format('YYYY-MM-DD')} 00:00:00`;
        query.endMtime = `${data.departureDate[1].format('YYYY-MM-DD')} 23:59:59`;
      }
      if (data.taskStatus != undefined) {
        query.status_code = data.taskStatus;
      }
      this.props.onSearchChange(query);
    }
  };
  formRef = React.createRef<FormInstance>();
  public render() {
    return (
      <div className={styles.from_container}>
        <Form layout="inline" ref={this.formRef} name="control-ref">
          <Form.Item label="创建时间" name="createdAt">
            <RangePicker
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '220px' }}
              allowClear={true}
            />
            {/* <Input
          className={styles.from_input}
          onChange={debounce(this.inputOnChange, 1000)}
        /> */}
          </Form.Item>
          <Form.Item label="机车号" name="locomotiveNo">
            <Input
              className={styles.from_input}
              style={{ width: '100px' }}
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
            />
          </Form.Item>
          <Form.Item label="车次" name="trainNo">
            <Input
              className={styles.from_input}
              allowClear={true}
              style={{ width: '100px' }}
              onChange={debounce(this.inputOnChange, 1000)}
            />
          </Form.Item>
          <Form.Item label="司机" name="driverName">
            <Input
              className={styles.from_input}
              style={{ width: '100px' }}
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
            />
          </Form.Item>
          <Form.Item label="发车时间" name="departureDate">
            <RangePicker
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '220px' }}
            />
          </Form.Item>
          <Form.Item label="任务状态" name="taskStatus">
            <Select
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '120px' }}
              allowClear={true}
            >
              <Option value={TaskStatus.A}>文件上传完成</Option>
              <Option value={TaskStatus.B}>文件转换完成</Option>
              <Option value={TaskStatus.C}>排队中</Option>
              <Option value={TaskStatus.D}>分析中</Option>
              <Option value={TaskStatus.E}>任务结束</Option>
              <Option value={TaskStatus.F}>已停止</Option>
              <Option value={TaskStatus.G}>异常中止</Option>
            </Select>
          </Form.Item>
        </Form>
      </div>
    );
  }
}
