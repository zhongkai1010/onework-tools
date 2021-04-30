/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:53
 * @LastEditTime: 2021-03-06 19:09:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\database\column.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;
  const Column = app.model.define('column', {
    ...baseModel,
    cnUid: { type: DataTypes.STRING, allowNull: false, comment: '连接uid' },
    tbUid: { type: DataTypes.STRING, allowNull: false, comment: '数据库表uid' },
    dbName: { type: DataTypes.STRING, allowNull: false, comment: '数据库uid' },
    type: { type: DataTypes.TEXT, allowNull: false, comment: '类型' },
    isNull: { type: DataTypes.BOOLEAN, allowNull: false, comment: '是否为空' },
    isUnique: { type: DataTypes.BOOLEAN, allowNull: false, comment: '是否主键' },
    length: { type: DataTypes.BIGINT, allowNull: true, comment: '长度' },
    precision: { type: DataTypes.INTEGER, allowNull: true, comment: '精度' },
    oredr: { type: DataTypes.INTEGER, allowNull: true, comment: '序号' },
    defaultValue: { type: DataTypes.STRING, allowNull: true, comment: '默认值' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },

  }, {
    tableName: 'ow_database_columns',
    paranoid: true,
  });
  return Column;
};
