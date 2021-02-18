/*
 * @Author: 钟凯
 * @Date: 2021-02-15 21:46:13
 * @LastEditTime: 2021-02-17 21:00:56
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\services\API.d.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
declare namespace API {
  export type CurrentUser = {
    avatar?: string;
    name?: string;
    title?: string;
    group?: string;
    signature?: string;
    tags?: {
      key: string;
      label: string;
    }[];
    userid?: string;
    access?: 'user' | 'guest' | 'admin';
    unreadCount?: number;
  };

  export type LoginStateType = {
    status?: 'ok' | 'error';
    type?: string;
  };

  export type NoticeIconData = {
    id: string;
    key: string;
    avatar: string;
    title: string;
    datetime: string;
    type: string;
    read?: boolean;
    description: string;
    clickClose?: boolean;
    extra: any;
    status: string;
  };

  export type ResponseResult<T> = {
    data: T;
    success: boolean;
  };

  declare namespace Model {
    export type AddItem = {
      /** 名称 */
      name: string;
      /** 代码 */
      code: string;
      /** 数据项类型，0：无、1：字符、2：整型、3：数字、4：布尔、5：日期、6：时间、 */
      type: 'character' | 'integer' | 'digital' | 'boolean' | 'enumerate' | 'date';
    };

    export type Item = {
      /** ID */
      id: string;
      /** 唯一值 */
      uid: string;
      /** 名称 */
      name: string;
      /** 代码 */
      code: string;
      /** 数据项类型，0：无、1：字符、2：整型、3：数字、4：布尔、5：日期、6：时间、 */
      type: 'character' | 'integer' | 'digital' | 'boolean' | 'enumerate' | 'date';
      /** 状态，1：启用 ，2：禁用 */
      status: 'enable' | 'disable';
      /** 创建时间 */
      created_at: string;
      /** 修改时间 */
      updated_at: string;
    };

    export type Collection = {
      /** ID */
      id: number;
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
  }
}
