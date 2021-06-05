/*
 * @Author: your name
 * @Date: 2021-05-18 17:41:48
 * @LastEditTime: 2021-05-18 19:44:42
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ow-node-manage-api\app\middleware\transaction.js
 */
'use strict';

const createHook = (hooks, ctx) => {
  for (let i = 0; i < hooks.length; i++) {
    const hook = hooks[i];
    ctx.model.addHook(hook, (_, options) => {
      options.transaction = ctx.transaction;
    });
  }
};

const createBulkhooks = (hooks, ctx) => {
  for (let i = 0; i < hooks.length; i++) {
    const hook = hooks[i];
    ctx.model.addHook(hook, options => {
      options.transaction = ctx.transaction;
    });
  }
};

module.exports = () => {
  /**
   * @description 事务处理，参考资料
   *  transaction：https://sequelize.org/master/manual/transactions.html
   *  hooks：https://sequelize.org/master/manual/hooks.html#permanent-hooks--with--code-sequelize-addhook--code--
   *  soucre： https://github.com/sequelize/sequelize/blob/v6/lib/hooks.js#L7
   * @param {*} ctx Context
   * @param {*} next Context
   * @return {*} Context
   */
  return async function transactionHandler(ctx, next) {
    ctx.transaction = await ctx.model.transaction();
    const hooks = [ 'beforeBulkCreate', 'beforeCreate', 'beforeDestroy', 'beforeUpdate', 'beforeSave', 'beforeUpsert' ];
    const bulkhooks = [ 'beforeBulkDestroy', 'beforeBulkUpdate' ];
    createHook(hooks, ctx);
    createBulkhooks(bulkhooks, ctx);
    // await ctx.helper.sleep(1000);
    await next();
    // 判断事务是否在异常处理中间件中进行回滚，回滚后无法提交事务
    // TODO  Sequelize CLS 可以自动装载事务
    if (ctx.transaction) {
      await ctx.transaction.commit();
    }
  };
};

