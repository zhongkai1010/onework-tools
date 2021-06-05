/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:53
 * @LastEditTime: 2021-03-31 15:37:49
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\column.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const NameCodeModel = require('../base_name_code');


module.exports = app => {
  const { STRING, TEXT, BOOLEAN, INTEGER, BIGINT } = app.Sequelize;

  const Column = app.model.define('column', {
    ...NameCodeModel,
    cnUid: { type: STRING, allowNull: false, comment: '连接uid' },
    dbUid: { type: STRING, allowNull: false, comment: '数据库uid' },
    tbUid: { type: STRING, allowNull: false, comment: '数据库表uid' },
    dbName: { type: STRING, allowNull: false, comment: '数据库uid' },
    type: { type: TEXT, allowNull: false, comment: '类型' },
    isNull: { type: BOOLEAN, allowNull: false, comment: '是否为空' },
    isUnique: { type: BOOLEAN, allowNull: false, comment: '是否主键' },
    length: { type: BIGINT, allowNull: true, comment: '长度' },
    precision: { type: INTEGER, allowNull: true, comment: '精度' },
    oredr: { type: INTEGER, allowNull: true, comment: '序号' },
    defaultValue: { type: TEXT, allowNull: true, comment: '默认值' },
    description: { type: TEXT, allowNull: true, comment: '描述' },

  }, {
    tableName: 'ow_database_columns',
    paranoid: true,
  });
  return Column;
};
