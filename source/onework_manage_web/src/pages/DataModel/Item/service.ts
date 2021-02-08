/*
 * @Author: 钟凯
 * @Date: 2021-02-06 07:03:31
 * @LastEditTime: 2021-02-08 11:47:22
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\pages\DataModel\Item\service.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

import { request } from 'umi';

/**
 * @description: 获取数据项列表
 * @param {*}
 * @return {*}
 */
export async function getItemList() {
    return request('/api/model/item/getItemList');
}

/**
 * @description: 保存数据项
 * @param {any} data
 * @return {*}
 */
export async function saveItem(data: any) {
    return request('/api/model/item/saveItem', { method: 'POST', data });
}

/**
 * @description: 删除数据项
 * @param {any} data
 * @return {*}
 */
export async function deleteItem(data: any) {
    return request('/api/model/item/deleteItem', { method: 'POST', data });
}
