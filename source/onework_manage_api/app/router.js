/*
 * @Author: 钟凯
 * @Date: 2021-02-11 18:45:01
 * @LastEditTime: 2021-02-17 11:43:24
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\router.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

/**
 * @param {Egg.Application} app - egg application
 */
module.exports = app => {
  const { router, controller } = app;
  router.get('/', controller.home.index);

  router.get('/api/swagger.json', controller.api.swagger.index);

  router.post('/api/model/item/insert', controller.api.model.item.insert);
  router.post('/api/model/item/getlist', controller.api.model.item.getlist);
  router.patch('/api/model/item/update', controller.api.model.item.update);
  router.put('/api/model/item/save', controller.api.model.item.save);
  router.post('/api/model/item/remove', controller.api.model.item.remove);
  router.get('/api/model/item/search', controller.api.model.item.search);

  router.post('/api/model/collection/insert', controller.api.model.collection.insert);
  router.post('/api/model/collection/getlist', controller.api.model.collection.getlist);
  router.patch('/api/model/collection/update', controller.api.model.collection.update);
  router.post('/api/model/collection/remove', controller.api.model.collection.remove);
  router.get('/api/model/collection/search', controller.api.model.collection.search);

  router.post('/api/model/data/insert', controller.api.model.data.insert);
  router.post('/api/model/data/getlist', controller.api.model.data.getlist);
  router.patch('/api/model/data/update', controller.api.model.data.update);
  router.post('/api/model/data/remove', controller.api.model.data.remove);
  router.get('/api/model/data/search', controller.api.model.data.search);

  router.post('/api/model/data/getModelItemList', controller.api.model.data.getModelItemList);
  router.post('/api/model/data/updateModelItem', controller.api.model.data.updateModelItem);
  router.post('/api/model/data/removeModelItem', controller.api.model.data.removeModelItem);

  // router.post('/api/model/data/improt', controller.api.model.data.improt);
};
