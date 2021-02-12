/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-10-15 02:56:11
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-02-13 07:27:20
 * @Description:
 * @FilePath: \onework_manage_api\app\middleware\error_handler.js
 */
'use strict';

module.exports = () => {
  return async function errorHandler(ctx, next) {
    try {
      await next();
    } catch (err) {
      // 所有的异常都在 app 上触发一个 error 事件，框架会记录一条错误日志
      ctx.app.emit('error', err, ctx);
      const status = err.status || 500;
      // 生产环境时 500 错误的详细错误内容不返回给客户端，因为可能包含敏感信息
      // const error =
      //   status === 500 && ctx.app.config.env === "prod"
      //     ? "Internal Server Error"
      //     : err.message;
      const error = err.message;
      // 从 error 对象上读出各个属性，设置到响应中
      const result = ctx.helper.getRequestWrapper(null, false, {
        message: error,
        details: err.errors,
      });
      ctx.body = JSON.stringify(result);
      ctx.status = status;
    }
  };
};
