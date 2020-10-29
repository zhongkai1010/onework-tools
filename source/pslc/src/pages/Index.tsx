import * as React from 'react';
import { Tabs } from 'antd';
import Task from '@/pages/Task/Index';
import Analysis from '@/pages/Analysis/Index';
import Driver from '@/pages/Driver/Index';
import Line from '@/pages//Line/Index';
import Storage from '@/pages/Storage/Index';
import styles from './Index.less';
import { Loading, connect, Dispatch } from 'umi';

const { TabPane } = Tabs;

export interface Props {
  dispatch: Dispatch;
}

export interface State {}

class Index extends React.Component<Props, State> {
  componentDidMount() {
    console.log('Index_componentDidMount');
  }
  render() {
    const tabOnChange = () => {
      console.log('tabOnChange', arguments);
    };
    const tabOnTabClick = () => {
      console.log('tabOnTabClick', arguments);
    };
    return (
      <Tabs
        defaultActiveKey="1"
        onChange={tabOnChange}
        type="card"
        tabBarGutter={10}
        animated={false}
        tabBarStyle={{ margin: '0px' }}
        size="large"
        onTabClick={tabOnTabClick}
      >
        <TabPane tab="任务列表" key="1" className={styles.tab_panel}>
          <Task />
        </TabPane>
        <TabPane tab="视频分析" key="2" className={styles.tab_panel}>
          <Analysis />
        </TabPane>
        <TabPane tab="司机管理" key="3" className={styles.tab_panel}>
          <Driver />
        </TabPane>
        <TabPane tab="线路管理" key="4" className={styles.tab_panel}>
          <Line />
        </TabPane>
        <TabPane tab="存储管理" key="5" className={styles.tab_panel}>
          <Storage />
        </TabPane>
      </Tabs>
    );
  }
}

export default connect(({ loading }: { loading: Loading }) => ({
  loading: loading.models.index,
}))(Index);
