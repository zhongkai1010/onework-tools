/*
 * @Author: your name
 * @Date: 2021-05-18 19:59:08
 * @LastEditTime: 2021-05-19 09:26:16
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ow-node-manage-api\app\middleware\validate.js
 */
'use strict';
const ApiVerify = require('../core/api_verify');

module.exports = () => {
  return async function validateHandler(ctx, next) {
    // TODO 需要考虑多种不同请求方式
    const path = `${ctx.method.toLocaleLowerCase()} ${ctx.originalUrl}`;
    if (ApiVerify[path]) {
      if (ctx.method.toLocaleLowerCase() === 'post') {
        ctx.validate(ApiVerify[path], ctx.request.body);
      } else {
        ctx.validate(ApiVerify[path], ctx.request.query);
      }
    }
    await next();

  };
};

