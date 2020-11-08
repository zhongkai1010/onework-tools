import React from 'react';
import { Form, Input } from 'antd';
import { FormInstance } from 'antd/lib/form';
import styles from '@/pages/Task/Index.less';
import debounce from 'debounce';
import DriverTypeSelect from '@/pages/Driver/components/DriverTypeSelect/Index';

export interface IAppProps {
  onSearchChange: (formData: any) => void;
}

export default class TableSearch extends React.Component<IAppProps> {
  inputOnChange = () => {
    if (this.formRef.current) {
      let query: any = {};
      const data = this.formRef.current.getFieldsValue();
      query = {
        work_id: data.work_id,
        name: data.name,
        user_type: data.user_type,
        work_group: data.work_group,
        teacher_group: data.teacher_group,
      };
      this.props.onSearchChange(query);
    }
  };
  formRef = React.createRef<FormInstance>();
  public render() {
    return (
      <div className={styles.from_container}>
        <Form layout="inline" ref={this.formRef} name="control-ref">
          <Form.Item label="工号" name="work_id">
            <Input
              className={styles.from_input}
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '120px' }}
            />
          </Form.Item>
          <Form.Item label="姓名" name="name">
            <Input
              className={styles.from_input}
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '120px' }}
              allowClear={true}
            />
          </Form.Item>
          <Form.Item label="职名" name="user_type">
            <DriverTypeSelect
              className={styles.from_input}
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '120px' }}
            />
          </Form.Item>
          <Form.Item label="车队" name="work_group">
            <Input
              className={styles.from_input}
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '120px' }}
            />
          </Form.Item>
          <Form.Item label="指导组" name="teacher_group">
            <Input
              className={styles.from_input}
              allowClear={true}
              onChange={debounce(this.inputOnChange, 1000)}
              style={{ width: '120px' }}
            />
          </Form.Item>
        </Form>
      </div>
    );
  }
}
