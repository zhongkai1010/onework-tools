/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-11-01 14:25:37
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-02-13 07:25:54
 * @Description:
 * @FilePath: \onework_manage_api\app\extend\helper.js
 */
'use strict';

const errorCode = require('./errorCode');

module.exports = {
  /**
   *  请求响应返回结果包裹器
   *
   * @param {*} [data=null]
   * @param {boolean} [success=false]
   * @param {*} [error=null]
   * @returns
   */
  getRequestWrapper: (data = null, success = false, error = null) => {
    return {
      data,
      success,
      error,
    };
  },

  /**
   *  获取请求响应错误对象
   *
   * @param {*} code
   * @param {string} [message="Internal Server Error"]
   * @param {boolean} [success=false]
   * @returns
   */
  getResponseErrorCode: (code, message = 'internal server error') => {
    const msg = code ? errorCode[code] : message;
    return {
      data: null,
      success: false,
      error: {
        message: msg,
        code,
      },
    };
  },

  /**
   *  数字前面补位
   *
   * @param {*} num
   * @param {*} n
   * @returns
   */
  prefixInteger: (num, n) => {
    return (Array(n).join(0) + num).slice(-n);
  },

};
