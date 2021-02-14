/*
 * @Author: 钟凯
 * @Date: 2021-02-13 22:00:56
 * @LastEditTime: 2021-02-14 19:28:38
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\core\appError.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const errorCode = require('../core/errorCode');

class AppError extends Error {
  constructor(code) {
    const names = Object.getOwnPropertyNames(errorCode);
    let message = '未知异常';
    if (names.includes(String(code))) {
      message = errorCode[code];
    }
    super(message);
    this.code = code;
    this.message = message;
    this.name = 'apperror';
  }
}
module.exports = AppError;
