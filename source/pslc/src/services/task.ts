/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-28 14:43:24
 * @LastEditors: Please set LastEditors
 * @LastEditTime: 2020-11-08 18:32:03
 * @Description:
 * @FilePath: \pslc\src\services\task.ts
 */
import request from '@/utils/request';
import { request as umiRequest } from 'umi';

export async function taskGetList(params: any) {
  return request('/api/v1/task/getList', {
    method: 'GET',
    params: params,
  });
}

export async function taskCreate(params: any) {
  return request('/api/v1/task/create', {
    method: 'POST',
    data: params,
  });
}
export async function createAndFile(params: any, data: any) {
  return umiRequest('/api/v1/task/createAndFile', {
    method: 'POST',
    headers: {
      token:
        'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjEsImlhdCI6MTYwNDc0MTAzNiwiZXhwIjoxNjA2NDY5MDM2fQ.dL9xvrzACrJC_sXzgSSjL70QcV-ERVqddkhxUFFwS_w',
    },
    params: params,
    requestType: 'form',
    responseType: 'json',
    data: data,
  });
}

export async function taskStart(params: string) {
  return request('/api/v1/task/start', {
    method: 'POST',
    data: { id: params },
  });
}

export async function taskStop(params: string) {
  return request('/api/v1/task/stop', {
    method: 'POST',
    data: { id: params },
  });
}
