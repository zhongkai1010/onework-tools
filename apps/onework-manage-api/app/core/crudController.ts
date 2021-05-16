/*
 * @Author: 钟凯
 * @Date: 2021-03-06 19:37:16
 * @LastEditTime: 2021-04-15 10:20:38
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\core\crudController.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import { BaseController } from '../core/index';
import { ModelCtor } from 'sequelize';


export default abstract class CrudControllerController<T extends Egg.Sequelize.BaseModel> extends BaseController {
  model:ModelCtor<T>;

  public abstract get():Promise<void>;

  public abstract add():Promise<void>;

  public abstract update():Promise<void>;

  public abstract getList():Promise<void>;

  protected async internalGet() {
    const query = this.ctx.request.query as unknown as Egg.Sequelize.BaseModel;
    const model = await this.model.findByPk(query.uid);
    this.success(model?.dataValues);
  }

  protected async internalAdd() {
    const body = this.ctx.request.body;
    const model = await this.model.create(body);
    this.success(model.dataValues);
  }

  protected async internalUpdate() {
    const body = this.ctx.request.body as T;
    const uidModel = body as unknown as Egg.Sequelize.BaseModel;
    let model = await this.model.findByPk(uidModel.uid);
    if (!model) {
      this.failure('uid not find model');
    } else {
      const keys = Object.keys(model.dataValues);
      for (const key in body) {
        if (keys.includes(key)) {
          model[key] = body[key];
        }
      }
      model = await model.save();
      this.success(model.dataValues);
    }
  }

  protected async internalGetList() {
    const data = await this.model.findAll();
    this.success(data.map(t => t.dataValues));
  }

  protected async internalGetPageList() {
    const data = await this.model.findAndCountAll();
    const rows = data.rows.map(t => t.dataValues);
    this.success({ count: data.count, rows });
  }
}

