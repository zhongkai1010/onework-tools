/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-28 09:17:42
 * @LastEditors: Please set LastEditors
 * @LastEditTime: 2020-11-07 16:35:21
 * @Description:
 * @FilePath: \pslc\config\config.ts
 */
// https://umijs.org/config/
import { defineConfig } from 'umi';
import defaultSettings from './defaultSettings';

export default defineConfig({
  hash: true,
  antd: {},
  dva: {
    hmr: true,
  },

  locale: {
    // default zh-CN
    default: 'zh-CN',
    antd: true,
    // default true, when it is true, will use `navigator.language` overwrite default
    baseNavigator: true,
  },
  dynamicImport: {
    loading: '@/components/PageLoading/index',
  },
  targets: {
    ie: 11,
  },
  // umi routes: https://umijs.org/docs/routing
  routes: [
    {
      path: '/',
      component: '../layouts/Index',
      routes: [
        {
          path: '/',
          redirect: '/index',
        },
        {
          path: '/index',
          component: '../pages/Index',
        },
      ],
    },
  ],
  // Theme for antd: https://ant.design/docs/react/customize-theme-cn
  theme: {
    // ...darkTheme,
    'primary-color': defaultSettings.primaryColor,
  },
  // @ts-ignore
  title: false,
  ignoreMomentLocale: true,
  proxy: {
    '/api': {
      target: 'http://127.0.0.1:7001/',
      changeOrigin: true,
    },
  },
  manifest: {
    basePath: '/',
  },
  request: {
    dataField: 'result',
  },
});
