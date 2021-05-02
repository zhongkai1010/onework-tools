// This file is created by egg-ts-helper@1.25.8
// Do not modify this file!!!!!!!!!

import 'egg';
import ExportHome from '../../../app/controller/home';
import ExportApiDatabaseConnection from '../../../app/controller/api/database/connection';
import ExportApiDatabaseScheme from '../../../app/controller/api/database/scheme';
import ExportApiDatabaseTable from '../../../app/controller/api/database/table';
import ExportApiModelCollection from '../../../app/controller/api/model/collection';
import ExportApiModelData from '../../../app/controller/api/model/data';
import ExportApiModelDataBehavior from '../../../app/controller/api/model/dataBehavior';
import ExportApiModelDataItem from '../../../app/controller/api/model/dataItem';
import ExportApiModelItem from '../../../app/controller/api/model/item';
import ExportApiSystemModule from '../../../app/controller/api/system/module';
import ExportApiTemplateManage from '../../../app/controller/api/template/manage';
import ExportApiUserLogin from '../../../app/controller/api/user/login';
import ExportApiUserManage from '../../../app/controller/api/user/manage';

declare module 'egg' {
  interface IController {
    home: ExportHome;
    api: {
      database: {
        connection: ExportApiDatabaseConnection;
        scheme: ExportApiDatabaseScheme;
        table: ExportApiDatabaseTable;
      }
      model: {
        collection: ExportApiModelCollection;
        data: ExportApiModelData;
        dataBehavior: ExportApiModelDataBehavior;
        dataItem: ExportApiModelDataItem;
        item: ExportApiModelItem;
      }
      system: {
        module: ExportApiSystemModule;
      }
      template: {
        manage: ExportApiTemplateManage;
      }
      user: {
        login: ExportApiUserLogin;
        manage: ExportApiUserManage;
      }
    }
  }
}
