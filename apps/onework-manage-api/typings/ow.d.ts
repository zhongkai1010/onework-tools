/*
 * @Author: 钟凯
 * @Date: 2021-03-10 11:33:58
 * @LastEditTime: 2021-03-25 11:00:28
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\demo\nodejs\egg_ts\typings\ow.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

declare module "egg" {
  namespace Ow.Database {
    interface Connection {
      uid?: string;
      name: string;
      dbType: string;
      database: string | null;
      username: string;
      password: string;
      host: string;
      port: number;
      config: any;
      description: string | null;
    }

    interface Database {
      uid?: string;
      name: string;
      code: string;
      cnUid: string;
      isSync: boolean;
      isOnline?: boolean;
      lastSyncDate: string;
      description: string | null;
    }

    interface Table {
      uid?: string;
      name: string;
      code: string;
      cnUid: string;
      dbUid: string;
      dbName: string;
      description: string;
      columns?: Egg.Sequelize.Database.Column[];
    }
    interface Column {
      uid?: string;
      name: string;
      code: string;
      cnUid: string;
      dbUid: string;
      tbUid: string;
      dbName: string;
      type: string;
      isNull: boolean;
      isUnique: boolean;
      length: number;
      precision: number | null;
      oredr: number | null;
      defaultValue: string | nul;
      description: string | null;
    }
  }
  namespace Ow.Data {
    interface Collection {
      name: string;
      code: string;
      itemUids?: string[];
      items?: Egg.Sequelize.Data.Item[];
      description?: string | null;
    }
    interface Data {
      name: string;
      code: string;
      use: "universal" | "input" | "output";
      status: string;
      description?: string | null;
      items?: Egg.Ow.Data.DataItem[];
      behaviors?: Egg.Ow.Data.DataBehavior[];
    }
    interface DataBehavior {
      name: string;
      code: string;
      dataUid: string;
      inputs: Array<{
        type: string;
        arrayType?: string | null;
        value?: string | null;
      }> | null;
      outputs: {
        type: string;
        arrayType?: string | null;
        value?: string | null;
      } | null;
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
  namespace Ow.Tool {
    interface Comparison {
      uid?: string;
      name: string;
      code: string;
      defaultValue: string;
      datas: {
        key: string;
        value: string;
      }[];
    }

    interface Translation {
      uid?: string;
      dst: string;
      src: string;
      from: string;
      to: string;
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
