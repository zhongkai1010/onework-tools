/*
 * @Author: 钟凯
 * @Date: 2020-10-30 21:56:24
 * @Last Modified by: 钟凯
 * @Last Modified time: 2020-10-31 08:49:07
 */
import { Reducer } from 'umi';
import { Task } from '@/models/task';

/**
 * @description Index页面状态
 * @author 钟凯
 * @date 30/10/2020
 * @export
 * @interface IndexPageState
 */
export interface IndexPageState {
  task: Task | any;
  analysisTabDisabled: boolean;
  tabKey: TabType;
}

/** Index页面Tab标签类型
 * @description
 * @author 钟凯
 * @date 30/10/2020
 * @export
 * @enum {number}
 */
export enum TabType {
  task = 'task',
  analysis = 'analysis',
  driver = 'driver',
  line = 'line',
  storage = 'storage',
}

/**
 * @description  Index页面Model
 * @author 钟凯
 * @date 30/10/2020
 * @export
 * @interface IndexModelType
 */
export interface IndexModelType {
  namespace: 'index';
  state: IndexPageState;
  reducers: {
    enableAnalysisTab: Reducer;
    setTabKey: Reducer<IndexPageState | any>;
  };
}

const IndexModel: IndexModelType = {
  namespace: 'index',
  state: {
    tabKey: TabType.task,
    task: {},
    analysisTabDisabled: true,
  },
  reducers: {
    enableAnalysisTab(_state: IndexPageState | any = {}, { payload }) {
      return { task: payload, analysisTabDisabled: false, tabKey: TabType.analysis };
    },
    setTabKey(state = {}, { payload }) {
      state = Object.assign({}, state, {
        tabKey: payload,
      });
      console.log('setTabKey',state)
      return state;
    },
  },
};

export default IndexModel;
