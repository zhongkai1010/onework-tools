/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-03-31 15:24:59
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\data\collection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import { NameCodeModel } from '../../core/index';

export default (app:Application) => {


  const Collection = app.model.define<Sequelize.Data.Collection, Ow.Data.Collection>('collection', {
    ...NameCodeModel,
    items: { type: DataTypes.JSON, allowNull: false, defaultValue: [], comment: '数据项集合' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_model_collections',
    paranoid: true,
  });

  return Collection;
};

