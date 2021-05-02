/*
 * @Author: 钟凯
 * @Date: 2021-02-13 22:48:00
 * @LastEditTime: 2021-02-14 17:18:11
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\middleware\transaction_handler.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const createHook = (hooks = [], ctx) => {
  for (let i = 0; i < hooks.length; i++) {
    const hook = hooks[i];
    ctx.model.addHook(hook, (_, options) => {
      options.transaction = ctx.transaction;
    });
  }
};

const createBulkhooks = (hooks = [], ctx) => {
  for (let i = 0; i < hooks.length; i++) {
    const hook = hooks[i];
    ctx.model.addHook(hook, options => {
      options.transaction = ctx.transaction;
    });
  }
};

module.exports = () => {
  /**
   * @description: 事务处理，参考资料
   *  transaction：https://sequelize.org/master/manual/transactions.html
   *  hooks：https://sequelize.org/master/manual/hooks.html#permanent-hooks--with--code-sequelize-addhook--code--
   *  soucre： https://github.com/sequelize/sequelize/blob/v6/lib/hooks.js#L7
   * @param {*} ctx
   * @param {*} next
   * @return {*}
   */
  return async function transactionHandler(ctx, next) {
    ctx.transaction = await ctx.model.transaction();
    const hooks = [ 'beforeBulkCreate', 'beforeCreate', 'beforeDestroy', 'beforeUpdate', 'beforeSave', 'beforeUpsert' ];
    const bulkhooks = [ 'beforeBulkDestroy', 'beforeBulkUpdate' ];
    createHook(hooks, ctx);
    createBulkhooks(bulkhooks, ctx);
    await next();
    // 判断事务是否在异常处理中间件中进行回滚，回滚后无法提交事务
    if (ctx.transaction) {
      await ctx.transaction.commit();
    }
  };
};

