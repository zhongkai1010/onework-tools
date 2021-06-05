/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-11-01 14:25:37
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-03-09 14:27:07
 * @Description:
 * @FilePath: \egg_ts\app\extend\helper.ts
 */
'use strict';

const { ErrorCode } = require('../core/index');


module.exports = {

  getRequestWrapper(data, success = false, error) {
    return {
      data,
      success,
      error,
    };
  },

  getResponseErrorCode(code, message = 'internal server error') {
    const msg = code ? ErrorCode[code] : message;
    return {
      data: null,
      success: false,
      error: {
        message: msg,
        code,
      },
    };
  },

  prefixInteger(num, n) {
    return (Array(n).join('0') + num).slice(-n);
  },

  sleep(time) {
    return new Promise(resolve => {
      setTimeout(() => {
        resolve();
      }, time || 1000);
    });
  },
};

