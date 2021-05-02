/*
 * @Author: 钟凯
 * @Date: 2021-03-04 10:03:17
 * @LastEditTime: 2021-03-15 17:07:37
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\services\scheme.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function getDatabases(query: any) {
  return request<API.ResponseResult<any>>('/api/database/scheme/getDatabases', {
    method: 'GET',
    params: query,
  });
}

export async function getTables(query: any) {
  return request<API.ResponseResult<any>>('/api/database/scheme/getTables', {
    method: 'GET',
    params: query,
  });
}

export async function syncDataBase(body: any) {
  return request<API.ResponseResult<any>>('/api/database/scheme/syncDataBase', {
    method: 'POST',
    data: body,
  });
}

export async function getTableColumns(query: any) {
  return request<API.ResponseResult<any>>('/api/database/scheme/getTableColumns', {
    method: 'GET',
    params: query,
  });
}


