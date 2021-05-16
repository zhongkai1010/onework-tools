/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:53
 * @LastEditTime: 2021-03-31 15:37:49
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\column.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import { NameCodeModel } from '../../core/index';

export default (app:Application) => {

  const Column = app.model.define<Sequelize.Database.Column, Ow.Database.Column>('column', {
    ...NameCodeModel,
    cnUid: { type: DataTypes.STRING, allowNull: false, comment: '连接uid' },
    dbUid: { type: DataTypes.STRING, allowNull: false, comment: '数据库uid' },
    tbUid: { type: DataTypes.STRING, allowNull: false, comment: '数据库表uid' },
    dbName: { type: DataTypes.STRING, allowNull: false, comment: '数据库uid' },
    type: { type: DataTypes.TEXT, allowNull: false, comment: '类型' },
    isNull: { type: DataTypes.BOOLEAN, allowNull: false, comment: '是否为空' },
    isUnique: { type: DataTypes.BOOLEAN, allowNull: false, comment: '是否主键' },
    length: { type: DataTypes.BIGINT, allowNull: true, comment: '长度' },
    precision: { type: DataTypes.INTEGER, allowNull: true, comment: '精度' },
    oredr: { type: DataTypes.INTEGER, allowNull: true, comment: '序号' },
    defaultValue: { type: DataTypes.TEXT, allowNull: true, comment: '默认值' },
    description: { type: DataTypes.TEXT, allowNull: true, comment: '描述' },

  }, {
    tableName: 'ow_database_columns',
    paranoid: true,
  });
  return Column;
};
