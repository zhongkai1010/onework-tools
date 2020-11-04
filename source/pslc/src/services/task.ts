/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-28 14:43:24
 * @LastEditors: 钟凯
 * @LastEditTime: 2020-11-04 18:51:40
 * @Description: 
 * @FilePath: \pslc\src\services\task.ts
 */
import request from '@/utils/request';
import { ListParams } from '../models/common';


/**
 * 检索任务列表参数
 *
 * @export
 * @interface TaskGetListParams
 */
export interface TaskGetListParams {
  createDate?: string;
  locomotiveNo?: string;
  driver?: string;
  departureDate?: string;
  taskStatus?: number;
}

/**
 *  获取任务列表
 *
 * @export
 * @param {(TaskGetListParams & ListParams)} params
 * @returns
 */
export async function taskGetList(params: TaskGetListParams & ListParams) {
  return request('/api/v1/task/getList', {
    method: 'GET',
    params: params,
  });
}

/**
 *  创建任务
 *
 * @export
 * @param {(TaskGetListParams & ListParams)} params
 * @returns
 */
export async function taskCreate(params: TaskGetListParams & ListParams) {
  return request('/api/task/create', {
    method: 'POST',
    data: params,
  });
}

/**
 * 启动任务
 *
 * @export
 * @param {string} params 任务Id
 * @returns
 */
export async function taskStart(params: string) {
  return request('/api/task/start', {
    method: 'POST',
    data: { id: params },
  });
}

/**
 * 停止任务
 *
 * @export
 * @param {string} params 任务Id
 * @returns
 */
export async function taskStop(params: string) {
  return request('/api/task/stop', {
    method: 'POST',
    data: { id: params },
  });
}
