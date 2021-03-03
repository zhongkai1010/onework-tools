/*
 * @Author: 钟凯
 * @Date: 2021-03-03 16:31:40
 * @LastEditTime: 2021-03-03 16:34:40
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataModel\types.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
declare namespace API {
  declare namespace Model {
    export type ItemType =
      | 'string'
      | 'number'
      | 'array'
      | 'object'
      | 'boolean'
      | 'integer'
      | 'other';

    export type AddItem = {
      /** 名称 */
      name: string;
      /** 代码 */
      code: string;
      /** 数据项类型，0：无、1：字符、2：整型、3：数字、4：布尔、5：日期、6：时间、 */
      type: ItemType;
    };

    export type Item = {
      /** 唯一值 */
      uid: string;
      /** 名称 */
      name: string;
      /** 代码 */
      code: string;
      /** 数据项类型，0：无、1：字符、2：整型、3：数字、4：布尔、5：日期、6：时间、 */
      type: ItemType;
      /** 创建时间 */
      created_at: string;
      /** 修改时间 */
      updated_at: string;
    };

    export type Collection = {
      /** 唯一值 */
      uid: string;
      /** 名称 */
      name: string;
      /** 编码 */
      code: string;
      /** 描述 */
      description: string;
      /** 数据项集合 */
      items: Item[];
      /** 创建时间 */
      created_at: string;
      /** 修改时间 */
      updated_at: string;
    };

    export type DataModelItem = {
      /** 唯一值 */
      uid: string;
      /** 数据模型唯一值 */
      dataUid: string;
      // 模型名称
      dataName?: string;
      /** 数据项唯一值 */
      itemUid: string;
      /** 名称 */
      name: string;
      /** 编码 */
      code: string;
      /** 类型 */
      itemType: ItemType;
      /** 唯一值 */
      typeValue: string | undefined;
      /** 是否可未空 */
      arrayType: ItemType | null;
      arrayDepth: number | null;
      /** 长度 */
      objectRef: string | null;
      objectRefName?: string | undefined;
      /** 小数位数 */
      defaultValue: string | null;
      /** 默认值 */
      isNull: boolean | string | null;
      /** 默认值 */
      length: number | null;
      /** 默认值 */
      precision: number | null;
      /** 默认值 */
      isUnique: boolean | string | null;
      /** 默认值 */
      createdAt?: string | undefined;
      /** 默认值 */
      updatedAt?: string | undefined;
    };

    export type DataModelBehavior = {
      /** 唯一值 */
      uid: string;
      /** 数据模型唯一值 */
      dataUid: string;
      /** 行为名称 */
      behaviorName: string;
      /** 行为编码 */
      behaviorCode: string;
      /** 行为输入参数集合 */
      inputs: DataModelBehaviorParams[] | null;
      /** 行为输入参数集合 */
      outputs: DataModelBehaviorParams[] | null;
      /** 行为操作类型  */
      operationType: 'read' | 'add' | 'update' | 'delete';
      /** 行为描述 */
      description?: string | undefined;
    };

    export type DataModelBehaviorParams = {
      /** 类型  */
      type: ItemType;
      arrayType?: ItemType;
      /** 类型  */
      value?: string | undefined;
    };

    export type DataModel = {
      /** 名称 */
      name: string;

      /** 编码 */
      code: string;
      /** 数据项集合 */
      items: DataModelItem[];
      /** 行为集合 */
      behaviors?: DataModelBehavior[] | undefined;
      /** 描述 */
      description?: string | undefined;
      /** 类型  */
      use: 'universal' | 'input' | 'output';
      /** ID */
      id: number;
      /** 唯一值 */
      uid: string;
      /** 创建时间 */
      created_at: string;
      /** 修改时间 */
      updated_at: string;
      /** 状态 */
      status: 'enable' | 'disable';
    };
  }
}
