/*
 * @Author: 钟凯
 * @Date: 2021-02-21 17:33:43
 * @LastEditTime: 2021-02-21 17:42:09
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\common.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

export const ItemTypeEnum = {
  string: { text: '文本' },
  number: { text: '数字' },
  array: { text: '数组' },
  object: { text: '对象' },
  boolean: { text: '布尔' },
  integer: { text: '整数' },
};

export const StatusEnum = {
  enable: { text: '启用' },
  disable: { text: '停用' },
};

export const ItemTypeOption = [
  { label: '文本', value: 'string' },
  { label: '数字', value: 'number' },
  { label: '数组', value: 'array' },
  { label: '对象', value: 'object' },
  { label: '布尔', value: 'boolean' },
  { label: '整数', value: 'integer' },
];
