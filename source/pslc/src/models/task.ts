import { Effect, Reducer } from 'umi';
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

/**
 * 任务列表搜索参数
 *
 * @export
 * @interface TaskSearchListParams
 */
export interface TaskSearchListParams {}

/**
 * 任务页面状态
 *
 * @export
 * @interface TaskPageState
 */
export interface TaskPageState {
  data: Array<Task>;
  dataTotal: number;
  search: TaskSearchListParams;
}

/**
 *  任务页面model
 *
 * @export
 * @interface TaskModelType
 */
export interface TaskModelType {
  namespace: 'task';
  state: TaskPageState;
  effects: {
    load: Effect; //检索
    add: Effect; //添加
    start: Effect; //启动
    stop: Effect; //停止
  };
  reducers: {
    setListData: Reducer<TaskPageState>;
  };
}

const TaskModel: TaskModelType = {
  namespace: 'task',
  state: {
    data: [],
    dataTotal: 0,
    search: {},
  },
  effects: {
    *load({ payload }, { call, put }) {
     
      const data = yield call(taskGetList, payload);
      yield put({ type: 'setListData', payload: data });
    },
    add: (_, {}) => {},
    start: (_, {}) => {},
    stop: (_, {}) => {},
  },
  reducers: {
    setListData(state = { data: [], dataTotal: 0, search: {} }, { payload }) {
      state.data = payload.result.data;
      state.dataTotal = payload.result.total;
      return state;
    },
  },
};

export default TaskModel;
