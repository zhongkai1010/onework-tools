/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-30 10:06:09
 * @LastEditors: 钟凯
 * @LastEditTime: 2020-11-04 15:05:14
 * @Description:
 * @FilePath: \pslc\src\models\task.ts
 */
import { Effect, Reducer } from 'umi';
import { taskGetList } from '@/services/task';
import { Task } from './task.d';
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
