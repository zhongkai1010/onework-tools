/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:00:46
 * @LastEditTime: 2021-02-23 17:01:12
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\model\base.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const sequelize = require('sequelize');

module.exports = {
  id: { type: sequelize.DataTypes.INTEGER, primaryKey: true, autoIncrement: true, comment: '自动增长列，主键' },
  uid: { type: sequelize.DataTypes.UUID, defaultValue: sequelize.DataTypes.UUIDV4, allowNull: false, comment: '唯一值，不重复' },
};
