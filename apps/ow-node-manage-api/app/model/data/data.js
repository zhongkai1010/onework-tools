/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:34:51
 * @LastEditTime: 2021-03-31 15:36:26
 * @LastEditors: 钟凯
 * @Description: Sequelize的数据模型Model文件
 * @FilePath: \egg_ts\app\model\data\data.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const NameCodeModel = require('../base_name_code');
const { AppCode } = require('../../core/index');

module.exports = app => {
  const { STRING } = app.Sequelize;
  const Data = app.model.define('data', {
    ...NameCodeModel,
    use: { type: STRING, allowNull: false, defaultValue: AppCode.model.modelUse.universal, comment: '用途' },
    status: { type: STRING, allowNull: false, defaultValue: AppCode.common.status.enable, comment: '状态' },
    description: { type: STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_model_datas',
    paranoid: true,
  });

  return Data;
};
