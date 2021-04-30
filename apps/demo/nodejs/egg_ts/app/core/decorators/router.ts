/*
 * @Author: 钟凯
 * @Date: 2021-03-22 10:05:42
 * @LastEditTime: 2021-03-31 17:02:46
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\core\decorators\router.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import { Middleware } from 'koa';

export type RouteData = {
  key:string; // 路由url
  middlewares: Middleware[]; // 路由中间件
  action:any; // 路由具体执行函数
  name:string; // 函数名称
  method:string; // 路由请求方式
  queryRule?:any
  bodyRule?:any
};

class Route {
  routes:RouteData[];
  constructor() {
    this.routes = [];
  }
  put(url: string, ...beforeMiddlewares: Middleware[]) {
    return this.verb('put', url, ...beforeMiddlewares);
  }
  patch(url: string, ...beforeMiddlewares: Middleware[]) {
    return this.verb('patch', url, ...beforeMiddlewares);
  }
  del(url: string, ...beforeMiddlewares: Middleware[]) {
    return this.verb('del', url, ...beforeMiddlewares);
  }
  options(url: string, ...beforeMiddlewares: Middleware[]) {
    return this.verb('options', url, ...beforeMiddlewares);
  }
  get(url: string, ...beforeMiddlewares: Middleware[]) {
    return this.verb('get', url, ...beforeMiddlewares);
  }
  post(url: string, ...beforeMiddlewares: Middleware[]) {
    return this.verb('post', url, ...beforeMiddlewares);
  }

  verb(method:string, url: string, ...beforeMiddlewares: Middleware[]) {
    return (target:any, propertyKey: string) => {
      this.routes.push({
        key: url,
        middlewares: beforeMiddlewares,
        action: target.constructor,
        name: propertyKey,
        method,
      });
    };
  }

}

export default new Route();

