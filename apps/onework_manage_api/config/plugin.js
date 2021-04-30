/*
 * @Author: 钟凯
 * @Date: 2021-02-11 18:45:01
 * @LastEditTime: 2021-02-13 20:34:02
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\config\plugin.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

/** @type Egg.EggPlugin */
module.exports = {
  // had enabled by egg
  // static: {
  //   enable: true,
  // }
  sequelize: {
    enable: true,
    package: 'egg-sequelize',
  },
  validate: {
    enable: true,
    package: 'egg-validate',
  },
};
