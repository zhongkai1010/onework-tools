/*
 * @Author: 钟凯
 * @Date: 2021-03-10 21:11:42
 * @LastEditTime: 2021-03-14 14:16:19
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\router.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { Application } from 'egg';

export default (app: Application) => {
  const { controller, router } = app;

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

  router.get('/api/model/data/get', controller.api.model.data.get);
  router.post('/api/model/data/insert', controller.api.model.data.insert);
  router.post('/api/model/data/getlist', controller.api.model.data.getlist);
  router.patch('/api/model/data/update', controller.api.model.data.update);
  router.post('/api/model/data/remove', controller.api.model.data.remove);
  router.get('/api/model/data/search', controller.api.model.data.search);

  router.post('/api/model/data/item/insert', controller.api.model.dataItem.insert);
  router.post('/api/model/data/item/getList', controller.api.model.dataItem.getList);
  router.post('/api/model/data/item/update', controller.api.model.dataItem.update);
  router.post('/api/model/data/item/remove', controller.api.model.dataItem.remove);

  router.post('/api/model/data/behavior/insert', controller.api.model.dataBehavior.insert);
  router.post('/api/model/data/behavior/getList', controller.api.model.dataBehavior.getList);
  router.post('/api/model/data/behavior/update', controller.api.model.dataBehavior.update);
  router.post('/api/model/data/behavior/remove', controller.api.model.dataBehavior.remove);

  router.get('/api/database/scheme/getData', controller.api.database.scheme.getSchemeData);
  router.get('/api/database/scheme/getDatabases', controller.api.database.scheme.getDatabases);
  router.get('/api/database/scheme/getTables', controller.api.database.scheme.getTables);

  router.get('/api/database/scheme/getTable', controller.api.database.scheme.getTable);
  router.post('/api/database/scheme/syncDataBase', controller.api.database.scheme.syncDataBase);

  router.post('/api/database/connection/insert', controller.api.database.connection.insert);
  router.get('/api/database/connection/getlist', controller.api.database.connection.getlist);
  router.post('/api/database/connection/update', controller.api.database.connection.update);
  router.post('/api/database/connection/remove', controller.api.database.connection.remove);

  // router.get('/api/database/table/get', controller.api.database.table.get);
};
