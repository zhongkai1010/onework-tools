/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:05
 * @LastEditTime: 2021-02-03 15:36:34
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\services\user.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function query() {
  return request<API.CurrentUser[]>('/api/users');
}

export async function queryCurrent() {
  return request<API.CurrentUser>('/api/currentUser');
}

export async function queryNotices(): Promise<any> {
  return request<{ data: API.NoticeIconData[] }>('/api/notices');
}
