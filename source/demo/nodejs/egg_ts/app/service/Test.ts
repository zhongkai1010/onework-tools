/*
 * @Author: 钟凯
 * @Date: 2021-03-09 09:14:31
 * @LastEditTime: 2021-03-09 17:49:42
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\Test.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';

/**
 * Test Service
 */
export default class Test extends Service {
  /**
   * sayHi to you
   */
  public async sayHi() {
    const result = await this.ctx.model.Database.Connection.findOne();


    return result;
  }
}
