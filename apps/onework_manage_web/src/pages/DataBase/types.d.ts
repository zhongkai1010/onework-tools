/*
 * @Author: 钟凯
 * @Date: 2021-03-04 10:03:58
 * @LastEditTime: 2021-03-17 15:03:48
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\types.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
declare namespace API {
  declare namespace DataBase {
    export type Connection = {
      dbType: 'mysql' | 'mariadb' | 'postgres' | 'mssql';
      port: number;
      config: any | null;
      database: string | null;
      password: string;
      host: string;
      username: string;
      updatedAt: string;
      uid: string;
      name: string;
      description: string | null;
      createdAt: string;
    };

    export type Database = {
      uid: string;
      name: string;
      code: string;
      cnUid: string;
      isSync: boolean;
      isOnline?: boolean;
      lastSyncDate: string;
      description: string | null;
      updatedAt?: string;
      createdAt?: string;
    };
    export type Table = {
      uid: string;
      name: string;
      code: string;
      cnUid: string;
      dbName: string;
      description: string;
      columns?: Api.DataBase.Column[];
    };
    export type Column = {
      uid?: string;
      updatedAt?: string;
      createdAt?: string;
    };
  }
}
