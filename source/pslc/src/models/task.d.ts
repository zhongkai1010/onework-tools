/*
 * @Author: your name
 * @Date: 2020-11-07 10:19:16
 * @LastEditTime: 2020-11-07 11:52:46
 * @LastEditors: your name
 * @Description: In User Settings Edit
 * @FilePath: \pslc\src\models\task.d.ts
 */
/**
 * @description
 * @author 钟凯
 * @date 07/11/2020
 * @export
 * @interface Task
 */
export interface Task {
  id?: number; //任务Id
  module_id?: string; //分析模块编号
  train_number?: string; //车辆编号
  train_id?: string; //车次
  m_time?: string; //发车时间
  a_time?: string; //到达时间
  route_id?: number; //线路编号, 线路表记录了总里程
  begin_mileage?: number; //开始里程
  end_mileage?: number; //结束里程
  current_mileage?: number; //当前任务录像文件OSD里程读数
  current_mtime?: string; //当前任务录像文件OSD时间读数
  main_driver_name?: string; //主司机姓名
  sub_driver_name?: string; //副司机姓名
  status_code?: TaskStatus; //为空任务准备中, 任务状态码 0:"文件上传完成"，1:"文件转换完成",2: "排队中", 3 "分析中", 4: "任务结束", 5: "已停止",6:"异常中止"
  status_message?: string; //任务状态消息,如有异常情况记录
  user_id: number; //创建任务的用户编号
  createdAt?: string; //创建时间
  updatedAt?: string; //更新时间
}

/**
 * 任务状态码 A:"文件上传完成"，B:"文件转换完成",C: "排队中", D:"分析中", E: "任务结束", F: "已停止",G:"异常中止"
 * @description
 * @author 钟凯
 * @date 07/11/2020
 * @export
 * @interface TaskStatus
 */
export enum TaskStatus {
  A = 0,
  B = 1,
  C = 2,
  D = 3,
  E = 4,
  F = 5,
  G = 6,
}
