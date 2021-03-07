/*
 * @Author: 钟凯
 * @Date: 2021-03-07 23:01:46
 * @LastEditTime: 2021-03-07 23:02:27
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\person.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { Table, Column, Model } from 'sequelize-typescript';

@Table
export default class Person extends Model {
  @Column
  name: string;

  @Column
  birthday: Date;
}
