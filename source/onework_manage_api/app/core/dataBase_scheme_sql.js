/*
 * @Author: 钟凯
 * @Date: 2021-02-28 18:57:09
 * @LastEditTime: 2021-02-28 19:04:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\core\dataBase_scheme_sql.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
module.exports = {
  mssql: {
    database: 'SELECT name FROM Master..SysDatabases ORDER BY name',
    table: "SELECT obj.name AS [name], pro.value AS [description] FROM sys.objects obj LEFT JOIN sys.extended_properties pro ON obj.object_id = pro.major_id WHERE obj.type= 'u' ORDER BY [name]",
    column: '',
  },
  mysql: {
    database: 'SELECT SCHEMA_NAME AS `name` FROM INFORMATION_SCHEMA.SCHEMATA ORDER BY name;',
    table: '',
    column: '',
  },
};
