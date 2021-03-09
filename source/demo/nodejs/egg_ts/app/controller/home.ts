/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-03-09 16:12:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\controller\home.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import { ModelCtor } from 'sequelize/types';
import CrudControllerController from '../core/crud_controller';

export default class HomeController extends CrudControllerController {

  get model(): ModelCtor<any> {
    return this.ctx.model.Data.Data;
  }

}
