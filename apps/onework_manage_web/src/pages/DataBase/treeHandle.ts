/*
 * @Author: 钟凯
 * @Date: 2021-03-16 13:57:50
 * @LastEditTime: 2021-03-18 16:21:49
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\treeHandle.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import type { DataNode } from 'antd/lib/tree';
import * as connectionServices from './services/connection';
import * as schemeServices from './services/scheme';
import { message } from 'antd';

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
  isSelect: boolean;
}

export default class TreeHandle {
  private _nodeList: SchemeNode[] = [];
  /**
   *
   */
  constructor(data?: API.DataBase.Connection[]) {
    this._nodeList = data ? this.transformNodes('connection', data) : [];
  }
  public get nodeList(): SchemeNode[] {
    return this._nodeList;
  }

  public get selectNode(): SchemeNode | undefined {
    return this._nodeList.find((t) => t.isSelect);
  }

  /**
   * @description: 获取连接节点中元数据中的连接数据
   * @param {*}
   * @return {*}
   */
  public get connections(): API.DataBase.Connection[] {
    const connectionNodes = this._nodeList.filter((t) => t.type === 'connection');
    const connections = [] as API.DataBase.Connection[];
    for (let i = 0; i < connectionNodes.length; i += 1) {
      const node = connectionNodes[i];
      if (node.source.connection) {
        connections.push(node.source.connection);
      }
    }
    return connections;
  }
  /**
   * @description:  获取子节点中原数据
   * @param {string} parentKey 父节点key
   * @param {*} source 原数据类型
   * @return {*}
   */
  public getNodeChildrens<T>(parentKey: string, source: 'database' | 'table'): T[] {
    const datas = [] as T[];
    const nodes = this._nodeList.filter((t) => t.parentKey === parentKey);
    for (let i = 0; i < nodes.length; i += 1) {
      const node = nodes[i];
      if (node.source[source]) {
        datas.push((node.source[source] as unknown) as T);
      }
    }
    return datas;
  }
  public async loadAllConnection() {
    const result = await connectionServices.getlist();
    if (result.success) {
      this._nodeList = this.transformNodes('connection', result.data);
    } else {
      message.error('加载连接数据失败');
    }
  }
  public async loadNode(key: string | number) {
    const node = this._nodeList.find((t) => t.key === key);
    if (node) {
      if (!node.isLoad) {
        if (node.type === 'connection') {
          const result = await schemeServices.getDatabases({ uid: node.key });
          const connectionNodes = this.transformNodes('database', result.data, node);
          // 移除旧得子节点数据，重新加载新得节点
          this._nodeList = this._nodeList.filter(
            (t) => !t.parentKey?.toString().includes(node.key.toString()),
          );
          this._nodeList.push(...connectionNodes);
        }
        if (node.type === 'database') {
          const result = await schemeServices.getTables({
            uid: node.source.connection?.uid,
            database: node.source.database?.name,
          });
          const databaseNodes = this.transformNodes('table', result.data, node);
          // 移除旧得子节点数据，重新加载新得节点
          this._nodeList = this._nodeList.filter(
            (t) => !t.parentKey?.toString().includes(node.key.toString()),
          );
          this._nodeList.push(...databaseNodes);
        }
        this.setNodeLoaded(node.key, true);
      }
      this.setNodeExpand(node.key, true);
      this.setNodeSelected(node.key);
    }
  }
  /**
   * @description: 设置节点收展状态
   * @param {string} key
   * @param {boolean} expanded
   * @return {*}
   */
  public setNodeExpand(key: string | number, expanded: boolean): void {
    // 展开节点判断是否已加载子节点，未加载不设置展开状态，走加载控制
    if (expanded) {
      const node = this.getNode(key);
      if (!node.isLoad) return;
    }
    this._nodeList = this.setTypeNodeExpand(key, this._nodeList, expanded);
  }

  public getNodeOrNull(key: string | number): SchemeNode | undefined {
    return this._nodeList.find((t) => t.key === key);
  }
  public getNode(key: string | number): SchemeNode {
    const node = this._nodeList.find((t) => t.key === key);
    if (node === undefined) {
      throw new Error(`"${key}" is not in tree nodes`);
    }
    return node;
  }

  /**
   * @description: 设置节点收展状态
   * @param {string} key
   * @param {boolean} expanded
   * @return {*}
   */
  public setNodeSelected(key: string | number): void {
    this._nodeList = this.setAllSchemeNodeCancelSelected(this._nodeList);
    this.setSchemeNodeAttribute(key, 'isSelect', true, this._nodeList);
  }
  /**
   * @description: 设置节点收展状态
   * @param {string} key
   * @param {boolean} expanded
   * @return {*}
   */
  public setNodeLoaded(key: string | number, loaded: boolean): void {
    this.setSchemeNodeLoaded(key, this._nodeList, loaded);
  }
  /**
   * @description:  添加连接
   * @param {*} async
   * @return {*}
   */
  public addNode(node: SchemeNode): void {
    this._nodeList.unshift(node);
  }
  public deleteNode(key: string | number) {
    this._nodeList = this._nodeList.filter((t) => !t.key.toString().includes(key.toString()));
  }
  public replaceNode(key: string | number, node: SchemeNode) {
    this.replaceSchemeNode(key, this._nodeList, node);
  }
  /**
   * @description: 获取展开的节点
   * @param {*}
   * @return {*}
   */
  public getExpandedKeys(): string[] {
    const keys = this._nodeList.filter((t) => t.isExpand).map((t) => t.key.toString());
    return keys;
  }
  public getLoadedKeys() {
    const keys = this._nodeList.filter((t) => t.isLoad).map((t) => t.key.toString());
    return keys;
  }
  public getSelectedKeys() {
    const keys = this._nodeList.filter((t) => t.isSelect).map((t) => t.key.toString());
    return keys;
  }
  public collapseAllNode() {
    this._nodeList = this.setAllSchemeNodeExpand(this._nodeList, false);
  }
  public cancelNodeSelected() {
    this._nodeList = this.setAllSchemeNodeCancelSelected(this._nodeList);
  }
  public static transformConnection(connection: API.DataBase.Connection) {
    return {
      type: 'connection',
      key: connection.uid,
      parentKey: null,
      source: { connection },
      title: connection.name,
      isLeaf: false,
      isLoad: false,
      isSelect: false,
      isExpand: false,
    } as SchemeNode;
  }
  public static transformDataBase(connection: SchemeNode, database: API.DataBase.Database) {
    return {
      key: `${connection?.key}_${database.name}`,
      parentKey: connection?.key.toString(),
      type: 'database',
      source: { database, connection: connection.source.connection },
      title: `${database.name}`,
      isLeaf: false,
      isLoad: false,
      isSelect: false,
      isExpand: false,
    } as SchemeNode;
  }
  public static transformTabel(database: SchemeNode, table: API.DataBase.Table) {
    return {
      key: `${database?.key}_${table.uid}`,
      parentKey: database?.key.toString(),
      type: 'table',
      source: { ...database?.source, table },
      title: table.name,
      isLoad: false,
      isLeaf: true,
      isSelect: false,
      isExpand: false,
    } as SchemeNode;
  }
  /**
   * @description: 获取数据结构的树形结构数据
   * @param {*}
   * @return {*}
   */
  public static getTreeData(nodes: SchemeNode[]): any {
    const root = nodes.filter((t) => t.type === 'connection');
    const newNodeList = [];
    for (let i = 0; i < root.length; i += 1) {
      const connection = root[i];
      connection.children = [];
      const temp_children = nodes.filter((t) => t.parentKey === connection.key);
      for (let j = 0; j < temp_children.length; j += 1) {
        const database = temp_children[j];
        database.children = nodes.filter((t) => t.parentKey === database.key);
        connection.children.push(database);
      }
      newNodeList.push(connection);
    }
    return newNodeList;
  }
  private transformNodes = (
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
            result.push(TreeHandle.transformConnection(element));
            break;
          }
          case 'database': {
            const element = data[i] as API.DataBase.Database;
            if (!node) throw new Error('transformNode params node is null!');
            result.push(TreeHandle.transformDataBase(node, element));
            break;
          }
          case 'table': {
            const element = data[i] as API.DataBase.Table;
            if (!node) throw new Error('transformNode params node is null!');
            result.push(TreeHandle.transformTabel(node, element));
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
  private replaceSchemeNode(key: string | number, nodes: SchemeNode[], newNode: SchemeNode) {
    const nodeIndex = nodes.findIndex((t) => t.key === key);
    nodes.splice(nodeIndex, 1, newNode);
  }
  /**
   * @description: 设置数组中指定key的节点指定的属性值
   * @param {string} key
   * @param {string} attribute
   * @param {any} value
   * @param {SchemeNode} nodes
   */
  private setSchemeNodeAttribute(
    key: string | number,
    attribute: string,
    value: any,
    nodes: SchemeNode[],
  ): void {
    const node = nodes.find((t) => t.key === key);
    if (node) {
      if (Object.keys(node).includes(attribute)) {
        Object.defineProperty(node, attribute, {
          value,
          writable: true,
          enumerable: true,
          configurable: true,
        });
        this.replaceSchemeNode(key, nodes, node);
      }
    }
  }
  /**
   * @description: 展开或收起指定key值的节点
   * @param {string} key 收起的节点key
   * @param {SchemeNode} nodes 节点集合
   * @param {boolean} expanded true：展开，false：收起
   * @return {*}
   */
  private setSchemeNodeExpand(
    key: string | number,
    nodes: SchemeNode[],
    expanded: boolean = false,
  ): void {
    this.setSchemeNodeAttribute(key, 'isExpand', expanded, nodes);
  }
  /**
   * @description: 设置指定key值的节点加载状态
   * @param {string} key 节点key值
   * @param {SchemeNode} nodes 节点集合
   * @param {boolean} loaded true：已加载，false：未加载
   * @return {*}
   */
  private setSchemeNodeLoaded(
    key: string | number,
    nodes: SchemeNode[],
    loaded: boolean = false,
  ): void {
    this.setSchemeNodeAttribute(key, 'isLoad', loaded, nodes);
  }
  /**
   * @description: 设置所有节点展开状态
   * @param {SchemeNode} nodes 节点集合
   * @param {boolean} expanded true：已加载，false：未加载
   * @return {*}
   */
  private setAllSchemeNodeExpand(nodes: SchemeNode[], expanded: boolean = false): SchemeNode[] {
    return nodes.map((t) => {
      return {
        ...t,
        isExpand: expanded,
      };
    });
  }
  /**
   * @description: 取消所有节点选中状态
   * @param {SchemeNode} nodes 节点集合
   * @param {boolean} expanded true：已选中，false：未选中
   * @return {*}
   */
  private setAllSchemeNodeCancelSelected(nodes: SchemeNode[]): SchemeNode[] {
    return nodes.map((t) => {
      return {
        ...t,
        isSelect: false,
      };
    });
  }
  /**
   * @description:  设置不同类型节点展开属性，内部控制级联关系的展开状态
   * @param {string} key
   * @param {SchemeNode} nodes
   * @param {boolean} expanded
   * @param {*} SchemeNode
   * @return {*}
   */
  private setTypeNodeExpand(
    key: string | number,
    nodes: SchemeNode[],
    expanded: boolean,
  ): SchemeNode[] {
    if (!expanded) {
      this.setSchemeNodeExpand(key, nodes, false);
      return nodes;
    }
    // 展开节点的同时，收起同类型节点
    const tempNodeList = this.setAllSchemeNodeExpand(nodes, false);
    const node = tempNodeList.find((t) => t.key === key);
    if (node) {
      if (node.source.connection?.uid) {
        const connectionUid = node.source.connection?.uid;
        const dataBaseName = node.source.database?.name;
        if (node.type === 'table') {
          this.setSchemeNodeExpand(connectionUid, tempNodeList, true);
          this.setSchemeNodeExpand(`${connectionUid}_${dataBaseName}`, tempNodeList, true);
        }
        if (node.type === 'database') {
          this.setSchemeNodeExpand(connectionUid, tempNodeList, true);
        }
        this.setSchemeNodeExpand(key, tempNodeList, true);
        return tempNodeList;
      }
    }
    return nodes;
  }
}
