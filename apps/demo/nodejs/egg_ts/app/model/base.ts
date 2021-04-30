/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:00:46
 * @LastEditTime: 2021-03-09 10:10:09
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\base.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';

export default {
  uid: { type: DataTypes.UUID, primaryKey: true, defaultValue: DataTypes.UUIDV4, allowNull: false, comment: '唯一值，不重复' },
};
