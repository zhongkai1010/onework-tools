/*
 * @Author: 钟凯
 * @Date: 2021-03-04 14:30:36
 * @LastEditTime: 2021-03-16 11:41:57
 * @LastEditors: 钟凯
 * @Description:
 *      1、加载数据库连接
 *      2、加载连接的数据库
 *      3、加载数据库的表
 *      4、设置节点收展状态
 *      5、设置节点加载状态
 *      6、修改节点
 *      7、新增节点
 *      8、删除节点
 *      9、关闭数据库连接
 * @FilePath: \onework_manage_web\src\pages\DataBase\treeHandleHook.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import type { DataNode } from 'antd/lib/tree';
import { useEffect, useState } from 'react';
import { useRequest } from 'umi';
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
  loadAllConnection: () => Promise<void>;
  loadDatabase: (node: SchemeNode) => Promise<void>;
  loadTable: (node: SchemeNode) => Promise<void>;
  getTreeData: () => SchemeNode[];
  addConnection: (connection: API.DataBase.Connection) => Promise<void>;
  deleteConnection: (key: string | number) => Promise<void>;
  updateConnection: (connection: API.DataBase.Connection) => Promise<void>;
  closeConnection: (key: string | number) => void;
  getExpandedKeys: () => string[];
  setExpandNode: (key: string | number, expanded: boolean) => void;
  setLoadedNode: (key: string | number, loaded: boolean) => void;
  getLoadedKeys: () => string[];
}

export const transformConnection = (connection: API.DataBase.Connection) => {
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

export const transformDataBase = (connection: SchemeNode, database: API.DataBase.Database) => {
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

export const transformTabel = (database: SchemeNode, table: API.DataBase.Table) => {
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

export const transformNodes = (
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
          result.push(transformConnection(element));
          break;
        }
        case 'database': {
          const element = data[i] as API.DataBase.Database;
          if (!node) throw new Error('transformNode params node is null!');
          result.push(transformDataBase(node, element));
          break;
        }
        case 'table': {
          const element = data[i] as API.DataBase.Table;
          if (!node) throw new Error('transformNode params node is null!');
          result.push(transformTabel(node, element));
          break;
        }
        default:
          break;
      }
    }
  }
  return result;
};

/**
 * @description: 替换数组中指定key的节点
 * @param {string} key 替换节点的key
 * @param {SchemeNode} nodes 节点集合
 * @param {SchemeNode} newNode 需要替换的节点
 */
export const replaceSchemeNode = (
  key: string | number,
  nodes: SchemeNode[],
  newNode: SchemeNode,
) => {
  const nodeIndex = nodes.findIndex((t) => t.key === key);
  nodes.splice(nodeIndex, 1, newNode);
};

/**
 * @description: 设置数组中指定key的节点指定的属性值
 * @param {string} key
 * @param {string} attribute
 * @param {any} value
 * @param {SchemeNode} nodes
 */
export const setSchemeNodeAttribute = (
  key: string | number,
  attribute: string,
  value: any,
  nodes: SchemeNode[],
): void => {
  const node = nodes.find((t) => t.key === key);
  if (node === undefined) throw new Error(`${key} is not find nodes`);
  if (!Object.keys(node).includes(attribute))
    throw new Error(`${attribute} attribute is not in node attribute`);
  Object.defineProperty(node, attribute, {
    value,
    writable: true,
    enumerable: true,
    configurable: true,
  });
  replaceSchemeNode(key, nodes, node);
};

/**
 * @description: 展开或收起指定key值的节点
 * @param {string} key 收起的节点key
 * @param {SchemeNode} nodes 节点集合
 * @param {boolean} expanded true：展开，false：收起
 * @return {*}
 */
export const expandedSchemeNode = (
  key: string | number,
  nodes: SchemeNode[],
  expanded: boolean = false,
): void => {
  setSchemeNodeAttribute(key, 'isExpand', expanded, nodes);
};

/**
 * @description: 设置指定key值的节点加载状态
 * @param {string} key 节点key值
 * @param {SchemeNode} nodes 节点集合
 * @param {boolean} loaded true：已加载，false：未加载
 * @return {*}
 */
export const loadedSchemeNode = (
  key: string | number,
  nodes: SchemeNode[],
  loaded: boolean = false,
): void => {
  setSchemeNodeAttribute(key, 'isLoad', loaded, nodes);
};

/**
 * @description: 设置所有节点展开状态
 * @param {SchemeNode} nodes 节点集合
 * @param {boolean} expanded true：已加载，false：未加载
 * @return {*}
 */
export const expandedAllSchemeNode = (
  nodes: SchemeNode[],
  expanded: boolean = false,
): SchemeNode[] => {
  return nodes.map((t) => {
    return {
      ...t,
      isExpand: expanded,
    };
  });
};

/**
 * @description:  设置不同类型节点展开属性，内部控制级联关系的展开状态
 * @param {string} key
 * @param {SchemeNode} nodes
 * @param {boolean} expanded
 * @param {*} SchemeNode
 * @return {*}
 */
export const expandTypeNode = (
  key: string | number,
  nodes: SchemeNode[],
  expanded: boolean,
): SchemeNode[] => {
  if (!expanded) {
    expandedSchemeNode(key, nodes, false);
    return nodes;
  }
  // 展开节点的同时，收起同类型节点
  const tempNodeList = expandedAllSchemeNode(nodes, false);
  const node = tempNodeList.find((t) => t.key === key);
  if (node === undefined) throw new Error('key node in nides to keys');
  if (node.source.connection?.uid === undefined) throw new Error('connection node in nides');
  const connectionUid = node.source.connection?.uid;
  const dataBaseName = node.source.database?.name;
  if (node.type === 'table') {
    expandedSchemeNode(connectionUid, tempNodeList, true);
    expandedSchemeNode(`${connectionUid}_${dataBaseName}`, tempNodeList, true);
  }
  if (node.type === 'database') {
    expandedSchemeNode(connectionUid, tempNodeList, true);
  }
  expandedSchemeNode(key, tempNodeList, true);
  return tempNodeList;
};

export default (): TreeHandleHook => {
  const connectionGetListOperate = useRequest(connectionServices.getlist, {
    throwOnError: true,
    manual: false,
  });
  const updateConnectionOperate = useRequest(connectionServices.update, { manual: true });
  const removeConnectionOperate = useRequest(connectionServices.remove, { manual: true });
  const addConnectionOperate = useRequest(connectionServices.insert, { manual: true });
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
  const loadAllConnection = async () => {
    const datas = await connectionGetListOperate.run();
    const nodes = transformNodes('connection', datas);
    setNodeList(nodes);
  };
  /**
   * @description: 加载连接节点下的数据库节点，如果已加载就设置展开状态
   * @param {SchemeNode} node 连接节点
   */
  const loadDatabase = async (node: SchemeNode): Promise<void> => {
    // 判断是否已经加载过，如果未加载过请求服务接口进行数据加载
    if (node.isLoad) {
      const tempNodeList = expandTypeNode(node.key, nodeList, true);
      setNodeList(tempNodeList.slice());
    } else {
      const data = await getDatabasesOperate.run({ uid: node.source.connection?.uid });
      const connectionNodes = transformNodes('database', data, node);
      const newNodeList = [...nodeList, ...connectionNodes];
      // loadedSchemeNode(node.key, newNodeList, true);
      // if (!node.isExpand) newNodeList = expandTypeNode(node.key, newNodeList, true);
      setNodeList(newNodeList.slice());
    
    }
    console.log('loadDatabase')
  };
  /**
   * @description: 加载数据库表
   * @param {*} node 数据库节点
   * @return {*}
   */
  const loadTable = async (node: SchemeNode): Promise<void> => {
    if (node.isLoad) {
      const tempNodeList = expandTypeNode(node.key, nodeList, true);
      setNodeList(tempNodeList.slice());
    } else {
      const data = await getTablesOperate.run({
        uid: node.source.connection?.uid,
        database: node.source.database?.name,
      });
      const databaseNodes = transformNodes('table', data, node);
      const newNodeList = [...nodeList, ...databaseNodes];
      // loadedSchemeNode(node.key, newNodeList, true);
      // if (!node.isExpand) newNodeList = expandTypeNode(node.key, newNodeList, true);
      setNodeList(newNodeList.slice());
    }
  };

  /**
   * @description: 设置节点收展状态
   * @param {string} key
   * @param {boolean} expanded
   * @return {*}
   */
  const setExpandNode = (key: string | number, expanded: boolean): void => {
    const newNodeList = expandTypeNode(key, nodeList, expanded);
    setNodeList(newNodeList.slice());
  };

  /**
   * @description: 设置节点收展状态
   * @param {string} key
   * @param {boolean} expanded
   * @return {*}
   */
  const setLoadedNode = (key: string | number, loaded: boolean): void => {
    setSchemeNodeAttribute(key, 'isLoad', loaded, nodeList);
    setNodeList(nodeList.slice());
  };

  /**
   * @description: 关闭连接
   * @param {*} async
   * @return {*}
   */
  const closeConnection = (key: string | number): void => {
    const newNodeList = nodeList.filter(
      (t) => !t.key.toString().includes(key.toString()) && t.key !== key,
    );
    expandedSchemeNode(key, newNodeList, false);
    loadedSchemeNode(key, newNodeList, false);
    setNodeList(newNodeList.slice());
  };
  /**
   * @description:  添加连接
   * @param {*} async
   * @return {*}
   */
  const addConnection = async (connection: API.DataBase.Connection): Promise<void> => {
    const data = await addConnectionOperate.run(connection);
    const schemeNode = transformConnection(data);
    nodeList.push(schemeNode);
    setNodeList(nodeList.slice());
  };
  const deleteConnection = async (key: string | number) => {
    await removeConnectionOperate.run([key]);
    const newNodeList = nodeList.filter(
      (t) => !t.key.toString().includes(key.toString()) && t.key !== key,
    );
    setNodeList(newNodeList.slice());
  };
  const updateConnection = async (connection: API.DataBase.Connection) => {
    const updatedConnection = await updateConnectionOperate.run(connection);
    const schemeNode = transformConnection(updatedConnection);
    const newNodeList = nodeList.filter(
      (t) => !t.key.toString().includes(connection.uid) && t.key !== connection.uid,
    );
    replaceSchemeNode(connection.uid, newNodeList, schemeNode);
    setNodeList(newNodeList.slice());
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
      connection.children = [];
      const temp_children = nodeList.filter((t) => t.parentKey === connection.key);
      for (let j = 0; j < temp_children.length; j += 1) {
        const database = temp_children[j];
        database.children = nodeList.filter((t) => t.parentKey === database.key);
        connection.children.push(database);
      }
      newNodeList.push(connection);
    }
    console.log('getTreeData')
    return newNodeList;
  };
  /**
   * @description: 获取展开的节点
   * @param {*}
   * @return {*}
   */
  const getExpandedKeys = (): string[] => {
    const keys = nodeList.filter((t) => t.isExpand).map((t) => t.key.toString());
    return keys;
  };
  const getLoadedKeys = () => {
    const keys = nodeList.filter((t) => t.isLoad).map((t) => t.key.toString());
    return keys;
  };

  useEffect(() => {
    const datas = connectionGetListOperate.data || [];
    const nodes = transformNodes('connection', datas);
    setNodeList(nodes);
  }, [connectionGetListOperate.data]);
  return {
    loadAllConnection,
    loadDatabase,
    loadTable,
    getTreeData,
    nodeList,
    loading: connectionGetListOperate.loading,
    closeConnection,
    getLoadedKeys,
    addConnection,
    getExpandedKeys,
    setExpandNode,
    setLoadedNode,
    deleteConnection,
    updateConnection,
  };
};
