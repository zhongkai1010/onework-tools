/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-24 15:27:17
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\item.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const AppCode = require('../../core/appCode');
const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Item = app.model.define('item', {
    ...baseModel,
    type: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.model.itemType.string, comment: '数据项类型' },
    cumulate: { type: DataTypes.INTEGER, allowNull: false, defaultValue: 0, comment: '使用累计总数' },
  }, {
    tableName: 'ow_model_items',
    paranoid: true,
  });

  Item.prototype.plusCumulate = async function() {
    this.cumulate = this.cumulate + 1;
    await this.save({ fields: [ 'cumulate' ] });
  };
  Item.prototype.subCumulate = async function() {
    this.cumulate = this.cumulate - 1;
    await this.save({ fields: [ 'cumulate' ] });
  };
  return Item;
};
