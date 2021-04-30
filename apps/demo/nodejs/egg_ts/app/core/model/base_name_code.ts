/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:31:35
 * @LastEditTime: 2021-03-31 15:39:24
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\core\model\base_name_code.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import baseModel from './base';

export default {
  ...baseModel,
  name: { type: DataTypes.STRING(500), allowNull: false, comment: '名称' },
  code: { type: DataTypes.STRING, allowNull: false, comment: '编码' },
};
