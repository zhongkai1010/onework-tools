/*
 * @Author: 钟凯
 * @Date: 2021-03-19 14:34:32
 * @LastEditTime: 2021-04-15 09:42:53
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\controller\api\tool\comparison.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */


import { CrudController } from '../../../core';
import { Context } from 'egg';
import router from '../../../core/decorators/router';

class ComparisonController extends CrudController<Egg.Sequelize.Tool.Comparison> {
  constructor(ctx:Context) {
    super(ctx);
    this.model = this.ctx.model.Tool.Comparison;

  }

  @router.get('/api/tool/comparison/get')
  public async get() {
    await this.internalGet();
  }

  @router.post('/api/tool/comparison/add')
  public async add() {
    await this.internalAdd();
  }

  @router.post('/api/tool/comparison/update')
  public async update() {
    await this.internalUpdate();
  }

  @router.post('/api/tool/comparison/getList')
  public async getList() {
    await this.internalGetList();
  }

}

export default ComparisonController;
