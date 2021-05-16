// This file is created by egg-ts-helper@1.25.8
// Do not modify this file!!!!!!!!!

import 'egg';
type AnyClass = new (...args: any[]) => any;
type AnyFunc<T = any> = (...args: any[]) => T;
type CanExportFunc = AnyFunc<Promise<any>> | AnyFunc<IterableIterator<any>>;
type AutoInstanceType<T, U = T extends CanExportFunc ? T : T extends AnyFunc ? ReturnType<T> : T> = U extends AnyClass ? InstanceType<U> : U;
import ExportDatabaseConnection from '../../../app/service/database/connection';
import ExportDatabaseDatabase from '../../../app/service/database/database';
import ExportDatabaseScheme from '../../../app/service/database/scheme';
import ExportDatabaseTable from '../../../app/service/database/table';
import ExportModelCollection from '../../../app/service/model/collection';
import ExportModelData from '../../../app/service/model/data';
import ExportModelDataBehavior from '../../../app/service/model/dataBehavior';
import ExportModelDataItem from '../../../app/service/model/dataItem';
import ExportModelItem from '../../../app/service/model/item';

declare module 'egg' {
  interface IService {
    database: {
      connection: AutoInstanceType<typeof ExportDatabaseConnection>;
      database: AutoInstanceType<typeof ExportDatabaseDatabase>;
      scheme: AutoInstanceType<typeof ExportDatabaseScheme>;
      table: AutoInstanceType<typeof ExportDatabaseTable>;
    }
    model: {
      collection: AutoInstanceType<typeof ExportModelCollection>;
      data: AutoInstanceType<typeof ExportModelData>;
      dataBehavior: AutoInstanceType<typeof ExportModelDataBehavior>;
      dataItem: AutoInstanceType<typeof ExportModelDataItem>;
      item: AutoInstanceType<typeof ExportModelItem>;
    }
  }
}
