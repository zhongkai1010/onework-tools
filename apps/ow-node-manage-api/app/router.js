/*
 * @Author: your name
 * @Date: 2021-05-17 18:34:51
 * @LastEditTime: 2021-05-18 19:55:38
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ow-node-manage-api\app\router.js
 */
'use strict';

const fs = require('fs');
const path = require('path');

const judgeMethod = fun_name => {
  if (fun_name.startsWith('get')) {
    return 'get';
  }
  return 'post';
};

const ignorePath = [ 'execPageService', 'getPageParmas',
  'validatePage', 'success', 'failure', 'toInt', 'toDefaultInt' ];

const generatePath = (path, controller) => {
  const result = [];
  for (const key in controller) {
    const item = controller[key];
    const action_path = `${path}/${key}`;
    if (typeof item === 'object') {
      result.push(...generatePath(action_path, item));
    } else {
      if (!ignorePath.includes(key)) {
        result.push({ path: action_path, fun: controller[key], method: judgeMethod(key) });
      }
    }
  }
  return result;
};

const writePathFile = paths => {
  const path_fule = path.join(__dirname, 'core', '.temp');
  let path_str = '';
  for (let i = 0; i < paths.length; i++) {
    path_str += `"${paths[i].method} ${paths[i].path}":{},\n`;
  }
  fs.mkdirSync(path_fule, { recursive: true });
  fs.writeFileSync(path.join(path_fule, 'router.js'), `'use strict';\n module.exports = {\n${path_str}\n}`);
};

/**
 * @param {Egg.Application} app - egg application
 */
module.exports = app => {
  const { router, controller } = app;
  const paths = generatePath('', controller);
  for (let i = 0; i < paths.length; i++) {
    const path = paths[i].path;
    const fun = paths[i].fun;
    const method = paths[i].method;
    router[method](path, fun);
  }
  writePathFile(paths);
  // console.log(paths);
  router.get('/', controller.home.index);
};
