import type { DataNode } from 'antd/lib/tree';
import { useEffect, useState } from 'react';
import { useRequest } from 'umi';
/*
 * @Author: 钟凯
 * @Date: 2021-03-04 14:30:36
 * @LastEditTime: 2021-03-14 17:15:07
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\treeHandleHook.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import * as connectionServices from './services/connection';
import * as schemeServices from './services/scheme';

export interface SchemeNode extends DataNode {
  type: 'connection' | 'database' | 'table';
  source: {
    connection?: API.DataBase.Connection;
    database?: API.DataBase.Database;
    table?: API.DataBase.Table;
  };
  parentKey: string | null;
  isLoad: boolean;
  isExpand: boolean;
}

export interface TreeHandleHook {
  nodeList: SchemeNode[];
  loading: boolean;
  loadConnection: () => Promise<void>;
  loadDatabase: (node: SchemeNode) => Promise<void>;
  loadTable: (node: SchemeNode) => Promise<void>;
  getTreeData: () => SchemeNode[];
  addConnection: (connection: API.DataBase.Connection) => Promise<void>;
  closeConnection: (node: SchemeNode) => Promise<void>;
  refreshConnection: () => void;
  handleError: (node: SchemeNode) => void;
  getExpandedKeys: () => string[];
  expandNode: (node: SchemeNode, expanded: boolean) => void;
}

const handleConnection = (connection: API.DataBase.Connection) => {
  return {
    type: 'connection',
    key: connection.uid,
    parentKey: null,
    source: { connection },
    title: `${connection.name}(${connection.host})`,
    isLeaf: false,
    isLoad: false,
    isExpand: false,
  } as SchemeNode;
};

const handleDataBase = (connection: SchemeNode, database: API.DataBase.Database) => {
  return {
    key: `${connection?.key}_${database.name}`,
    parentKey: connection?.key.toString(),
    type: 'database',
    source: { database, connection: connection.source.connection },
    title: `${database.name}`,
    isLeaf: false,
    isLoad: false,
    isExpand: false,
  } as SchemeNode;
};

const handleTabel = (database: SchemeNode, table: API.DataBase.Table) => {
  return {
    key: `${database?.key}_${table.uid}`,
    parentKey: database?.key.toString(),
    type: 'table',
    source: { ...database?.source, table },
    title: table.name,
    isLoad: false,
    isLeaf: true,
    isExpand: false,
  } as SchemeNode;
};

const transformNode = (
  type: 'connection' | 'database' | 'table',
  data: (API.DataBase.Connection | API.DataBase.Database | API.DataBase.Table)[],
  node?: SchemeNode,
) => {
  const result = [] as SchemeNode[];
  if (data) {
    for (let i = 0; i < data.length; i += 1) {
      switch (type) {
        case 'connection': {
          const element = data[i] as API.DataBase.Connection;
          result.push(handleConnection(element));
          break;
        }
        case 'database': {
          const element = data[i] as API.DataBase.Database;
          if (!node) throw new Error('transformNode params node is null!');
          result.push(handleDataBase(node, element));
          break;
        }
        case 'table': {
          const element = data[i] as API.DataBase.Table;
          if (!node) throw new Error('transformNode params node is null!');
          result.push(handleTabel(node, element));
          break;
        }
        default:
          break;
      }
    }
  }
  return result;
};

const expandSchemeNode = (
  nodes: SchemeNode[],
  node: SchemeNode,
  expanded: boolean,
): SchemeNode[] => {
  // 收起控制只需要设置isExpand属性，展开需要考虑连接与数据库上下级展开
  if (!expanded) {
    const index = nodes.findIndex((t) => t.key === node.key);
    const newNode = node;
    newNode.isExpand = false;
    nodes.splice(index, 1, newNode);
    return nodes;
  }
  const tempNodeList = nodes.map((t) => {
    return { ...t, isExpand: false };
  });
  const index = tempNodeList.findIndex((t) => t.key === node.key);
  const newNode = node;
  newNode.isExpand = true;
  tempNodeList.splice(index, 1, newNode);
  if (node.type === 'database') {
    // 展开连接的节点
    const connIndex = tempNodeList.findIndex(
      (t) => t.source.connection?.uid === node.source.connection?.uid,
    );
    const connNode = tempNodeList.find(
      (t) => t.source.connection?.uid === node.source.connection?.uid,
    );
    if (connNode != null) {
      connNode.isExpand = true;
      tempNodeList.splice(connIndex, 1, connNode);
    }
  }
  return tempNodeList;
};

export default (): TreeHandleHook => {
  const connectionGetListOperate = useRequest(connectionServices.getlist, {
    throwOnError: true,
    manual: false,
  });
  const getDatabasesOperate = useRequest(schemeServices.getDatabases, {
    manual: true,
    throwOnError: true,
  });
  const getTablesOperate = useRequest(schemeServices.getTables, {
    manual: true,
    throwOnError: true,
  });
  const [nodeList, setNodeList] = useState<(DataNode & SchemeNode)[]>([]);
  /**
   * @description: 加载接口服务中返回的数据库连接集合数据，写入节点列表
   */
  const loadConnection = async () => {
    const datas = await connectionGetListOperate.run();
    const nodes = transformNode('connection', datas);
    setNodeList(nodes);
  };
  /**
   * @description: 加载数据库数据
   * @param {SchemeNode} node 数据库连接节点
   */
  const loadDatabase = async (node: SchemeNode): Promise<void> => {
    // 判断是否已经加载过，如果未加载过请求服务接口进行数据加载
    let tempNodeList = [];
    if (!node.isLoad) {
      const data = await getDatabasesOperate.run({ uid: node.source.connection?.uid });
      const connectionNodes = transformNode('database', data, node);
      tempNodeList = [...nodeList, ...connectionNodes];
    } else {
      tempNodeList = nodeList;
    }
    tempNodeList = tempNodeList.map((t) => {
      return { ...t, isLoad: t.key === node.key ? true : t.isLoad };
    });
    tempNodeList = expandSchemeNode(tempNodeList, node, true);
    setNodeList(tempNodeList);
  };
  /**
   * @description: 加载数据库表
   * @param {*} node 数据库节点
   * @return {*}
   */
  const loadTable = async (node: SchemeNode): Promise<void> => {
    // 判断是否已经加载过，如果未加载过请求服务接口进行数据加载
    let tempNodeList = [] as SchemeNode[];
    if (!node.isLoad) {
      const data = await getTablesOperate.run({
        uid: node.source.connection?.uid,
        database: node.source.database?.name,
      });
      const connectionNodes = transformNode('table', data, node);
      tempNodeList = [...nodeList, ...connectionNodes];
    }
    tempNodeList = tempNodeList.map((t) => {
      return { ...t, isLoad: t.key === node.key ? true : t.isLoad };
    });
    tempNodeList = expandSchemeNode(tempNodeList, node, true);
    setNodeList(tempNodeList);
  };
  /**
   * @description: 刷新数据库连接，初始化所有加载和展开状态
   * @param {*}
   * @return {*}
   */
  const refreshConnection = (): void => {
    connectionGetListOperate.data = undefined;
  };
  /**
   * @description: 关闭连接
   * @param {*} async
   * @return {*}
   */
  const closeConnection = async (node: SchemeNode): Promise<void> => {
    const temp = node;
    temp.isLoad = false;
    temp.isLeaf = false;
    delete temp.children;
    const index = nodeList.findIndex((t) => t.key === node.key);
    const newNodes = nodeList.splice(index, 1, temp);
    setNodeList(newNodes);
  };
  /**
   * @description:  添加连接
   * @param {*} async
   * @return {*}
   */
  const addConnection = async (connection: API.DataBase.Connection) => {
    const seachemNode = handleConnection(connection);
    const tempNodes = nodeList;
    tempNodes.push(seachemNode);
    setNodeList(tempNodes);
  };
  /**
   * @description: 加载失败设置展开状态和子节点
   * @param {SchemeNode} node
   * @return {*}
   */
  const handleError = (node: SchemeNode): void => {
    const temp = node;
    temp.isLoad = false;
    temp.isLeaf = false;
    delete temp.children;
    const index = nodeList.findIndex((t) => t.key === node.key);
    nodeList.splice(index, 1);
    nodeList.splice(index, 0, temp);
    setNodeList(nodeList.slice());
  };

  /**
   * @description: 获取数据结构的树形结构数据
   * @param {*}
   * @return {*}
   */
  const getTreeData = (): any => {
    const root = nodeList.filter((t) => t.type === 'connection');
    const newNodeList = [];
    for (let i = 0; i < root.length; i += 1) {
      const connection = root[i];
      if (connection.isExpand) {
        connection.children = [];
        const temp_children = nodeList.filter((t) => t.parentKey === connection.key);
        for (let j = 0; j < temp_children.length; j += 1) {
          const database = temp_children[j];
          if (database.isExpand) {
            database.children = nodeList.filter((t) => t.parentKey === database.key);
          } else {
            database.children = undefined;
          }
          connection.children.push(database);
        }
      } else {
        connection.children = undefined;
      }

      newNodeList.push(connection);
    }
    return newNodeList;
  };
  /**
   * @description: 获取展开的节点
   * @param {*}
   * @return {*}
   */
  const getExpandedKeys = () => {
    const keys = nodeList.filter((t) => t.isExpand).map((t) => t.key.toString());
    return keys;
  };
  const expandNode = (node: SchemeNode, expanded: boolean): void => {
    const newNodeList = expandSchemeNode(nodeList, node, expanded);
    setNodeList(newNodeList);
  };
  useEffect(() => {
    const datas = connectionGetListOperate.data || [];
    const nodes = transformNode('connection', datas);
    setNodeList(nodes);
  }, [connectionGetListOperate.data]);
  return {
    loadConnection,
    loadDatabase,
    loadTable,
    getTreeData,
    nodeList,
    loading: connectionGetListOperate.loading,
    refreshConnection,
    closeConnection,
    addConnection,
    handleError,
    getExpandedKeys,
    expandNode,
  };
};
