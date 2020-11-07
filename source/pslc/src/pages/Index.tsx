import * as React from 'react';
import CustomTabs from '@/components/CustomTabs';
import { Loading, connect, Dispatch } from 'umi';
import { IndexPageState } from '@/models/index';
import styles from './Index.less';

export interface Props {
  dispatch: Dispatch;
  index: IndexPageState;
}

export interface State {}

class Index extends React.Component<Props, State> {
  tab = React.createRef<any>();
  componentDidMount() {}
  tabOnTabClick = (key: string) => {
    const { dispatch } = this.props;
    console.log('tabOnTabClick', key);
    dispatch({
      type: 'index/setTabKey',
      payload: key,
    });
  };
  render() {
    const { tabKey, analysisTabDisabled } = this.props.index;
   
    return (
      <div>
        <CustomTabs
          ref={this.tab}
          tabKey={tabKey}
          onTabClick={this.tabOnTabClick}
          analysisTabDisabled={analysisTabDisabled}
        />
        <div className={styles.user_container}>指导司机王师傅，已登录</div>
      </div>
    );
  }
}

export default connect(({ index, loading }: { index: any; loading: Loading }) => ({
  loading: loading.models.index,
  index: index,
}))(Index);
