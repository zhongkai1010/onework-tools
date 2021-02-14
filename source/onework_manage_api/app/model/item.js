/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-14 18:27:07
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\item.js
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
    type: { type: DataTypes.INTEGER, allowNull: false, defaultValue: AppCode.model.itemType.string, comment: '数据项类型，0:缺省值，1：字符、2：整型、3：数字、4：布尔、5：日期、6：时间' },
    status: { type: DataTypes.INTEGER, allowNull: false, defaultValue: AppCode.common.status.enable, comment: '状态，1：启用、2：禁用' },
    cumulate: { type: DataTypes.INTEGER, allowNull: false, defaultValue: 0, comment: '使用累计总数' },
    created_at: DataTypes.DATE,
    updated_at: DataTypes.DATE,
  }, {
    tableName: 'model_items',
    paranoid: true,
  });

  Item.prototype.plusCumulate = async function() {
    this.cumulate = this.cumulate + 1;
    await this.save({ fields: [ 'cumulate' ], transaction: app.ctx.transaction });
  };
  Item.prototype.subCumulate = async function() {
    this.cumulate = this.cumulate - 1;
    await this.save({ fields: [ 'cumulate' ] });
  };
  return Item;
};
