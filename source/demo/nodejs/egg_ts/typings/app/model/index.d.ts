// This file is created by egg-ts-helper@1.25.8
// Do not modify this file!!!!!!!!!

import 'egg';
import ExportBase from '../../../app/model/base';
import ExportBaseNameCode from '../../../app/model/base_name_code';
import ExportDataCollection from '../../../app/model/data/collection';
import ExportDataData from '../../../app/model/data/data';
import ExportDataDataBehavior from '../../../app/model/data/dataBehavior';
import ExportDataDataItem from '../../../app/model/data/dataItem';
import ExportDataItem from '../../../app/model/data/item';
import ExportDatabaseColumn from '../../../app/model/database/column';
import ExportDatabaseConnection from '../../../app/model/database/connection';
import ExportDatabaseTable from '../../../app/model/database/table';
import ExportModuleModule from '../../../app/model/module/module';
import ExportModuleModuleModel from '../../../app/model/module/moduleModel';
import ExportSystemSystem from '../../../app/model/system/system';
import ExportSystemSystemModule from '../../../app/model/system/systemModule';
import ExportUserUser from '../../../app/model/user/user';

declare module 'egg' {
  interface IModel {
    Base: ReturnType<typeof ExportBase>;
    BaseNameCode: ReturnType<typeof ExportBaseNameCode>;
    Data: {
      Collection: ReturnType<typeof ExportDataCollection>;
      Data: ReturnType<typeof ExportDataData>;
      DataBehavior: ReturnType<typeof ExportDataDataBehavior>;
      DataItem: ReturnType<typeof ExportDataDataItem>;
      Item: ReturnType<typeof ExportDataItem>;
    }
    Database: {
      Column: ReturnType<typeof ExportDatabaseColumn>;
      Connection: ReturnType<typeof ExportDatabaseConnection>;
      Table: ReturnType<typeof ExportDatabaseTable>;
    }
    Module: {
      Module: ReturnType<typeof ExportModuleModule>;
      ModuleModel: ReturnType<typeof ExportModuleModuleModel>;
    }
    System: {
      System: ReturnType<typeof ExportSystemSystem>;
      SystemModule: ReturnType<typeof ExportSystemSystemModule>;
    }
    User: {
      User: ReturnType<typeof ExportUserUser>;
    }
  }
}
