/*
 * @Author: 钟凯
 * @Date: 2021-02-18 16:57:16
 * @LastEditTime: 2021-02-28 09:51:47
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\services\model\dataModel.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function get(query: any) {
  return request<API.ResponseResult<API.Model.DataModel>>('/api/model/data/get', {
    method: 'GET',
    params: { uid: query },
  });
}

export async function getlist(query: any, body: any) {
  return request('/api/model/data/getlist', {
    method: 'POST',
    params: query,
    data: body,
  });
}

export async function insert(body: any) {
  return request<API.ResponseResult<API.Model.DataModel>>('/api/model/data/insert', {
    method: 'POST',
    data: body,
  });
}

export async function update(body: any) {
  return request<API.ResponseResult<API.Model.DataModel>>('/api/model/data/update', {
    method: 'PATCH',
    data: body,
  });
}

export async function save(body: any) {
  return request('/api/model/data/save', {
    method: 'PUT',
    data: body,
  });
}

export async function remove(body: any) {
  return request('/api/model/data/remove', {
    method: 'POST',
    data: body,
  });
}

export async function search(query: any) {
  return request('/api/model/data/search', {
    params: query,
  });
}
