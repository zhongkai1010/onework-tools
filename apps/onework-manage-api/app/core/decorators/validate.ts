import { Context } from 'egg';
/*
 * @Author: 钟凯
 * @Date: 2021-03-27 20:03:09
 * @LastEditTime: 2021-03-27 20:18:54
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\core\decorators\validate.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
// export default (route:{queryRule?:any, bodyRule:any}) => {
//     return (target: any, propertyKey: string, descriptor:TypedPropertyDescriptor<Function>) => {
//         const routeData = this.routes.find(t => t.action === target.constructor);
//         if (routeData) {
//           const method = descriptor.value;
//           const newRouteData = { ...routeData, ...route } as RouteData;
//           const index = this.routes.findIndex(t => t.action === target.constructor && t.name === propertyKey);
//           this.routes.splice(index, 0, newRouteData);
//           descriptor.value = () => {
//             // eslint-disable-next-line prefer-rest-params
//             return method?.apply(this, arguments);
//           };
//         }
//       };
// };
export default function validate(route:{queryRule?:any, bodyRule:any}) {
  return function(_target: any, _propertyKey: string, descriptor: any) {
    const method = descriptor.value;
    descriptor.value = function() {
      const ctx = this.ctx as Context;
      if (route.queryRule) {
        ctx.validate(route.queryRule, ctx.request.query);
      }
      if (route.bodyRule) {
        ctx.validate(route.bodyRule, ctx.request.body);
      }
      // eslint-disable-next-line prefer-rest-params
      return method.apply(this, arguments);
    };
  };
}
