/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-03-07 00:59:03
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\config\plugin.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { EggPlugin } from 'egg';

const plugin: EggPlugin = {
  // static: true,
  // nunjucks: {
  //   enable: true,
  //   package: 'egg-view-nunjucks',
  // },
  sequelize: {
    enable: true,
    package: 'egg-sequelize',
  },
  validate: {
    enable: true,
    package: 'egg-validate',
  },

};

export default plugin;
