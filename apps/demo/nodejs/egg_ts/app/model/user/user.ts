/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:19:27
 * @LastEditTime: 2021-03-10 11:43:05
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\user\user.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import baseModel from '../base';

export default (app:Application) => {

  const User = app.model.define<Sequelize.User.User, Ow.User.User>('systemModule', {
    ...baseModel,
    systemUid: { type: DataTypes.UUID, allowNull: false, comment: '系统uid' },
    moduleUid: { type: DataTypes.UUID, allowNull: false, comment: '模块uid' },
  }, {
    tableName: 'ow_users',
    paranoid: true,
  });

  return User;
};
