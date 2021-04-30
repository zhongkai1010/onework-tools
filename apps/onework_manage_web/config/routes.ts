/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-03-03 16:08:14
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
        path: '/model/item',
        name: 'item',
        icon: 'smile',
        component: './DataModel/Item',
      },
      {
        path: '/model/collection',
        name: 'collection',
        icon: 'table',
        component: './DataModel/Collection',
      },
      {
        path: '/model/model',
        name: 'model',
        icon: 'smile',
        component: './DataModel/Model',
      },
      {
        path: '/model/model-item',
        name: 'model-item',
        icon: 'smile',
        component: './DataModel/Model/item',
      },
      {
        path: '/model/model-behavior',
        name: 'model-behavior',
        icon: 'smile',
        component: './DataModel/Model/behavior',
      },
    ],
  },
  {
    path: '/db',
    name: 'db',
    icon: 'crown',
    access: 'canAdmin',
    component: './DataBase',
  },
  {
    path: '/',
    redirect: '/welcome',
  },
  {
    component: './404',
  },
];
