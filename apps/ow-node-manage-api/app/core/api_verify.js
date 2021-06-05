/*
 * @Author: your name
 * @Date: 2021-05-18 18:54:07
 * @LastEditTime: 2021-05-19 09:20:53
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ow-node-manage-api\app\core\api_ver.js
 */
'use strict';

const { AppCode } = require('../core/index');

module.exports = {
  'post /api/database/connection/insert': {
    name: 'string',
    dbType: [ 'mysql', 'mariadb', 'postgres', 'mssql' ],
    database: 'string?',
    username: 'string',
    password: 'string',
    host: 'string',
    port: 'int',
    config: 'string?',
    description: 'string?',
  },
  'get /api/database/connection/getlist': {
    page: { type: 'int', required: true, min: AppCode.common.page.minpage },
    limit: { type: 'int', required: true, min: 1, max: AppCode.common.page.maxlimit },
    keyword: 'string?',
    order: 'string?',
    sort: Object.values(AppCode.common.order),
  },
  'post /api/database/connection/update': {
    uid: 'string',
    name: 'string',
    dbType: [ 'mysql', 'mariadb', 'postgres', 'mssql' ],
    database: 'string?',
    username: 'string',
    password: 'string',
    host: 'string',
    port: 'int',
    config: 'string?',
    description: 'string?',
  },
  'post /api/database/connection/remove': {
    type: 'array',
    required: true,
    itemType: 'string',
  },
  'get /api/database/scheme/getSchemeData': {
    uid: 'string',
    type: [ 'database', 'table', 'column' ],
    database: 'string?',
    table: 'string?',
  },
  'get /api/database/scheme/getDatabases': {
    uid: 'string',
  },
  'get /api/database/scheme/getTables': {
    uid: 'string',
    database: 'string',
  },
  'post /api/database/scheme/syncDataBase': {
    uid: 'string',
    database: 'string',
  },
  'get /api/database/scheme/getTableColumns': {
    uid: 'string',
  },
  'post /api/model/collection/insert': {
    name: 'string',
    code: 'string',
    itemUids: { type: 'array', itemType: 'string' },
    description: 'string?',
  },
  'get /api/model/collection/getlist': {
    page: { type: 'int', required: true, min: AppCode.common.page.minpage },
    limit: { type: 'int', required: true, min: 1, max: AppCode.common.page.maxlimit },
    keyword: 'string?',
    order: 'string?',
    sort: Object.values(AppCode.common.order),
  },
  'post /api/model/collection/update': {
    uid: 'string',
    name: 'string',
    code: 'string',
    itemUids: { type: 'array', rule: 'string' },
    description: 'string?',
  },
  'post /api/model/collection/search': {
    keyword: 'string',
  },
  'post /api/model/collection/remove': {
    type: 'array',
    required: true,
    itemType: 'string',
  },
  'get /api/model/data/get': {
    uid: 'string',
  },
  'post /api/model/data/insert': {
    name: 'string',
    code: 'string',
    use: Object.values(AppCode.model.modelUse),
    items: { type: 'array', min: 1, required: true, itemType: 'object', rule: {
      name: 'string',
      code: 'string',
      itemType: Object.values(AppCode.model.itemType),
      isNull: 'boolean?',
      isUnique: 'boolean?',
    } },
    behaviors: { type: 'array', required: false, itemType: 'object', rule: {
      name: 'string',
      code: 'string',
      description: 'string?',
      operationType: Object.values(AppCode.model.behaviorType),
    } },
    description: 'string?',
  },
  'get /api/model/data/getlist': {
    status: {
      type: 'array',
      required: false,
      itemType: 'enum',
      rule: {
        values: Object.values(AppCode.common.status),
      },
    },
    use: {
      type: 'array',
      required: false,
      itemType: 'enum',
      rule: {
        values: Object.values(AppCode.model.modelUse),
      },
    },
    page: { type: 'int', required: true, min: AppCode.common.page.minpage },
    limit: { type: 'int', required: true, min: 1, max: AppCode.common.page.maxlimit },
    keyword: 'string?',
    order: 'string?',
    sort: Object.values(AppCode.common.order),
  },
  'post /api/model/data/update': {
    uid: 'string',
    name: 'string',
    code: 'string',
    use: Object.values(AppCode.model.modelUse),
    items: { type: 'array', min: 1, required: true, itemType: 'object', rule: {
      name: 'string',
      code: 'string',
      itemType: Object.values(AppCode.model.itemType),
    } },
    behaviors: { type: 'array', required: false, itemType: 'object', rule: {
      name: 'string',
      code: 'string',
      description: 'string?',
    } },
    description: 'string?',
  },
  'post /api/model/data/remove': {
    params: {
      type: 'array',
      required: true,
      itemType: 'string',
    },
  },
  'post /api/model/data/search': {
    keyword: 'string',
  },
  'post /api/model/dataBehavior/insert': {
    dataUid: 'string',
    name: 'string',
    code: 'string',
    inputs: {
      type: 'array', required: false, itemType: 'object', rule: {
        type: Object.values(AppCode.model.itemType),
        arrayType: 'string?',
        value: 'string?',
      },
    },
    outputs: {
      type: 'object', required: false, rule: {
        type: Object.values(AppCode.model.itemType),
        arrayType: 'string?',
        value: 'string?',
      },
    },
    operationType: Object.values(AppCode.model.behaviorType),
    description: 'string?',
  },
  'get /api/model/dataBehavior/getList': {
    page: { type: 'int', required: true, min: AppCode.common.page.minpage },
    limit: { type: 'int', required: true, min: 1, max: AppCode.common.page.maxlimit },
    keyword: 'string?',
    order: 'string?',
    sort: Object.values(AppCode.common.order),
  },
  'post /api/model/dataBehavior/update': {
    uid: 'string',
    name: 'string',
    code: 'string',
    inputs: {
      type: 'array', required: false, itemType: 'object', rule: {
        type: Object.values(AppCode.model.itemType),
        arrayType: 'string?',
        value: 'string?',
      },
    },
    outputs: {
      type: 'object', required: false, rule: {
        type: Object.values(AppCode.model.itemType),
        arrayType: 'string?',
        value: 'string?',
      },
    },
    operationType: Object.values(AppCode.model.behaviorType),
    description: 'string?',
  },
  'post /api/model/dataBehavior/remove': {
    params: {
      type: 'array',
      required: true,
      itemType: 'string',
    },
  },
  'get /api/model/dataItem/getList': {
    page: { type: 'int', required: true, min: AppCode.common.page.minpage },
    limit: { type: 'int', required: true, min: 1, max: AppCode.common.page.maxlimit },
    keyword: 'string?',
    order: 'string?',
    sort: Object.values(AppCode.common.order),
  },
  'post /api/model/dataItem/insert': {
    dataUid: 'string',
    name: 'string',
    code: 'string',
    itemType: 'string',
    typeValue: 'string?',
    arrayType: 'string?',
    objectRef: 'string?',
    defaultValue: 'string?',
    isNull: 'boolean?',
    length: 'int?',
    precision: 'int?',
    isUnique: 'boolean?',
  },
  'post /api/model/dataItem/update': {
    uid: 'string',
    name: 'string',
    code: 'string',
    itemType: 'string',
    typeValue: 'string?',
    arrayType: 'string?',
    objectRef: 'string?',
    defaultValue: 'string?',
    isNull: 'boolean?',
    length: 'int?',
    precision: 'int?',
    isUnique: 'boolean?',
  },
  'post /api/model/dataItem/remove': {
    params: {
      type: 'array',
      required: true,
      itemType: 'string',
    },
  },
  'post /api/model/item/insert': {
    name: 'string',
    code: 'string',
    type: Object.values(AppCode.model.itemType),
  },
  'get /api/model/item/getlist': {
    type: {
      type: 'array',
      required: false,
      itemType: 'enum',
      rule: {
        values: Object.values(AppCode.model.itemType),
      },
    },
  },
  'post /api/model/item/update': {
    uid: 'string',
    name: 'string',
    code: 'string',
    type: Object.values(AppCode.model.itemType),
  },
  'post /api/model/item/save': {
    params: {
      type: 'array',
      required: true,
      itemType: 'object',
      rule: {
        uid: 'string?',
        name: 'string',
        code: 'string',
        type: Object.values(AppCode.model.itemType),
      },
    },
  },
  'post /api/model/item/remove': {
    params: {
      type: 'array',
      required: true,
      itemType: 'string',
    },
  },
  'post /api/model/item/search': {
    keyword: 'string',
  },
};
