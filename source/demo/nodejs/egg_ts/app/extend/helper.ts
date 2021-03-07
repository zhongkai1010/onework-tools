/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-11-01 14:25:37
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-03-07 08:42:34
 * @Description:
 * @FilePath: \egg_ts\app\extend\helper.ts
 */


import { RequestResult } from '../../typings/app';
import errorCode from '../core/errorCode';

/**
 * @description 包裹其
 * @param {any} data 12
 * @param {*} success 12
 * @param {any} error 12
 * @return {*}  12
 */
function getRequestWrapper(data: any = null, success = false, error: any) : RequestResult {
  return {
    data,
    success,
    error,
  };
}

/**
 * @description: 12
 * @param {string} code 12
 * @param {*} message 112
 * @return {*} 12
 */
function getResponseErrorCode(code: string | number, message = 'internal server error'): RequestResult {
  const msg = code ? errorCode[code] : message;
  return {
    data: null,
    success: false,
    error: {
      message: msg,
      code,
    },
  };
}

/**
 * @description 12
 * @param {number} num 12
 * @param {number} n 12
 * @return {*} 12
 */
function prefixInteger(num:number, n:number) {
  return (Array(n).join('0') + num).slice(-n);
}

export default {
  getRequestWrapper,
  getResponseErrorCode,
  prefixInteger,
};

