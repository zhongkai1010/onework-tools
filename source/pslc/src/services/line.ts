/*
 * @Author: your name
 * @Date: 2020-11-07 13:39:04
 * @LastEditTime: 2020-11-09 22:29:09
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \videoanalyze_web\src\services\line.ts
 */
import request from '@/utils/request';

export const getLineSelectData = () => {
  return request('/api/v1/routes/getSelect');
};

export async function lineCreate(params: any) {
  return request('/api/v1/routes/create', {
    method: 'POST',
    data: params,
  });
}

export async function lineGetList(params: any) {
  return request('/api/v1/routes/getList', {
    method: 'GET',
    params: params,
  });
}

export async function lineGetDetails(params: any) {
  return request('/api/v1/routes/getDetails', {
    method: 'GET',
    data: params,
  });
}

export async function lineCopy(params: any) {
  return request('/api/v1/routes/copy', {
    method: 'POST',
    data: params,
  });
}

export async function lineDelete(params: any) {
  return request('/api/v1/routes/delete', {
    method: 'delete',
    params: params,
  });
}
