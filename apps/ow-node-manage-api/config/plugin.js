/*
 * @Author: your name
 * @Date: 2021-05-17 18:34:51
 * @LastEditTime: 2021-05-18 17:53:50
 * @LastEditors: your name
 * @Description: In User Settings Edit
 * @FilePath: \ow-node-manage-api\config\plugin.js
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
