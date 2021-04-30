/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:18
 * @LastEditTime: 2021-03-31 15:38:23
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\table.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import { NameCodeModel } from '../../core/index';

export default (app:Application) => {

  const Table = app.model.define<Sequelize.Database.Table, Ow.Database.Table>('table', {
    ...NameCodeModel,
    cnUid: { type: DataTypes.STRING, allowNull: true, comment: '连接uid' },
    dbUid: { type: DataTypes.STRING, allowNull: true, comment: '数据库uid' },
    dbName: { type: DataTypes.STRING, allowNull: true, comment: '数据库名称' },
    description: { type: DataTypes.TEXT, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_tables',
    paranoid: true,
  });


  return Table;
};
