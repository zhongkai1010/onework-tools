/*
 * @Author: 钟凯
 * @Date: 2021-03-24 16:07:54
 * @LastEditTime: 2021-03-25 17:43:27
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\Tool\services.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { request } from 'umi';

export async function addComparison(body: Omit<API.Tool.Comparison, 'uid'>) {
  return request<API.ResponseResult<API.Tool.Comparison>>('/api/tool/comparison/add', {
    method: 'POST',
    data: body,
  });
}

export async function comparisonGetList() {
  return request<API.ResponseResult<API.Tool.Comparison[]>>('/api/tool/comparison/getlist', {
    method: 'GET',
  });
}

export async function updateComparison(body: API.Tool.Comparison) {
  return request<API.ResponseResult<API.Tool.Comparison>>('/api/tool/comparison/update', {
    method: 'POST',
    data: body,
  });
}

export async function deleteComparison(body: any) {
  return request<API.ResponseResult<any>>('/api/tool/comparison/delete', {
    method: 'POST',
    data: body,
  });
}

export async function addTemplate(body: Omit<API.Tool.Template, 'uid'>) {
  return request<API.ResponseResult<API.Tool.Comparison>>('/api/tool/template/add', {
    method: 'POST',
    data: body,
  });
}

export async function templateGetList() {
  return request<API.ResponseResult<API.Tool.Template[]>>('/api/tool/template/getlist', {
    method: 'GET',
  });
}

export async function updateTemplate(body: API.Tool.Template) {
  return request<API.ResponseResult<API.Tool.Template>>('/api/tool/template/update', {
    method: 'POST',
    data: body,
  });
}

export async function deleteTemplate(body: any) {
  return request<API.ResponseResult<any>>('/api/tool/template/delete', {
    method: 'POST',
    data: body,
  });
}

export async function translation(body: { q: string; from: string; to: string }) {
  return request<API.ResponseResult<string>>('/api/tool/translation/', {
    method: 'POST',
    data: body,
  });
}

export async function translationGetlist(
  params: { page: number; limit: number; keyword?: string; sort: string; order?: string },
  body: any,
) {
  return request<API.ResponseResult<{ rows: API.Tool.TranslationRecord[]; total: number }>>(
    '/api/tool/translation/getlist',
    {
      method: 'POST',
      params,
      data: body,
    },
  );
}
