/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-03-24 16:51:47
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\config\proxy.ts
 * @可以输入预定的版权声明、个性签名、空行等
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
    '/api/trans/vip/translate': {
      target: 'http://api.fanyi.baidu.com',
      changeOrigin: true,
    },
    '/api/model/': {
      target: 'http://127.0.0.1:7001',
      changeOrigin: true,
    },
    '/api/database/': {
      target: 'http://127.0.0.1:7001',
      changeOrigin: true,
    },
    '/api/tool/': {
      target: 'http://yapi.one-work.net/mock/15/',
      changeOrigin: true,
    },
    '/api/': {
      target: 'https://preview.pro.ant.design',
      changeOrigin: true,
      pathRewrite: { '^': '' },
    },
  },
  test: {
    '/api/': {
      target: 'https://preview.pro.ant.design',
      changeOrigin: true,
      pathRewrite: { '^': '' },
    },
  },
  pre: {
    '/api/': {
      target: 'your pre url',
      changeOrigin: true,
      pathRewrite: { '^': '' },
    },
  },
};
