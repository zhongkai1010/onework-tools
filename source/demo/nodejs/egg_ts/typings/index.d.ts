/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-03-07 00:54:43
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\typings\index.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import "egg";
import Transaction from 'sequelize'

declare module "egg" {
  interface RequestResult {
    data: any;
    success: boolean;
    error: RequestError | null;
  }
  interface RequestError {
    message: string;
    code: string| number;
  }
  interface Context {
    dashboard: Transaction | null;
  }
}
