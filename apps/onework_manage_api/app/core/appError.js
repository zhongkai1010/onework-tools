/*
 * @Author: 钟凯
 * @Date: 2021-02-13 22:00:56
 * @LastEditTime: 2021-02-24 21:54:09
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\core\appError.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const errorCode = require('../core/errorCode');

/**
 * @description:  应用异常处理
 * @param {*}
 * @return {*}
 */
class AppError extends Error {
  /**
   * @description: 异常构造函数
   * @param {*} code 文本或编码
   */
  constructor(code) {
    // TODO 考虑异常文本动态参数嵌入
    const names = Object.getOwnPropertyNames(errorCode);
    let message = '未知异常';
    if (names.includes(String(code))) {
      message = errorCode[code];
    } else {
      message = code;
    }
    super(message);
    this.code = code;
    this.message = message;
    this.name = 'apperror';
  }
}
module.exports = AppError;
