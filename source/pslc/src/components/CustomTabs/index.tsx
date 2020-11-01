/*
 * @Author: 钟凯
 * @Date: 2020-10-30 20:47:26
 * @Last Modified by: 钟凯
 * @Last Modified time: 2020-10-30 20:47:54
 */
import * as React from 'react';
import { Tabs } from 'antd';
import Task from '@/pages/Task/Index';
import Analysis from '@/pages/Analysis/Index';
import Driver from '@/pages/Driver/Index';
import Line from '@/pages//Line/Index';
import Storage from '@/pages/Storage/Index';
import styles from './index.less';
import { TabType } from '@/models/index';

const { TabPane } = Tabs;

export interface IAppProps {
  tabKey: TabType;
  onTabClick?: (activeKey: string, e: React.KeyboardEvent | React.MouseEvent) => void;
  analysisTabDisabled: boolean;
}

/**
 * @description
 * @author 钟凯
 * @date 30/10/2020
 * @class CustomTabs
 * @extends {React.Component<IAppProps>}
 */
class CustomTabs extends React.Component<IAppProps> {
  public render() {
    const { onTabClick, analysisTabDisabled, tabKey } = this.props;
    console.log('CustomTabs', tabKey);
    return (
      <Tabs
        defaultActiveKey={TabType.task}
        type="card"
        activeKey={tabKey}
        tabBarGutter={10}
        animated={false}
        tabBarStyle={{ margin: '0px' }}
        onTabClick={onTabClick}
        size="large"
      >
        <TabPane tab="任务列表" key={TabType.task} className={styles.tab_panel}>
          <Task />
        </TabPane>
        <TabPane
          tab="视频分析"
          key={TabType.analysis}
          disabled={analysisTabDisabled}
          className={styles.tab_panel}
        >
          <Analysis />
        </TabPane>
        <TabPane tab="司机管理" key={TabType.driver} className={styles.tab_panel}>
          <Driver />
        </TabPane>
        <TabPane tab="线路管理" key={TabType.line} className={styles.tab_panel}>
          <Line />
        </TabPane>
        <TabPane tab="存储管理" key={TabType.storage} className={styles.tab_panel}>
          <Storage />
        </TabPane>
      </Tabs>
    );
  }
}
export default CustomTabs;
