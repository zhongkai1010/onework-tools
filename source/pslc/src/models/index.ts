/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2020-11-02 09:06:37
 * @LastEditors: 钟凯
 * @LastEditTime: 2020-11-05 14:12:21
 * @Description:
 * @FilePath: \pslc\src\models\index.ts
 */
import { Reducer } from 'umi';
import { Task } from '@/models/task';

export interface IndexPageState {
  task: Task | any; //当前选中的任务
  analysisTabDisabled: boolean; //视频分析tab状态
  tabKey: TabType; //当前选中的tab
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
      return state;
    },
  },
};

export default IndexModel;
