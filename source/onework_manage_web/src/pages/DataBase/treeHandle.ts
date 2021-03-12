import type { DataNode } from 'antd/lib/tree';
import { useEffect } from 'react';
import { useState } from 'react';
import { useRequest } from 'umi';
/*
 * @Author: 钟凯
 * @Date: 2021-03-04 14:30:36
 * @LastEditTime: 2021-03-05 10:58:17
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\treeHandle.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import * as connectionServices from './services/connection';
import * as schemeServices from './services/scheme';

export interface SchemeNode extends DataNode {
  type: 'connection' | 'database' | 'table';
  source: {
    connection?: any;
    database?: any;
    table?: any;
  };
  parentKey?: string;
  isLoad: boolean;
  isExpand: boolean;
}

export default () => {
  const getlistOperate = useRequest(connectionServices.getlist, {
    throwOnError: true,
  });
  const schemeOperate = useRequest(schemeServices.getlist, { manual: true, throwOnError: true });
  const [nodeList, setNodeList] = useState<(DataNode & SchemeNode)[]>([]);

  const transformNode = (
    type: 'connection' | 'database' | 'table',
    data: (API.DataBase.Connection | API.DataBase.Database | API.DataBase.Table)[],
    node?: SchemeNode,
  ) => {
    const result = [] as (DataNode & SchemeNode)[];
    if (data) {
      for (let i = 0; i < data.length; i += 1) {
        switch (type) {
          case 'connection': {
            const element = data[i] as API.DataBase.Connection;
            result.push({
              type: 'connection',
              key: element.uid,
              source: { connection: element },
              title: `${element.name}(${element.host})`,
              isLeaf: false,
              isLoad: false,
              isExpand: false,
            });
            break;
          }
          case 'database': {
            const element = data[i] as API.DataBase.Database;
            result.push({
              key: `${node?.key}_${element.name}`,
              parentKey: node?.key.toString(),
              type: 'database',
              source: { ...node?.source, database: element },
              title: `${element.name}`,
              isLeaf: false,
              isLoad: false,
              isExpand: false,
            });
            break;
          }
          case 'table': {
            const element = data[i] as API.DataBase.Table;
            result.push({
              key: `${node?.key}_${element.name}`,
              parentKey: node?.key.toString(),
              type: 'table',
              source: { ...node?.source, table: element },
              title: element.name,
              isLoad: false,
              isLeaf: true,
              isExpand: false,
            });
            break;
          }
          default:
            break;
        }
      }
    }
    return result;
  };

  const loadDatabase = async (node: SchemeNode) => {
    if (!node.isLoad) {
      const data = await schemeOperate.run({ uid: node.source.connection.uid, type: 'database' });
      const databaseNodes = transformNode('database', data, node);
      const temp = nodeList.map((t) => {
        const item = t;
        if (t.key === node.key) {
          item.isLoad = true;
        }
        return item;
      });
      setNodeList([...temp, ...databaseNodes]);
    }
  };

  const loadTable = async (node: SchemeNode) => {
    if (!node.isLoad) {
      const data = await schemeOperate.run({
        uid: node.source?.connection.uid,
        type: 'table',
        database: node?.source.database.name,
      });
      const databaseNodes = transformNode('table', data, node);
      const temp = nodeList.map((t) => {
        const item = t;
        if (t.key === node.key) {
          item.isLoad = true;
        }
        return item;
      });
      setNodeList([...temp, ...databaseNodes]);
    }
  };

  const addConnection = async (connection: API.DataBase.Connection ) =>{
   
  }

  const getTreeData = () => {
   
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
    return newNodeList;
  };

  useEffect(() => {
    const nodeData = transformNode('connection', getlistOperate.data || []);
    setNodeList(nodeData);
  }, [getlistOperate.data]);

  return {
    loadDatabase,
    loadTable,
    getTreeData,
    nodeList,
    loading: getlistOperate.loading,
  };
};
