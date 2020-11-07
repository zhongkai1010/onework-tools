/*
 * @Author: your name
 * @Date: 2020-11-07 13:39:04
 * @LastEditTime: 2020-11-07 14:05:54
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \pslc\src\services\line.js
 */
import request from '@/utils/request';

export const getLineSelectData = () => {
  return request('/api/v1/routes/getSelect');
};
