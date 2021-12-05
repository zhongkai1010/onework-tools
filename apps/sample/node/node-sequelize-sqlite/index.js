/*
 * @Author: 钟凯
 * @Date: 2021-05-01 08:01:33
 * @LastEditTime: 2021-05-01 09:56:00
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \node-sequelize-sqlite\index.js
 * 可以输入预定的版权声明、个性签名、空行等
 */

const { Sequelize } = require("sequelize");
const fs = require("fs");
const path = require("path");
// eslint-disable-next-line no-unused-vars
const sequelize = new Sequelize({
  dialect: "sqlite",
  storage: "./db/ow.db",
});

(async () => {
  const model_files = fs.readdirSync("./model");
  for (let i = 0; i < model_files.length; i++) {
    const model_file_name = model_files[i];
    const model_file_path = path.join(__dirname, "model", model_file_name);
    require(model_file_path)(sequelize);
  }
  await sequelize.sync();
  console.log(sequelize.models);
  const user = await sequelize.models.User.create({
    firstName: "钟",
    lastName: "凯",
  });
  console.log(user);
})();
