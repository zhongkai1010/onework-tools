/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:24:45
 * @LastEditTime: 2021-02-21 15:24:46
 * @LastEditors: 钟凯
 * @Description: 模块
 * @FilePath: \onework_manage_api\app\model\module.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import { BaseModel } from '../../core/index';

export default (app:Application) => {

  const Module = app.model.define<Sequelize.Module.Module, Ow.Module.Module>('module', {
    ...BaseModel,
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },

  }, {
    tableName: 'ow_modules',
    paranoid: true,
  });


  return Module;
};
