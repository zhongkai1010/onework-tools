
/*
 * @Author: 钟凯
 * @Date: 2021-03-19 11:13:34
 * @LastEditTime: 2021-03-31 15:39:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\tool\translation.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import { DataTypes } from 'sequelize';
import { Application, Ow, Sequelize } from 'egg';
import { NameCodeModel } from '../../core/index';


export default (app:Application) => {

  const Translation = app.model.define<Sequelize.Tool.Translation, Ow.Tool.Translation>('Translation', {
    ...NameCodeModel,
    dst: { type: DataTypes.STRING, allowNull: true, comment: '翻译后文本' },
    src: { type: DataTypes.STRING, allowNull: true, comment: '翻译前的文本' },
    from: { type: DataTypes.STRING, allowNull: true, comment: '需要翻译的语言' },
    to: { type: DataTypes.STRING, allowNull: true, comment: '翻译后的语言' },
  }, {
    tableName: 'ow_tool_translations',
    paranoid: true,
  });


  return Translation;
};
