/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-05-14 21:09:56
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: /oneowork-github/apps/demo/nodejs/egg_ts/config/config.default.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { EggAppConfig, EggAppInfo, PowerPartial } from 'egg';
import * as path from 'path';
// import * as cls from 'cls-hooked';
// import { Sequelize } from 'sequelize';


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
  // 加入事务钩子
  // const namespace = cls.createNamespace('onework-namespace');
  // Sequelize.useCLS(namespace);
  // add your special config in here
  const bizConfig = {
    security: {
      domainWhiteList: [ '*' ], // 白名单
      csrf: { enable: false },
    },
    sequelize: {
      dialect: 'mysql',
      port: 8033,
      username: 'onework',
      password: 'C0uaU*Eq-2.X0nUr',
      database: 'onework',
      host: '101.37.81.183',
      timezone: '+08:00', // for writing to database
    },
    static: {
      prefix: '/public/',
      dir: path.join(appInfo.baseDir, 'app/public'),
    },
  };

  // the return config will combines to EggAppConfig
  return {
    ...config,
    ...bizConfig,
  };
};
