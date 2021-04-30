/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-10-15 02:56:11
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-02-14 01:33:53
 * @Description:
 * @FilePath: \onework_manage_api\app\middleware\error_handler.js
 */
'use strict';

module.exports = () => {
  return async function errorHandler(ctx, next) {
    try {
      await next();
    } catch (err) {
      // 异常捕获后，判断是否开启事务，如果开启事务后，就进行事务回滚
      if (ctx.transaction) {
        await ctx.transaction.rollback();
        ctx.transaction = null;
      }
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
        code: err.code ? err.code : 5000,
        message: error,
        details: ctx.app.env === 'local' ? err.errors : undefined,
      });
      ctx.body = JSON.stringify(result);
      ctx.status = status;
    }
  };
};
