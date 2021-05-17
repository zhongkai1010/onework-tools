/*
 * @Author: 钟凯
 * @Date: 2021-03-31 14:56:25
 * @LastEditTime: 2021-03-31 15:51:00
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\core\index.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const AppCode = require('./app_code');
const AppError = require('./app_error');
const BaseController = require('./base_controller');
const CrudController = require('./crud_controller');
const ErrorCode = require('./app_error_code');


module.exports = {
  AppCode,
  AppError,
  BaseController,
  CrudController,
  ErrorCode,
};
