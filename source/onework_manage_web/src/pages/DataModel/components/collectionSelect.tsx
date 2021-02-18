/*
 * @Author: 钟凯
 * @Date: 2021-02-18 21:55:44
 * @LastEditTime: 2021-02-18 23:18:13
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\components\collectionSelect.tsx
 * @可以输入预定的版权声明、个性签名、空行等
 */
import type { SelectProps } from 'antd';
import { Spin } from 'antd';
import { Select } from 'antd';
import React, { useState } from 'react';
import { useRequest } from 'umi';
import * as collectionServices from '@/services/model/collection';
import debounce from 'debounce';

// eslint-disable-next-line @typescript-eslint/no-empty-interface
interface Props {}
// const { Option } = Select;

const CollectionSelect = (props: Props & SelectProps<any>) => {
  const [options, setOptions] = useState(props.options ?? []);
  const searchOperate = useRequest(collectionServices.search, { manual: true });
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
            data.map((t: API.Model.Collection) => {
              return {
                 ...t,
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

export default CollectionSelect;
