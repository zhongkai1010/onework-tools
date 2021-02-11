/*
 * @Author: 钟凯
 * @Date: 2021-02-11 18:45:01
 * @LastEditTime: 2021-02-11 21:40:59
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\config\config.default.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
/* eslint valid-jsdoc: "off" */

'use strict';

/**
 * @param {Egg.EggAppInfo} appInfo app info
 */
module.exports = appInfo => {
  /**
   * built-in config
   * @type {Egg.EggAppConfig}
   **/
  const config = exports = {};

  // use for cookie sign key, should change to your own and keep security
  config.keys = appInfo.name + '_1613040293104_971';

  // add your middleware config here
  config.middleware = [];

  // add your user config here
  const userConfig = {
    // myAppName: 'egg',
    sequelize: {
      dialect: 'mysql',
      username: 'root',
      password: '123qwe!@#',
      database: 'egg-sequelize-doc-default',
      host: '127.0.0.1',
    },
  };

  return {
    ...config,
    ...userConfig,
  };
};
