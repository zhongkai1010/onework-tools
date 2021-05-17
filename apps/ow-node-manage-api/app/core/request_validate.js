'use strict';

module.exports = {
  'POST /api/database/connection/add': {
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
  'GET /api/database/connection/getlist': {},
  'POST /api/database/connection/update': {},
};
