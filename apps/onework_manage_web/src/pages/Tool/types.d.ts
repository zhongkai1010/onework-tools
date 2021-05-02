/*
 * @Author: 钟凯
 * @Date: 2021-03-24 16:09:24
 * @LastEditTime: 2021-03-25 17:31:42
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\Tool\types.d.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
declare namespace API {
  declare namespace Tool {
    interface Comparison {
      uid: string;
      name: string;
      code: string;
      datas: {
        key: string;
        value: string;
      }[];
      updatedAt?: string;
      createdAt?: string;
    }

    interface Template {
      uid: string;
      name: string;
      template: string;
      parameters: {
        name: string;
        rule: any;
      }[];
      updatedAt?: string;
      createdAt?: string;
    }

    interface TranslationRecord {
      uid: string;
      text: string;
      translation: string;
      from: string;
      to: string;
      updatedAt?: string;
      createdAt?: string;
      deletedAt?: string;
    }
  }
}
