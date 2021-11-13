/*
 * @Author: 钟凯
 * @Date: 2021-05-01 09:15:41
 * @LastEditTime: 2021-05-01 09:17:22
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \node-sequelize-sqlite\model\user.js
 * 可以输入预定的版权声明、个性签名、空行等
 */
const { DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  sequelize.define("User", {
    // Model attributes are defined here
    firstName: {
      type: DataTypes.STRING,
      allowNull: false,
    },
    lastName: {
      type: DataTypes.STRING,
      // allowNull defaults to true
    },
  });
};
