/*
 * @Author: 钟凯
 * @Date: 2021-02-17 20:51:16
 * @LastEditTime: 2021-02-18 12:16:36
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\services\model\collection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
/*
 * @Author: 钟凯
 * @Date: 2021-02-16 20:49:39
 * @LastEditTime: 2021-02-17 20:12:23
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\services\model\item.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function getlist(query: any, body: any) {
  return request('/api/model/collection/getlist', {
    method: 'POST',
    params: query,
    data: body,
  });
}

export async function insert(body: any) {
  return request<API.ResponseResult<API.Model.Item>>('/api/model/collection/insert', {
    method: 'POST',
    data: body,
  });
}

export async function update(body: any) {
  return request('/api/model/collection/update', {
    method: 'PATCH',
    data: body,
  });
}

export async function save(body: any) {
  return request('/api/model/collection/save', {
    method: 'PUT',
    data: body,
  });
}

export async function remove(body: any) {
  return request('/api/model/collection/remove', {
    method: 'POST',
    data: body,
  });
}

export async function search(query: any) {
  return request('/api/model/collection/search', {
    params: query,
  });
}
