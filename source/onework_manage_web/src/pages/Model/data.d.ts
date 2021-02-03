/*
 * @Author: 钟凯
 * @Date: 2021-02-03 16:32:22
 * @LastEditTime: 2021-02-03 17:25:12
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\pages\Model\data.d.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

export enum DataItemType {
    Integer, // 整型
    Character, // 字符串
    Digital, // 数字
    Boolean, // 布尔
    Enumerate, // 枚举
    Date, // 日期
    DateTime, // 日期时间
    Object // 对象
}

export type PublicDataItem = {
    id?: string; // 数据项Id
    name: string; // 数据项名称
    code: string; // 编码
    type: DataItemType; // 类型
    allowNull: boolean; // 是否允许空
    rule: string; // 规则
    length: number; // 长度
    precision: number;// 精度
    defaultValue?: string; // 默认值
    description: string; // 描述
    enable: boolean; // 启用状态
};

export type PublicData = {
    id: string; // 数据项Id
    name: string; // 数据项名称
    code: string; // 编码
    category: string; // 类别  
    enable: boolean; // 启用状态
    description: string; // 描述
};


export type Data = {
    id: string;
    name: string;
    code: string;
};

export type DataItem = {
    id: string;
    name: string;
    code: string;
};