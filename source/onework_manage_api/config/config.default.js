/*
 * @Author: 钟凯
 * @Date: 2021-02-11 18:45:01
 * @LastEditTime: 2021-02-17 14:09:06
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\config\config.default.js
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

  config.security = {
    domainWhiteList: [ '*' ], // 白名单
    csrf: { enable: false },
  };

  // add your middleware config here
  config.middleware = [
    'transactionHandler',
    'errorHandler',
  ];

  // add your user config here
  const userConfig = {
    // myAppName: 'egg',
    sequelize: {
      dialect: 'mysql',
      username: 'root',
      password: '123qwe!@#',
      database: 'onework',
      host: '127.0.0.1',
      timezone: '+08:00', // for writing to database
    },
  };

  return {
    ...config,
    ...userConfig,
  };
};
