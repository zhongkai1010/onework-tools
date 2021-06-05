
/*
 * @Author: 钟凯
 * @Date: 2021-03-19 11:13:34
 * @LastEditTime: 2021-03-31 15:39:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\tool\translation.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';


const NameCodeModel = require('../base_name_code');
module.exports = app => {
  const { STRING } = app.Sequelize;
  const Translation = app.model.define('Translation', {
    ...NameCodeModel,
    dst: { type: STRING, allowNull: true, comment: '翻译后文本' },
    src: { type: STRING, allowNull: true, comment: '翻译前的文本' },
    from: { type: STRING, allowNull: true, comment: '需要翻译的语言' },
    to: { type: STRING, allowNull: true, comment: '翻译后的语言' },
  }, {
    tableName: 'ow_tool_translations',
    paranoid: true,
  });


  return Translation;
};
