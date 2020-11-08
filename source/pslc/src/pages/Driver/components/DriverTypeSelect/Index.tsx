import * as React from 'react';
import { SelectProps } from 'antd/lib/select';
import { Select } from 'antd';
import { DriverType } from '@/models/user.d';

const { Option } = Select;

interface IAppProps {}

const DriverTypeSelect: React.FunctionComponent<IAppProps & SelectProps<any>> = (props) => {
  return (
    <Select {...props}>
      <Option value={DriverType.A}>主司机 </Option>
      <Option value={DriverType.B}>副司机</Option>
      <Option value={DriverType.C}>值班员</Option>
      <Option value={DriverType.D}>机车调度员</Option>
      <Option value={DriverType.E}>队长</Option>
      <Option value={DriverType.F}>支部司机</Option>
      <Option value={DriverType.G}>指导司机</Option>
      <Option value={DriverType.H}>扳道员</Option>
    </Select>
  );
};

export default DriverTypeSelect;
