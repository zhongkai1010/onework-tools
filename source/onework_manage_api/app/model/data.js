/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:34:51
 * @LastEditTime: 2021-02-13 07:37:14
 * @LastEditors: 钟凯
 * @Description: Sequelize的数据模型Model文件
 * @FilePath: \onework_manage_api\app\model\data.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Data = app.model.define('data', {
    id: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true },
    uuid: { type: DataTypes.UUID, defaultValue: DataTypes.UUIDV4, allowNull: false },
    name: { type: DataTypes.STRING, allowNull: false, unique: true, comment: '数据项名称，唯一' },
    code: { type: DataTypes.STRING, allowNull: false, comment: '代码值' },
    type: { type: DataTypes.INTEGER, allowNull: false, defaultValue: 1, comment: '数据项类型，0:缺省值，1：字符、2：整型、3：数字、4：布尔、5：日期、6：时间、7：枚举' },
    state: { type: DataTypes.INTEGER, allowNull: false, comment: '状态，1：启用 ，2：禁用' },
    created_at: DataTypes.DATE,
    updated_at: DataTypes.DATE,
  }, {
    tableName: 'model_datas',
    paranoid: true,
  });

  return Data;
};
