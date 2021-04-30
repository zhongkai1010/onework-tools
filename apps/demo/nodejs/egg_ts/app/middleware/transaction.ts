/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:51:31
 * @LastEditTime: 2021-03-07 00:47:21
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\middleware\transaction.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
/*
 * @Author: 钟凯
 * @Date: 2021-02-13 22:48:00
 * @LastEditTime: 2021-03-07 00:15:23
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\middleware\transaction_handler.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Context } from 'egg';

const createHook = (hooks : any, ctx:Context) => {
  for (let i = 0; i < hooks.length; i++) {
    const hook = hooks[i];
    ctx.model.addHook(hook, (_, options) => {
      options.transaction = ctx.transaction;
    });
  }
};

const createBulkhooks = (hooks :any, ctx:Context) => {
  for (let i = 0; i < hooks.length; i++) {
    const hook = hooks[i];
    ctx.model.addHook(hook, options => {
      options.transaction = ctx.transaction;
    });
  }
};

// 这里是你自定义的中间件
export default function transactionHandler(): any {
  /**
   * @description 事务处理，参考资料
   *  transaction：https://sequelize.org/master/manual/transactions.html
   *  hooks：https://sequelize.org/master/manual/hooks.html#permanent-hooks--with--code-sequelize-addhook--code--
   *  soucre： https://github.com/sequelize/sequelize/blob/v6/lib/hooks.js#L7
   * @param {*} ctx Context
   * @param {*} next Context
   * @return {*} Context
   */
  return async function transactionHandler(ctx:Context, next) {
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
}

