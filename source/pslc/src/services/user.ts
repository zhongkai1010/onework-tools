/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-28 09:17:42
 * @LastEditors: Please set LastEditors
 * @LastEditTime: 2020-11-08 20:46:45
 * @Description:
 * @FilePath: \pslc\src\services\user.ts
 */

import request from '@/utils/request';
import { DriverType } from '@/models/user.d';

export const getUserSelectData = (value: DriverType) => {
  return request('/api/v1/driver/getSelect', {
    method: 'GET',
    params: {
      user_type: value,
    },
  });
};

export const createDriver = (params: any) => {
  return request('/api/v1/driver/create', {
    method: 'POST',
    data: params,
  });
};

export const getDriverList = (params: any) => {
  return request('/api/v1/driver/getList', {
    method: 'GET',
    params: params,
  });
};

export const updateDriver = (params: any) => {
  return request('/api/v1/driver/update', {
    method: 'POST',
    data: params,
  });
};

export const deleteDriver = (params: any) => {
  return request('/api/v1/driver/delete', {
    method: 'Delete',
    params: params,
  });
};
