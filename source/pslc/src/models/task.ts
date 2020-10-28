import { Effect } from 'umi';
import { taskGetList } from '@/services/index';
/**
 * 任务
 *
 * @export
 * @interface Task
 */
export interface Task {
  id: number; //流水号
  uuid: string; //任务Id
  locomotiveNo: string; //机车号?
  trainNo: string; //车次
  driverId: string; //司机Id
  driverName: string; //司机名称
  coDriverId: string; //副司机Id
  coDriverName: string; //副司机名称
  departureDate: string; //发车时间
  lineId: string; //线路Id
  lineName: string; //线路名称
  createdAt: string; //创建时间
  updatedAt: string; //修改时间
  taskStatus: number; //任务状态 0：无、1：排队中、 2：分析中、3：已完成、4：已停止
}

export interface TaskModelType {
  namespace: 'task';
  state: any;
  effects: {
    fetch: Effect;
  };
}

const TaskModel: TaskModelType = {
  namespace: 'task',
  state: {},
  effects: {
    *fetch(_, { call, put }) {
      const response = yield call(taskGetList);
      yield put({
        type: 'save',
        payload: response,
      });
    },
  },
};

export default TaskModel;
