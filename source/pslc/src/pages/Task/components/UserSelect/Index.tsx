import React from 'react';
import { useRequest } from 'umi';
import { Select } from 'antd';
import * as services from '@/services/user';
import { SelectProps } from 'antd/es/select';

export interface IAppProps {}

export interface OptionData {
  id: number;
  name: string;
  work_id: string;
}
const { Option } = Select;

const UserSelect: React.FC<IAppProps & SelectProps<any>> = (props) => {
  const { data } = useRequest(() => {
    return services.getUserSelectData();
  });
  const renderOption = (item: Array<OptionData> = []) => {
    return item.map((value) => {
      return <Option value={value.id}>{value.name}</Option>;
    });
  };
  console.log('UserSelect', renderOption(data));
  if (data) {
    return <Select {...props}>{renderOption(data)}</Select>;
  } else {
    return <Select {...props}>{props.children}</Select>;
  }
};
export default UserSelect;
