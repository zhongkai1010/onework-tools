/*
 * @Author: 钟凯
 * @Date: 2021-02-07 09:21:39
 * @LastEditTime: 2021-02-07 17:28:27
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\mock\model.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
/*
 * @Author: 钟凯
 * @Date: 2021-02-05 22:10:10
 * @LastEditTime: 2021-02-06 16:29:26
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\mock\model.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */


import { Request, Response } from 'express';
import Mock from 'mockjs';

export default {
  'GET /api/model/item/getlist': (req: Request, res: Response) => {
    let dataSource = Mock.mock({
      'data|10': [
        {
          'id|+1': 1,
          uuid: '@guid()', // Id
          name: '@cname()', // 名称
          code: '@first()', // 编码
          'type|1': ['character', 'integer', 'digital', 'boolean', 'enumerate', 'date', 'datetime'], // 类型
          'status|1': ['enable', 'disable'], // 启用状态      
          created: '@datetime()',
          updated: '@datetime()',
        },
      ],
    });
    res.json({ data: dataSource.data, success: true });
  },
};
