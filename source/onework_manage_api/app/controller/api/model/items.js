/*
 * @Author: 钟凯
 * @Date: 2021-02-11 19:22:50
 * @LastEditTime: 2021-02-13 07:13:58
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\items.js
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

const Controller = require('../../../core/base_controller');

class ItemController extends Controller {
  /**
   * @description: 添加数据项
   * @param {*}
   * @return {*}
   */
  async insert() {
    const ctx = this.ctx;
    const query = { limit: this.toInt(ctx.query.limit), offset: this.toInt(ctx.query.offset) };
    ctx.body = await ctx.model.User.findAll(query);
  }

  /**
   * @description:  获取数据项列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
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
   * @description:  修改数据项（单条）
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const { name, age } = ctx.request.body;
    const user = await ctx.model.User.create({ name, age });
    ctx.status = 201;
    ctx.body = user;
  }

  /**
   * @description:  保存数据项（新增或修改）
   * @param {*}
   * @return {*}
   */
  async save() {
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

  /**
   * @description: 删除数据项
   * @param {*}
   * @return {*}
   */
  async remove() {
    this.failure();
  }

  /**
   * @description: 检索数据项（关键字、限制10条）
   * @param {*}
   * @return {*}
   */
  async search() {
    this.failure();
  }
}

module.exports = ItemController;
