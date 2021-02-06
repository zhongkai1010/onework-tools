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
          'type|1-7': 0, // 类型
          allowNull: '@boolean()', // 是否允许空
          rule: null, // 规则
          'length|0-100': 0, // 长度
          'precision|1': [null, 1, 2, 3, 4], // 精度
          'defaultValue|1': [null, '@cname()'], // 默认值
          description: '@csentence()', // 描述
          'status|1': [1, 2], // 启用状态      
          created: '@datetime()',
          updated: '@datetime()',
        },
      ],
    });
    res.json({ data: dataSource.data, success: true });
  },
};
