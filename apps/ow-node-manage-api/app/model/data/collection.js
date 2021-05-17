/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-03-31 15:24:59
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\data\collection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const NameCodeModel = require('../base_name_code');

module.exports = app => {
  const { STRING, JSON } = app.Sequelize;

  const Collection = app.model.define('collection', {
    ...NameCodeModel,
    items: { type: JSON, allowNull: false, defaultValue: [], comment: '数据项集合' },
    description: { type: STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_model_collections',
    paranoid: true,
  });

  return Collection;
};

