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
  return request('/api/task/getList', {
    method: 'GET',
    data: params,
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
