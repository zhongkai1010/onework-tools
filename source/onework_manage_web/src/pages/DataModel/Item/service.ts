/*
 * @Author: 钟凯
 * @Date: 2021-02-06 07:03:31
 * @LastEditTime: 2021-02-06 07:14:15
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\pages\DataModel\Item\service.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

import { request } from 'umi';

export async function getItemList() {
    return request('/api/model/item/getlist');
}
