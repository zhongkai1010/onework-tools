/*
 * @Author: 钟凯
 * @Date: 2021-03-04 10:03:58
 * @LastEditTime: 2021-03-04 14:52:27
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
      uid?: string;
      name: string;
      description: string | null;
      createdAt: string;
    };

    export type Database = {
      name: string;
    };
    export type Table = {
      name: string;
      code: string;
    };
    export type Column = {
      uid?: string;
      updatedAt?: string;
      createdAt?: string;
    };
  }
}
