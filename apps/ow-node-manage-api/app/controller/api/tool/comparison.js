/*
 * @Author: 钟凯
 * @Date: 2021-03-19 14:34:32
 * @LastEditTime: 2021-04-15 09:42:53
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\controller\api\tool\comparison.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const { CrudController } = require('../../../core/index');

class ComparisonController extends CrudController {
  constructor(ctx) {
    super(ctx);
    this.model = this.ctx.model.Tool.Comparison;

  }


}

module.exports = ComparisonController;
