/*
 * @Author: your name
 * @Date: 2021-05-17 18:34:51
 * @LastEditTime: 2021-05-25 12:53:03
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

  // add your user config here
  const userConfig = {
    security: {
      domainWhiteList: [ '*' ], // 白名单
      csrf: { enable: false },
    },
    // myAppName: 'egg',
    sequelize: {
      dialect: 'mysql',
      port: 8033,
      username: 'onework',
      password: 'C0uaU*Eq-2.X0nUr',
      database: 'onework',
      host: '101.37.81.183',
      timezone: '+08:00', // for writing to database
    },
  };


  return {
    ...config,
    ...userConfig,
  };
};
