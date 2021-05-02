/*
 * @Author: your name
 * @Date: 2020-11-05 22:31:44
 * @LastEditTime: 2021-02-23 14:36:38
 * @LastEditors: 钟凯
 * @Description: In User Settings Edit
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\core\errorCode.js
 */
/**
 *  错误编码
 */
'use strict';
const errorCode = {
  // TODO 需要考虑通过编码获取异常文本，便于后续异常文本修改和维护
  5100: '该数据已存在，请重新操作。',
  5101: '该数据不存在，请重新操作。',
  5102: '该数据已被使用，无法进行移除。',
};
module.exports = errorCode;
