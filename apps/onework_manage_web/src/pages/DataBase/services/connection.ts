/*
 * @Author: 钟凯
 * @Date: 2021-03-04 10:00:56
 * @LastEditTime: 2021-03-04 21:20:59
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\services\connection.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function insert(body: any) {
  return request<API.ResponseResult<API.DataBase.Connection>>('/api/database/connection/insert', {
    method: 'POST',
    data: body,
  });
}

export async function getlist() {
  return request<API.ResponseResult<API.DataBase.Connection[]>>('/api/database/connection/getlist');
}

export async function update(body: any) {
  return request<API.ResponseResult<API.DataBase.Connection>>('/api/database/connection/update', {
    method: 'POST',
    data: body,
  });
}

export async function remove(body: any) {
  return request<API.ResponseResult<any>>('/api/database/connection/remove', {
    method: 'POST',
    data: body,
  });
}
