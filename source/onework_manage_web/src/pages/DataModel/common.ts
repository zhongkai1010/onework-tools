/*
 * @Author: 钟凯
 * @Date: 2021-02-21 17:33:43
 * @LastEditTime: 2021-02-21 22:58:12
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

export const ModelUseOption = [
  { label: '通用', value: 'universal' },
  { label: '输出', value: 'input' },
  { label: '输入', value: 'output' },
];

export const ModelUseEnum = {
  universal: { text: '通用' },
  input: { text: '输出' },
  output: { text: '输入' },
};

export const BoolTypeOption = [
  { label: '是', value: 'true' },
  { label: '否', value: 'false' },
];

export const BehaviorOperationTypeOption = [
  { label: '查询', value: 'read' },
  { label: '新增', value: 'add' },
  { label: '修改', value: 'update' },
  { label: '删除', value: 'delete' },
];
export const BehaviorOperationTypeEnum = {
  read:{ text: '查询', value: 'read' },
  add: { text: '修改', value: 'add' },
  update: { text: '修改', value: 'update' },
  delete: { text: '删除', value: 'delete' },
};
