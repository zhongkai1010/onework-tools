/*
 * @Author: 钟凯
 * @Date: 2021-02-28 15:27:42
 * @LastEditTime: 2021-02-28 15:30:51
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\user\login.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

class LoginController extends Controller {

  async login() {
    this.failure();
  }
}

module.exports = LoginController;
