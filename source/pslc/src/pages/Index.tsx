import * as React from 'react';
import CustomTabs from '@/components/CustomTabs';
import { Loading, connect, Dispatch } from 'umi';
import { IndexPageData } from '@/models/index';

import { TabPaneProps } from 'antd/lib/tabs';

export interface Props {
  dispatch: Dispatch;
  index: IndexPageData;
}

export interface State {}

class Index extends React.Component<Props, State> {
  tab = React.createRef<any>();
  componentDidMount() {}
  tabOnTabClick = (key: string) => {
    const { dispatch } = this.props;
    console.log('tabOnTabClick',key.toString())
    dispatch({
      type: 'index/setTabKey',
      payload: key,
    });
  };
  render() {
    const { tabKey, analysisTabDisabled } = this.props.index;
    console.log('tabKey', tabKey);
    return (
      <CustomTabs
        ref={this.tab}
        tabKey={tabKey}
        onTabClick={this.tabOnTabClick}
        analysisTabDisabled={analysisTabDisabled}
      />
    );
  }
}

export default connect(({ index, loading }: { index: any; loading: Loading }) => ({
  loading: loading.models.index,
  index: index,
}))(Index);
