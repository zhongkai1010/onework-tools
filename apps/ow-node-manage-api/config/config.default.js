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
  config.middleware = [];

  // add your user config here
  const userConfig = {
    // myAppName: 'egg',
    sequelize: {
      dialect: 'mysql',
      port: 8806,
      username: 'root',
      password: '123qwe!@#zk',
      database: 'onework_dev',
      host: '101.37.81.183',
      timezone: '+08:00', // for writing to database
    },
  };


  return {
    ...config,
    ...userConfig,
  };
};
