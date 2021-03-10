/*
 * @Author: 钟凯
 * @Date: 2021-03-10 11:33:58
 * @LastEditTime: 2021-03-10 18:28:16
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\typings\ow.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

declare module "egg" {
  namespace Ow.Database {
    interface Connection {
      uid?: string;
      name: string;
      code: string;
      dbType: string;
      database: string | null;
      username: string;
      password: string;
      host: string;
      port: string;
      config: any;
      description: string | null;
    }
    interface Table {
      uid?: string;
      name: string;
      code: string;
      cnUid: string;
      dbName: string;
      description: string;
      columns?: Array<Egg.Sequelize.Database.Column>;
    }
    interface Column {
      uid?: string;
      name: string;
      code: string;
      cnUid: string;
      tbUid: string;
      dbName: string;
      type: string;
      isNull: string;
      isUnique: string;
      length: string;
      precision: string | null;
      oredr: string | null;
      defaultValue: string | nul;
      description: string | null;
    }
  }
  namespace Ow.Data {
    interface Collection {
      uid?: string;
      name: string;
      code: string;
      items: Egg.Sequelize.Data.Item[];
      description?: string | null;
    }
    interface Data {
      uid?: string;
      name: string;
      code: string;
      use: "universal" | "input" | "output";
      status: boolean;
      description?: string | null;
      items: Egg.Ow.Data.DataItem[]
    }
    interface DataBehavior {
      uid?: string;
      name: string;
      code: string;
      dataUid: string;
      inputs: Array<any> | null;
      outputs: Array<any> | null;
      operationType: "read" | "add" | "update" | "delete" | null;
      description: string | null;
    }
    interface DataItem {
      uid?: string;
      name: string;
      code: string;
      dataUid: string;
      itemUid: string;
      itemType:
        | "string"
        | "number"
        | "array"
        | "object"
        | "boolean"
        | "integer"
        | "other";
      arrayType:
        | "string"
        | "number"
        | "array"
        | "object"
        | "boolean"
        | "integer"
        | "other"
        | null;
      arrayDepth: number;
      objectRef: string | null;
      typeValue: string | null;
      defaultValue: string | null;
      isNull: boolean | null;
      length: number | null;
      precision: number | null;
      isUnique: boolean | null;
    }
    interface Item {
      uid?: string;
      name: string;
      code: string;
      type:
        | "string"
        | "number"
        | "array"
        | "object"
        | "boolean"
        | "integer"
        | "other";
      cumulate: number;
    }
  }
  namespace Ow.Module {
    interface Module {
      uid?: string;
      description: string | null;
    }
    interface ModuleModel {
      uid?: string;
      modelUid: string;
      moduleUid: string;
    }
  }
  namespace Ow.System {
    interface System {
      uid?: string;
      description: string | null;
    }
    interface SystemModule {
      uid?: string;
      systemUid: string;
      moduleUid: string;
    }
  }
  namespace Ow.User {
    interface User {
      uid?: string;
      systemUid: string;
      moduleUid: string;
    }
  }
  namespace Ow {
    interface DbDatabase {
      name: string;
    }
    interface DbTable {
      code: string;
      name: string;
      columns?: Egg.Ow.DbColumn[];
    }
    interface DbColumn {
      order: number;
      code: string;
      name: string;
      type: string;
      isUnique: 1 | 0;
      length: number;
      precision: number;
      isNull: 1 | 0;
      defaultValue: string | null;
    }
  }
}
