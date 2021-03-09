/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-03-09 10:25:53
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\config\config.default.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { EggAppConfig, EggAppInfo, PowerPartial } from 'egg';

export default (appInfo: EggAppInfo) => {
  const config = {} as PowerPartial<EggAppConfig>;

  // override config from framework / plugin
  // use for cookie sign key, should change to your own and keep security
  config.keys = appInfo.name + '_1615044078588_5255';

  // add your egg config in here
  config.middleware = [
    'transaction',
    'error',
  ];

  // add your special config in here
  const bizConfig = {
    security: {
      domainWhiteList: [ '*' ], // 白名单
      csrf: { enable: false },
    },
    sequelize: {
      dialect: 'mysql',
      port: 8806,
      username: 'onework_dev',
      password: 'akT7RCmZ26PCEy7L',
      database: 'onework_dev',
      host: '101.37.81.183',
      timezone: '+08:00', // for writing to database
    },
  };

  // the return config will combines to EggAppConfig
  return {
    ...config,
    ...bizConfig,
  };
};
