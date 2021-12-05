/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-12-04 19:53:02
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework-manage-api\config\config.default.ts
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
      port: 3306,
      username: 'onework',
      password: '123456',
      database: 'onework',
      host: '172.17.64.1',
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
