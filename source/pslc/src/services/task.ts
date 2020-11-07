/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-28 14:43:24
 * @LastEditors: Please set LastEditors
 * @LastEditTime: 2020-11-07 15:23:40
 * @Description:
 * @FilePath: \pslc\src\services\task.ts
 */
import request from '@/utils/request';

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
