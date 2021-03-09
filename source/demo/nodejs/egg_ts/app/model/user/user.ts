/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:19:27
 * @LastEditTime: 2021-03-09 10:01:26
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\user\user.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application } from 'egg';
import baseModel from '../base';

export default (app:Application) => {

  const SystemModule = app.model.define('systemModule', {
    ...baseModel,
    systemUid: { type: DataTypes.UUID, allowNull: false, comment: '系统uid' },
    moduleUid: { type: DataTypes.UUID, allowNull: false, comment: '模块uid' },
  }, {
    tableName: 'ow_users',
    paranoid: true,
  });

  return SystemModule;
};
