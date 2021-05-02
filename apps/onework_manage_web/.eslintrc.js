/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-03-15 18:00:16
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\.eslintrc.js
 * 可以输入预定的版权声明、个性签名、空行等
 */
module.exports = {
  extends: [require.resolve('@umijs/fabric/dist/eslint')],
  globals: {
    ANT_DESIGN_PRO_ONLY_DO_NOT_USE_IN_YOUR_PRODUCTION: true,
    page: true,
    REACT_APP_ENV: true,
  },
  rules:{
    "react-hooks/exhaustive-deps":0,
    "no-underscore-dangle":0
  }
};
