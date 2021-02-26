/*
 * @Author: 钟凯
 * @Date: 2021-02-26 16:20:43
 * @LastEditTime: 2021-02-26 16:26:11
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\services\model\modelBehavior.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function getlist(query: any, body: any) {
  return request('/api/model/data/behavior/getList', {
    method: 'POST',
    params: query,
    data: body,
  });
}

export async function insert(body: API.Model.DataModelItem) {
  return request<API.ResponseResult<API.Model.DataModelItem>>('/api/model/data/behavior/insert', {
    method: 'POST',
    data: body,
  });
}

export async function update(body: any) {
  return request<API.ResponseResult<API.Model.DataModelItem>>('/api/model/data/behavior/update', {
    method: 'POST',
    data: body,
  });
}

export async function save(body: any) {
  return request<API.ResponseResult<API.Model.DataModelItem>>('/api/model/data/behavior/save', {
    method: 'POST',
    data: body,
  });
}

export async function remove(body: any) {
  return request<API.ResponseResult<API.Model.DataModelItem>>('/api/model/data/behavior/remove', {
    method: 'POST',
    data: body,
  });
}