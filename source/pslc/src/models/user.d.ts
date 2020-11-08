/*
 * @Author: your name
 * @Date: 2020-11-08 20:37:27
 * @LastEditTime: 2020-11-08 22:46:36
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \videoanalyze_web\src\models\user.d.ts
 */

/**
 *  司机类型
 * @description
 * @author 钟凯
 * @date 08/11/2020
 * @export
 * @enum {number}
 */
export enum DriverType {
  A = 0,
  B = 1,
  C = 2,
  D = 3,
  E = 4,
  F = 5,
  G = 6,
  H = 7,
}

export interface Driver {
  id?: number; //id
  work_id?: string; //工号
  name?: string; //姓名
  user_type?: DriverType; //0：主司机 ，1：副司机，2：值班员，3：机车调度员，4：队长，5：支部司机，6：指导司机，7：扳道员 空=全部
  work_group?: string; //所在车队
  train_group?: string; //用户名称
  teacher_group?: string; //指导组
  username?: string; //用户名
  create_time?: string; //创建时间
  update_time?: string; //修改时间
}
