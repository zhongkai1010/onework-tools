/*
 * @Author: 钟凯
 * @Date: 2021-03-10 21:11:42
 * @LastEditTime: 2021-04-10 09:06:35
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\router.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { Application, Context } from 'egg';
import route, { RouteData } from '../app/core/decorators/router';

export default (app: Application) => {
  const { router } = app;
  // 处理路由装饰器
  route.routes.forEach((t:RouteData) => {
    router[t.method](t.key, ...t.middlewares, async (ctx: Context) => {
      const fun = new t.action(ctx);
      await fun[t.name](ctx);
    });
  });
  console.log(route.routes);
  // router.post('/api/model/item/insert', controller.api.model.item.insert);
  // router.post('/api/model/item/getlist', controller.api.model.item.getlist);
  // router.patch('/api/model/item/update', controller.api.model.item.update);
  // router.put('/api/model/item/save', controller.api.model.item.save);
  // router.post('/api/model/item/remove', controller.api.model.item.remove);
  // router.get('/api/model/item/search', controller.api.model.item.search);

  // router.post('/api/model/collection/insert', controller.api.model.collection.insert);
  // router.post('/api/model/collection/getlist', controller.api.model.collection.getlist);
  // router.patch('/api/model/collection/update', controller.api.model.collection.update);
  // router.post('/api/model/collection/remove', controller.api.model.collection.remove);
  // router.get('/api/model/collection/search', controller.api.model.collection.search);

  // router.get('/api/model/data/get', controller.api.model.data.get);
  // router.post('/api/model/data/insert', controller.api.model.data.insert);
  // router.post('/api/model/data/getlist', controller.api.model.data.getlist);
  // router.patch('/api/model/data/update', controller.api.model.data.update);
  // router.post('/api/model/data/remove', controller.api.model.data.remove);
  // router.get('/api/model/data/search', controller.api.model.data.search);

  // router.post('/api/model/data/item/insert', controller.api.model.dataItem.insert);
  // router.post('/api/model/data/item/getList', controller.api.model.dataItem.getList);
  // router.post('/api/model/data/item/update', controller.api.model.dataItem.update);
  // router.post('/api/model/data/item/remove', controller.api.model.dataItem.remove);

  // router.post('/api/model/data/behavior/insert', controller.api.model.dataBehavior.insert);
  // router.post('/api/model/data/behavior/getList', controller.api.model.dataBehavior.getList);
  // router.post('/api/model/data/behavior/update', controller.api.model.dataBehavior.update);
  // router.post('/api/model/data/behavior/remove', controller.api.model.dataBehavior.remove);

  // router.get('/api/database/scheme/getData', controller.api.database.scheme.getSchemeData);
  // router.get('/api/database/scheme/getDatabases', controller.api.database.scheme.getDatabases);
  // router.get('/api/database/scheme/getTables', controller.api.database.scheme.getTables);
  // router.get('/api/database/scheme/getTableColumns', controller.api.database.scheme.getTableColumns);
  // router.post('/api/database/scheme/syncDataBase', controller.api.database.scheme.syncDataBase);

  // router.post('/api/database/connection/add', controller.api.database.connection.insert);
  // router.get('/api/database/connection/getlist', controller.api.database.connection.getlist);
  // router.post('/api/database/connection/update', controller.api.database.connection.update);
  // router.post('/api/database/connection/remove', controller.api.database.connection.remove);

  // router.get('/api/tool/comparison/add', controller.api.tool.comparison.insert);
  // router.get('/api/tool/comparison/getlist', controller.api.tool.comparison.getList);
  // router.get('/api/tool/comparison/update', controller.api.tool.comparison.update);
  // router.get('/api/tool/comparison/remove', controller.api.tool.comparison.remove);

  // router.get('/api/tool/translation/add', controller.api.tool.translation.insert);
  // router.get('/api/tool/translation/getlist', controller.api.tool.translation.getList);
  // router.get('/api/tool/translation/update', controller.api.tool.translation.update);
  // router.get('/api/tool/translation/remove', controller.api.tool.translation.remove);

  // router.get('/api/tool/comparison/test', controller.api.tool.comparison.getData);
};
