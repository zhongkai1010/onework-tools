/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-11-01 14:25:37
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-03-09 14:27:07
 * @Description:
 * @FilePath: \egg_ts\app\extend\helper.ts
 */


import { RequestResult } from '../../typings/app';
import errorCode from '../core/errorCode';


function getRequestWrapper(data: any = null, success = false, error: any) : RequestResult {
  return {
    data,
    success,
    error,
  };
}

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

function prefixInteger(num:number, n:number) {
  return (Array(n).join('0') + num).slice(-n);
}

export default {
  getRequestWrapper,
  getResponseErrorCode,
  prefixInteger,
};

