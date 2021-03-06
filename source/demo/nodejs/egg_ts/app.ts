/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:25:28
 * @LastEditTime: 2021-03-06 23:42:50
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import { Boot } from 'egg';

class AppBootHoos extends Boot {

  serverDidReady() {
    console.log('serverDidReady');
  }
}

export default AppBootHoos;
