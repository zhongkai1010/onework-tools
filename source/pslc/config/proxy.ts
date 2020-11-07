/*
 * @Author: your name
 * @Date: 2020-10-27 22:58:00
 * @LastEditTime: 2020-11-07 10:37:40
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \pslc\config\proxy.ts
 */
/**
 * 在生产环境 代理是无法生效的，所以这里没有生产环境的配置
 * The agent cannot take effect in the production environment
 * so there is no configuration of the production environment
 * For details, please see
 * https://pro.ant.design/docs/deploy
 */
export default {
  dev: {
    '/api': {
      target: 'http://127.0.0.1:7001/',
      changeOrigin: true,
    },
  },
  test: {
    '/api': {
      target: 'http://127.0.0.1:7001/',
      changeOrigin: true,
    },
  },
  pre: {
    '/api': {
      target: 'http://127.0.0.1:7001/',
      changeOrigin: true,
    },
  },
};
