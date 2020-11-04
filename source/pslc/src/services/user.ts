/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-28 09:17:42
 * @LastEditors: 钟凯
 * @LastEditTime: 2020-11-04 18:49:53
 * @Description: 
 * @FilePath: \pslc\src\services\user.ts
 */
import request from '@/utils/request';

export const getUserSelectData = () => {
  return request('/api/v1/common/queryUsers');
};
