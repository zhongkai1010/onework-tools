/*
 * @Author: 钟凯
 * @Date: 2021-02-15 21:46:13
 * @LastEditTime: 2021-02-27 22:32:11
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


}
