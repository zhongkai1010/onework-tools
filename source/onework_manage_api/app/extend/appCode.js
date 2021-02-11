/*
 * Filename: d:\projects\wmsq_api\app\extend\appCode.js
 * Path: d:\projects\wmsq_api
 * Created Date: Wednesday, July 31st 2019, 10:08:45 am
 * Author: zk
 * 用于存储系统状态值
 * Copyright (c) 2019 Your Company
 */
'use strict';

const appCode = {
  loginType: {
    // 登录方式
    phoneLogin: 2, // 手机登录
    accountLogin: 1, // 账户登录
    weiXinLogin: 3, // 微信登录
    faceLogin: 4, // 人脸登录
    tokenLogin: 5, // token登录
    targetLogin: 6, // 程序跳转登录
  },
  smsCode: {
    // 短信验证码类型 1：手机登录，2：重置密码，3：发布票权，4：房产修改，5：删除房产，6：修改会议票权，7：录入纸质票，8：用户投票，9：删除业委会或筹备组成员，10：下载清册数据
    login: 1,
    password: 2,
  },
  appType: {
    // app类型，0：无，1：文明社区，2：灯火app，3:后台管理，4：文件上传
    wenming: 1,
    denghuo: 2,
    manage: 3,
    upload: 4,
  },
};
module.exports = appCode;
