/*
 * @Author: 钟凯
 * @Date: 2021-03-19 11:14:36
 * @LastEditTime: 2021-03-31 15:39:16
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\tool\comparison.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import { NameCodeModel } from '../../core/index';

export default (app:Application) => {

  const Comparison = app.model.define<Sequelize.Tool.Comparison, Ow.Tool.Comparison>('comparison', {
    ...NameCodeModel,
    defaultValue: { type: DataTypes.STRING, allowNull: false, comment: '缺省值' },
    datas: { type: DataTypes.JSON, defaultValue: [], allowNull: false, comment: '对照数据' },
  }, {
    tableName: 'ow_tool_comparisons',
    paranoid: true,
  });

  return Comparison;
};
