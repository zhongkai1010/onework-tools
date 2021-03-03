/*
 * @Author: 钟凯
 * @Date: 2021-02-18 08:16:02
 * @LastEditTime: 2021-03-03 16:39:27
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\components\ItemSelect.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import type { SelectProps } from 'antd';
import { Spin } from 'antd';
import { Select } from 'antd';
import React, { useState } from 'react';
import { useRequest } from 'umi';
import * as itemServices from '@/pages/DataModel/services/item';
import debounce from 'debounce';

// eslint-disable-next-line @typescript-eslint/no-empty-interface
interface Props {}
// const { Option } = Select;

const ItemSelect = (props: Props & SelectProps<any>) => {
  const [options, setOptions] = useState(props.options ?? []);
  const searchOperate = useRequest(itemServices.search, { manual: true });
  // const renderOption = (items: API.Model.Item[] = []) => {
  //   return items.map((t) => <Option value={t.uid}>{t.name}</Option>);
  // };
  return (
    <Select
      {...props}
      showSearch
      showArrow={false}
      filterOption={false}
      options={options}
      defaultActiveFirstOption={false}
      notFoundContent={searchOperate.loading ? <Spin size="small" /> : null}
      onSearch={debounce((value: string) => {
        if (value.trim().length === 0) return;
        searchOperate.run({ keyword: value }).then((data) => {
          setOptions(
            data.map((t: API.Model.Item) => {
              return {
                // ...t,
                label: t.name,
                value: t.uid,
               
              };
            }),
          );
        });
      }, 800)}
    />
  );
};

export default ItemSelect;
