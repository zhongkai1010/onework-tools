/*
 * @Author: 钟凯
 * @Date: 2021-03-06 23:21:22
 * @LastEditTime: 2021-03-09 18:27:49
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\typings\index.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import "egg";
import Transaction, { Model } from "sequelize";

declare module "egg" {
  interface RequestResult {
    data: any;
    success: boolean;
    error: RequestError | null;
  }
  interface RequestError {
    message: string;
    code: string | number;
  }
  interface Context {
    dashboard: Transaction | null;
  }

  namespace Ow {
    namespace Database {
      interface Connection {
        name: string;
        dbType: string;
        database: string;
        username: string;
        password: string;
        host: string;
        port: string;
        config: string;
        description: string;
      }
      interface Table {
        cnUid: string;
        dbName: string;
        description: string;
      }
      interface Column {
        cnUid: string;
        tbUid: string;
        dbName: string;
        type: string;
        isNull: string;
        isUnique: string;
        length: string;
        precision: string;
        oredr: string;
        defaultValue: string;
        description: string;
      }
    }
    namespace Data {
      interface Collection {}
      interface Data {}
      interface DataBehavior {}
      interface DataItem {}
      interface Item {}
    }
    namespace Module {
      interface Module {}
      interface ModuleModel {}
    }

    namespace System {
      interface System {}
      interface SystemModule {}
    }
    namespace User {
      interface User {}
    }
  }
  namespace SequelizeModel {
    interface BaseModel extends Model {
      uid: string;
      createdAt?: string;
      updatedAt?: string;
    }

    interface BaseNameModel extends BaseModel {
      name: string;
      code: string;
    }

    namespace Database {
      interface Connection extends BaseModel, Egg.Data.Database.Connection {}
      interface Table extends BaseModel, Egg.Data.Database.Table {}
      interface Column extends BaseModel, Egg.Data.Database.Column {}
    }
    namespace Data {
      interface Collection extends BaseModel, Egg.Data.Data.Collection {}
      interface Data extends BaseModel, Egg.Data.Data.Data {}
      interface DataBehavior extends BaseModel, Egg.Data.Data.DataBehavior {}
      interface DataItem extends BaseModel, Egg.Data.Data.DataItem {}
      interface Item extends BaseModel, Egg.Data.Data.Item {}
    }

    namespace Module {
      interface Module extends BaseModel, Egg.Data.Module.Module {}
      interface ModuleModel extends BaseModel, Egg.Data.Module.ModuleModel {}
    }

    namespace System {
      interface System extends BaseModel, Egg.Data.System.System {}
      interface SystemModule extends BaseModel, Egg.Data.System.SystemModule {}
    }

    namespace User {
      interface User extends BaseModel, Egg.Data.User.User {}
    }
  }
}
