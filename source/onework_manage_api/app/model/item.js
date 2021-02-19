/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-19 18:26:03
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\model\item.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const AppCode = require('../core/appCode');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Item = app.model.define('item', {
    id: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true },
    uid: { type: DataTypes.UUID, defaultValue: DataTypes.UUIDV4, allowNull: false },
    name: { type: DataTypes.STRING, allowNull: false, comment: '数据项名称，唯一' },
    code: { type: DataTypes.STRING, allowNull: false, comment: '代码值' },
    type: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.model.itemType.character, comment: '数据项类型' },
    status: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.common.status.enable, comment: '状态' },
    cumulate: { type: DataTypes.INTEGER, allowNull: false, defaultValue: 0, comment: '使用累计总数' },
  }, {
    tableName: 'model_items',
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
