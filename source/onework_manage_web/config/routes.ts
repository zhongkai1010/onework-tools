/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-02-09 07:30:20
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
        path: '/model/set',
        name: 'set',
        icon: 'table',
        component: './DataModel/Set',
      },
      {
        path: '/model/model',
        name: 'model',
        icon: 'smile',
        component: './DataModel/Model',
      },
      {
        path: '/model/behavior',
        name: 'behavior',
        icon: 'smile',
        component: './DataModel/Behavior',
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
