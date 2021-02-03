/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-02-03 15:51:34
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\config\routes.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
export default [
  {
    path: '/user',
    layout: false,
    routes: [
      {
        path: '/user',
        routes: [
          {
            name: 'login',
            path: '/user/login',
            component: './User/login',
          },
        ],
      },
    ],
  },
  {
    path: '/welcome',
    name: 'welcome',
    icon: 'smile',
    component: './Welcome',
  },
  {
    path: '/admin',
    name: 'admin',
    icon: 'crown',
    access: 'canAdmin',
    component: './Admin',
    routes: [
      {
        path: '/admin/sub-page',
        name: 'sub-page',
        icon: 'smile',
        component: './Welcome',
      },
    ],
  },
  {
    name: 'list.table-list',
    icon: 'table',
    path: '/list',
    component: './TableList',
  },

  {
    path: '/model',
    name: 'model',
    icon: 'crown',
    access: 'canAdmin',
    routes: [
      {
        path: '/model/publuc-data',
        name: 'public-data',
        icon: 'smile',
        component: './Model/PublicData',
      },
      {
        path: '/model/public-data-item',
        name: 'public-data-item',
        icon: 'table',
        component: './Model/PublicDataItem',
      },
      {
        path: '/model/data',
        name: 'data',
        icon: 'smile',
        component: './Model/Data',
      },
      {
        path: '/model/data-item',
        name: 'data-item',
        icon: 'smile',
        component: './Model/DataItem',
      },
    ],
  },
  {
    path: '/',
    redirect: '/welcome',
  },
  {
    component: './404',
  },
];
