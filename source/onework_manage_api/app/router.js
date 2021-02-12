/*
 * @Author: 钟凯
 * @Date: 2021-02-11 18:45:01
 * @LastEditTime: 2021-02-13 07:24:22
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

  router.post('/api/model/item/insert', controller.api.model.items.insert);
  router.get('/api/model/item/getlist', controller.api.model.items.getlist);
  router.patch('/api/model/item/update', controller.api.model.items.update);
  router.put('/api/model/item/save', controller.api.model.items.save);
  router.del('/api/model/item/remove', controller.api.model.items.remove);
  router.get('/api/model/item/search', controller.api.model.items.search);

  router.post('/api/model/set/insert', controller.api.model.set.insert);
  router.get('/api/model/set/getlist', controller.api.model.set.getlist);
  router.patch('/api/model/set/update', controller.api.model.set.update);
  router.del('/api/model/set/remove', controller.api.model.set.remove);
  router.get('/api/model/set/search', controller.api.model.set.search);

  router.post('/api/model/data/insert', controller.api.model.data.insert);
  router.get('/api/model/data/getlist', controller.api.model.data.getlist);
  router.patch('/api/model/data/update', controller.api.model.data.update);
  router.del('/api/model/data/remove', controller.api.model.data.remove);
  router.get('/api/model/data/search', controller.api.model.data.search);
};
