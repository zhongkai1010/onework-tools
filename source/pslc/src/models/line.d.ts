/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-11-09 16:52:28
 * @LastEditors: 钟凯
 * @LastEditTime: 2020-11-09 16:54:01
 * @Description:
 * @FilePath: \videoanalyze_web\src\models\line.d.ts
 */
/**
 * @description
 * @author 钟凯
 * @date 07/11/2020
 * @export
 * @interface Task
 */
export interface Line {
  id: number; //线路唯一标识,自增
  name: string; //线路名称
  pointCount: number; //识别项点数
  initial_station: string; //起点站
  terminal_station: string; //终点站
  mileage: number; //总里程
  global_recognition: string; //全局配置项,保存的内容为json
  create_time: string; //创建时间
  update_time: string; //更新时间
}
