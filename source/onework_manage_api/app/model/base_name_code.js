/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:31:35
 * @LastEditTime: 2021-02-21 15:32:48
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\base_name_code.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const sequelize = require('sequelize');
const baseModel = require('./base');

module.exports = {
  ...baseModel,
  name: { type: sequelize.DataTypes.STRING, allowNull: false, comment: '名称' },
  code: { type: sequelize.DataTypes.STRING, allowNull: false, comment: '编码' },
};
