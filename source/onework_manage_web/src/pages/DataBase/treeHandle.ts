import type { DataNode } from 'antd/lib/tree';
import { useEffect } from 'react';
import { useState } from 'react';
import { useRequest } from 'umi';
/*
 * @Author: 钟凯
 * @Date: 2021-03-04 14:30:36
 * @LastEditTime: 2021-03-04 18:00:37
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
  isLoad: boolean;
}

export default () => {
  const getlistOperate = useRequest(connectionServices.getlist);
  const schemeOperate = useRequest(schemeServices.getlist, { manual: true });
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
              key: element.uid || element.name,
              source: { connection: element },
              title: `${element.name}(${element.host})`,
              isLeaf: false,
              isLoad: false,
            });
            break;
          }
          case 'database': {
            const element = data[i] as API.DataBase.Database;
            result.push({
              key: `${node?.key}|${element.name}`,
              type: 'database',
              source: { ...node?.source, database: element },
              title: `${element.name}`,
              isLeaf: false,
              isLoad: false,
            });
            break;
          }
          case 'table': {
            const element = data[i] as API.DataBase.Table;
            result.push({
              key: ` ${node?.key}|${element.code}`,
              type: 'database',
              source: { ...node?.source, table: element },
              title: `${element.code}${element.name}`,
              isLoad: true,
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
    const data = await schemeOperate.run({ uid: node.source.connection.uid, type: 'database' });
    const databaseNodes = transformNode('database', data, node);
    setNodeList([...nodeList, ...databaseNodes]);
  };

  const loadTable = async (node: SchemeNode) => {
    const data = await schemeOperate.run({
      uid: node.source?.connection.uid,
      type: 'table',
      database: node?.source.database.name,
    });
    const databaseNodes = transformNode('table', data, node);
    setNodeList([...nodeList, ...databaseNodes]);
  };

  const getTreeData = () => {
    const root = nodeList.filter((t) => t.type === 'connection');
    const newNodeList = [];
    for (let i = 0; i < root.length; i += 1) {
      const connection = root[i];
      const children = nodeList.filter(
        (t) => t.type === 'database' && t.source.connection?.uid === element.source.connection.uid,
      );
      for (let j = 0; j < children.length; j++) {
        const element = children[j];
        
      }
      newNodeList.push({ ...element, children });
    }
    return nodeList;
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
