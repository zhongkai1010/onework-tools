import { Reducer } from 'umi';
import { Task } from '@/models/task';

/**
 *  首页页面model
 *
 * @export
 * @interface IndexModelType
 */
export interface IndexPageData {
  task: Task;
  analysisTabDisabled: boolean;
  tabKey: string;
}

/**
 *
 *
 * @export
 * @interface IndexModelType
 */
export interface IndexModelType {
  namespace: 'index';
  state: IndexPageData | any;
  reducers: {
    enableAnalysisTab: Reducer;
    setTabKey: Reducer<IndexPageData | any>;
  };
}

const IndexModel: IndexModelType = {
  namespace: 'index',
  state: {
    tabKey: '1',
    task: {},
    analysisTabDisabled: true,
  },
  reducers: {
    enableAnalysisTab(_, { payload }) {
      return { task: payload, analysisTabDisabled: false, tabKey: '2' };
    },
    setTabKey(state, { payload }) {
      Object.assign({}, state, {
        tabKey: payload,
      });
      console.log('reducers',state,payload)
      return state;
    },
  },
};

export default IndexModel;
