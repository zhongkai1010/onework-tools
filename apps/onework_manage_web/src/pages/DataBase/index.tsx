/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:06:46
 * @LastEditTime: 2021-03-24 16:57:23
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { PageContainer } from '@ant-design/pro-layout';
import { Button, Card, Col, Row, Space, Tree } from 'antd';
import React, { useEffect, useState } from 'react';
import EditConnectionModal from './components/EditConnectionModal';
 
import DbDataBaseList from './components/DbDataBaseList';
import DbTableList from './components/DbTableList';
import DbColumnList from './components/DbColumnList';
import DbConnectionList from './components/DbConnectionList';
import TreeHandle from './treeHandle';
import { useRequest } from 'umi';
import * as connectionServices from './services/connection';
import * as schemeServices from './services/scheme';
import {
  CloudOutlined,
  DatabaseOutlined,
  LeftOutlined,
  PlusOutlined,
  TableOutlined,
} from '@ant-design/icons';
import type { EventDataNode } from 'antd/lib/tree';
import type { SchemeNode } from './treeHandle';
import IconButton from '@/components/IconButton';

const DataBase = () => {
  const treeRef = React.createRef<any>();
  const [nodeList, setNodeList] = useState<SchemeNode[]>([]);
  const [treeHandle, setTreeHandle] = useState<TreeHandle>(new TreeHandle());
  const getConnectionOperate = useRequest(connectionServices.getlist, { throwOnError: true });
  const addConnectionOperate = useRequest(connectionServices.insert, { manual: true });
  const delConnectionOperate = useRequest(connectionServices.remove, { manual: true });
  const updateConnectionOperate = useRequest(connectionServices.update, { manual: true });
  const syncDataBaseOperate = useRequest(schemeServices.syncDataBase, { manual: true });
  useEffect(() => {
    const temp = new TreeHandle(getConnectionOperate.data);
    setTreeHandle(temp);
    setNodeList(temp.nodeList);
  }, [getConnectionOperate.data]);

  const getCardTitle = () => {
    const { selectNode } = treeHandle;
    if (!selectNode) return '连接详情';
    switch (selectNode.type) {
      case 'connection':
        return `${selectNode.source.connection?.name} - 连接`;
      case 'database':
        return `${selectNode.source.database?.name} - 数据库`;
      case 'table':
        return `${selectNode.source.table?.name}(${selectNode.source.table?.code}) - 表`;
      default:
        return '连接详情';
    }
  };
  const renderIcon = (node: any) => {
    const schemeNode = node as SchemeNode;
    switch (schemeNode.type) {
      case 'connection':
        return <CloudOutlined style={{ color: schemeNode.isLoad ? 'green' : '#000' }} />;
      case 'database':
        return <DatabaseOutlined style={{ color: schemeNode.isLoad ? 'green' : '#000' }} />;
      case 'table':
        return <TableOutlined />;
      default:
        return <></>;
    }
  };
  return (
    <PageContainer content="公共数据由多项公共数据项组合而成，分离在模型创建中常用的数据，例如：用户、组织等，便于创建模型过程中，快速构建常用的数据项，不需要重复创建，例如：基础模板、数据模板、状态模板、模型模板组合。">
      <Row gutter={18}>
        <Col span={6} onContextMenu={(e) => e.preventDefault()}>
          <Card
            title="连接"
            bordered={false}
            loading={getConnectionOperate.loading}
            extra={
              <Space>
                <EditConnectionModal
                  title="添加连接"
                  trigger={<Button icon={<PlusOutlined />} type="text" />}
                  onFinish={async (data) => {
                    const connection = await addConnectionOperate.run(data);
                    const schemeNode = TreeHandle.transformConnection(connection);
                    treeHandle.addNode(schemeNode);
                    setNodeList(treeHandle.nodeList.slice());
                    return Promise.resolve(true);
                  }}
                />
                <IconButton
                  loading={getConnectionOperate.loading}
                  onClick={async () => {
                    await getConnectionOperate.run();
                  }}
                />
              </Space>
            }
          >
            <Tree.DirectoryTree
              ref={treeRef}
              showIcon
              defaultExpandParent={false}
              expandAction={false}
              expandedKeys={treeHandle.getExpandedKeys()}
              loadedKeys={treeHandle.getLoadedKeys()}
              selectedKeys={treeHandle.getSelectedKeys()}
              icon={renderIcon}
              onExpand={(_expandedKeys, { expanded, node }) => {
                treeHandle.setNodeExpand(node.key, expanded);
                setNodeList(treeHandle.nodeList.slice());
              }}
              onSelect={(_, { node }) => {
                treeHandle.setNodeSelected(node.key);
                setNodeList(treeHandle.nodeList.slice());
              }}
              loadData={async (node: EventDataNode) => {
                const schemeNode = (node as unknown) as SchemeNode;
                await treeHandle.loadNode(schemeNode.key);
                setNodeList(treeHandle.nodeList.slice());
              }}
              treeData={TreeHandle.getTreeData(nodeList)}
            />
          </Card>
        </Col>
        <Col span={18}>
          <Card
            title={getCardTitle()}
            loading={getConnectionOperate.loading}
            extra={
              treeHandle.selectNode !== null ? (
                <IconButton
                  title="返回"
                  icon={<LeftOutlined />}
                  onClick={async () => {
                    const parentKey = treeHandle.selectNode?.parentKey as string;
                    if (parentKey === null) {
                      treeHandle.cancelNodeSelected();
                    } else {
                      treeHandle.setNodeSelected(parentKey);
                    }
                    setNodeList(treeHandle.nodeList.slice());
                    Promise.resolve();
                  }}
                />
              ) : (
                <></>
              )
            }
          >
            {treeHandle.selectNode === undefined ? (
              <DbConnectionList
                connections={treeHandle.connections}
                loadDatabase={async (connection) => {
                  await treeHandle.loadNode(connection.uid);
                  treeHandle.setNodeLoaded(connection.uid, true);
                  setNodeList(treeHandle.nodeList);
                }}
                updateDatabase={async (connection) => {
                  const newConnection = await updateConnectionOperate.run(connection);
                  const connectionNode = TreeHandle.transformConnection(newConnection);
                  treeHandle.replaceNode(connectionNode.key, connectionNode);
                  setNodeList(treeHandle.nodeList.slice());
                  return Promise.resolve(true);
                }}
                deleteDatabase={async (connection) => {
                  await delConnectionOperate.run([connection.uid]);
                  treeHandle.deleteNode(connection.uid);
                  setNodeList(treeHandle.nodeList.slice());
                }}
              />
            ) : (
              <></>
            )}
            {treeHandle.selectNode?.type === 'connection' ? (
              <DbDataBaseList
                node={treeHandle.selectNode}
                databases={treeHandle.getNodeChildrens<API.DataBase.Database>(
                  treeHandle.selectNode.key.toString(),
                  'database',
                )}
                syncDatabase={async (database, connection) => {
                  const connNode = TreeHandle.transformConnection(connection);
                  const newDatabase = await syncDataBaseOperate.run({
                    uid: connection.uid,
                    database: database.name,
                  });
                  const databaseNode = TreeHandle.transformDataBase(connNode, newDatabase);
                  treeHandle.replaceNode(databaseNode.key, databaseNode);
                  await treeHandle.loadNode(databaseNode.key);
                  setNodeList(treeHandle.nodeList.slice());
                }}
                loadTable={async (database, connection) => {
                  const connNode = TreeHandle.transformConnection(connection);
                  const databaseNode = TreeHandle.transformDataBase(connNode, database);
                  await treeHandle.loadNode(databaseNode.key);
                  setNodeList(treeHandle.nodeList.slice());
                }}
                deleteTable={() => {
                  return Promise.resolve();
                }}
                loadDatabase={async (node) => {
                  await treeHandle.loadNode(node.key);
                  setNodeList(treeHandle.nodeList.slice());
                }}
              />
            ) : (
              <></>
            )}
            {treeHandle.selectNode?.type === 'database' ? (
              <DbTableList
                node={treeHandle.selectNode}
                showColumn={(databaseNode, table) => {
                  const node = TreeHandle.transformTabel(databaseNode, table);
                  treeHandle.setNodeSelected(node.key);
                  setNodeList(treeHandle.nodeList.slice());
                }}
                tables={treeHandle.getNodeChildrens<API.DataBase.Table>(
                  treeHandle.selectNode.key.toString(),
                  'table',
                )}
                syncDatabase={async (node) => {
                  if (node.source.connection && node.source.database) {
                    const { connection, database } = node.source;
                    const newDatabase = await syncDataBaseOperate.run({
                      uid: connection.uid,
                      database: database.name,
                    });
                    const connectionNode = TreeHandle.transformConnection(connection);
                    const newDatabaseNode = TreeHandle.transformDataBase(
                      connectionNode,
                      newDatabase,
                    );
                    treeHandle.replaceNode(node.key, newDatabaseNode);
                    await treeHandle.loadNode(newDatabaseNode.key);
                    setNodeList(treeHandle.nodeList.slice());
                  }
                }}
                loadTable={async (node) => {
                  await treeHandle.loadNode(node.key);
                  setNodeList(treeHandle.nodeList.slice());
                }}
              />
            ) : (
              <></>
            )}
            {treeHandle.selectNode?.type === 'table' ? (
              <DbColumnList node={treeHandle.selectNode} treeHandle={treeHandle} />
            ) : (
              <></>
            )}
          </Card>
        </Col>
      </Row>
    </PageContainer>
  );
};

export default DataBase;
