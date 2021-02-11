/*
 * @Author: 钟凯
 * @Date: 2021-02-11 19:22:50
 * @LastEditTime: 2021-02-12 01:25:03
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\items.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
/*
 * @Author: 钟凯
 * @Date: 2021-02-11 19:22:50
 * @LastEditTime: 2021-02-11 19:22:50
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\users.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../core/base_controller');

class ItemController extends Controller {
  /**
   * @description: 获取数据项列表，包含分页、排序、检索等功能。
   * @param {*}
   * @return {*}
   */
  async getItemList() {
    const ctx = this.ctx;
    const query = { limit: this.toInt(ctx.query.limit), offset: this.toInt(ctx.query.offset) };
    ctx.body = await ctx.model.User.findAll(query);
  }

  /**
   * @description:  修改数据项
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const id = this.toInt(ctx.params.id);
    const user = await ctx.model.User.findByPk(id);
    if (!user) {
      ctx.status = 404;
      return;
    }

    const { name, age } = ctx.request.body;
    await user.update({ name, age });
    ctx.body = user;
  }

  /**
   * @description:  批量操作数据项，包含：新增、修改等功能。
   * @param {*}
   * @return {*}
   */
  async batchSave() {
    const ctx = this.ctx;
    const { name, age } = ctx.request.body;
    const user = await ctx.model.User.create({ name, age });
    ctx.status = 201;
    ctx.body = user;
  }

  /**
   * @description:  移除数据项，进行软删除。
   * @param {*}
   * @return {*}
   */
  async remove() {
    const ctx = this.ctx;
    const id = this.toInt(ctx.params.id);
    const user = await ctx.model.User.findByPk(id);
    if (!user) {
      ctx.status = 404;
      return;
    }

    await user.destroy();
    ctx.status = 200;
  }
}

module.exports = ItemController;
