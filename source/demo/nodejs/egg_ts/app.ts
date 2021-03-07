/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:25:28
 * @LastEditTime: 2021-03-07 22:20:57
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import { Boot } from 'egg';

class AppBootHoos extends Boot {

  async serverDidReady() {
    // await this.app.model.sync({ alter: true });
    // await this.app.model.sync({ force: true });
  }
}

export default AppBootHoos;
