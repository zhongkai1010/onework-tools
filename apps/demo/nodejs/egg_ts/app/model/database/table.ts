/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:18
 * @LastEditTime: 2021-03-09 10:04:36
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\table.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import baseModel from '../base_name_code';

export default (app:Application) => {

  const Table = app.model.define<Sequelize.Database.Table, Ow.Database.Table>('table', {
    ...baseModel,
    cnUid: { type: DataTypes.STRING, allowNull: true, comment: '连接uid' },
    dbName: { type: DataTypes.STRING, allowNull: true, comment: '数据库名称' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_tables',
    paranoid: true,
  });


  return Table;
};
