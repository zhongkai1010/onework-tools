/*
 * @Author: your name
 * @Date: 2021-05-17 18:34:51
 * @LastEditTime: 2021-05-19 09:23:53
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ow-node-manage-api\config\config.default.js
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
  config.keys = appInfo.name + '_1621247684682_9886';

  // add your middleware config here
  config.middleware = [
    'error',
    'validate',
    'transaction',
  ];

  config.security = {
    csrf: {
      enable: false
    }
  }

  // add your user config here
  const userConfig = {
    // myAppName: 'egg',
    sequelize: {
      dialect: 'mysql',
      port: 3306,
      username: 'root',
      password: '123qwe',
      database: 'onework_dev',
      host: '127.0.0.1',
      timezone: '+08:00', // for writing to database
    },
  };


  return {
    ...config,
    ...userConfig,
  };
};
