/*
 * @Author: 钟凯
 * @Date: 2021-02-13 22:00:56
 * @LastEditTime: 2021-05-19 11:13:12
 * @LastEditors: Please set LastEditors
 * @Description:
 * @FilePath: \egg_ts\app\core\appError.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const errorCode = require('./app_error_code');

/**
 * @description:  应用异常处理
 * @param {*}
 * @return {*}
 */
class AppError extends Error {
  /**
   * @description  异常构造函数
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
    this.message = message;
    this.name = 'apperror';
  }
}

module.exports = AppError;
