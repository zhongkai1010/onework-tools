import React from 'react';
import { Layout } from 'antd';
import styles from './Index.less';

const { Content } = Layout;

const Index: React.FC = ({ children }) => (
  <Layout>
    <Content className={styles.content_container}> {children}</Content>
  </Layout>
);

export default Index;
