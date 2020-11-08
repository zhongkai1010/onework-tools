/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-10-30 10:06:09
 * @LastEditors: Please set LastEditors
 * @LastEditTime: 2020-11-08 21:06:37
 * @Description:
 * @FilePath: \pslc\src\models\task.ts
 */
import { Effect, Reducer } from 'umi';
import { getDriverList, createDriver, updateDriver, deleteDriver } from '@/services/user';
import { Driver } from './user.d';

/**
 * 司机页面状态
 *
 * @export
 * @interface DriverPageState
 */
export interface DriverPageState {
  data: Array<Driver>;
  dataTotal: number;
  search: any;
}

/**
 *  司机页面model
 *
 * @export
 * @interface DriverModelType
 */
export interface DriverModelType {
  namespace: 'driver';
  state: DriverPageState;
  effects: {
    load: Effect; //检索
    add: Effect;
    update: Effect;
    deleteDriver: Effect;
  };
  reducers: {
    setListData: Reducer<DriverPageState>;
  };
}

const DriverModel: DriverModelType = {
  namespace: 'driver',
  state: {
    data: [],
    dataTotal: 0,
    search: {},
  },
  effects: {
    *load({ payload }, { call, put }) {
      const data = yield call(getDriverList, payload);
      yield put({ type: 'setListData', payload: data });
    },
    *add({ payload }, { call }) {
      yield call(createDriver, payload);
    },
    *update({ payload }, { call }) {
      yield call(updateDriver, payload);
    },
    *deleteDriver({ payload }, { call }) {
      yield call(deleteDriver, payload);
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

export default DriverModel;
