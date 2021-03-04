/*
 * @Author: 钟凯
 * @Date: 2021-03-04 10:03:17
 * @LastEditTime: 2021-03-04 17:35:39
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\services\scheme.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function getlist(query: any) {
  return request<API.ResponseResult<any>>('/api/database/scheme/getlist', {
    method: 'GET',
    params: query,
  });
}
