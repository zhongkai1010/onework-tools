import React from 'react';
import { useRequest } from 'umi';
import { Select } from 'antd';
import * as services from '@/services/line';
import { SelectProps } from 'antd/es/select';

export interface IAppProps {}

export interface OptionData {
  id: number;
  name: string;
  work_id: string;
}
const { Option } = Select;

const RouteSelect: React.FC<IAppProps & SelectProps<any>> = (props) => {
  const { data } = useRequest(() => {
    return services.getLineSelectData();
  });

  const renderOption = (item: Array<OptionData> = []) => {
    return item.map((value, index) => {
      return (
        <Option key={index} value={value.id}>
          {value.name}
        </Option>
      );
    });
  };

  if (data) {
    return <Select {...props}>{renderOption(data)}</Select>;
  } else {
    return <Select {...props}>{props.children}</Select>;
  }
};
export default RouteSelect;
