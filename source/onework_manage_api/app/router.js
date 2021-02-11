/*
 * @Author: 钟凯
 * @Date: 2021-02-11 18:45:01
 * @LastEditTime: 2021-02-12 01:26:29
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\router.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

/**
 * @param {Egg.Application} app - egg application
 */
module.exports = app => {
  const { router, controller } = app;
  router.get('/', controller.home.index);

  router.resources('users', '/users', controller.api.items);
};
