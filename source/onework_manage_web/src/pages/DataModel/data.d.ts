/*
 * @Author: 钟凯
 * @Date: 2021-02-03 16:32:22
 * @LastEditTime: 2021-02-06 16:50:14
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\pages\DataModel\data.d.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

/**
 *   数据项类型
 */
export enum DataItemType {
    Character = 1, // 字符串
    Integer = 2, // 整型
    Digital = 3, // 数字
    Boolean = 4, // 布尔
    Enumerate = 5, // 枚举
    Date = 6, // 日期
    DateTime = 7, // 日期时间
    Object = 8 // 对象
}

/**
 *  数据类别
 */
export enum DataCategory {
    Class = 1, // 类
    Interface = 2, // 接口
    Abstract = 3, // 抽象
    ValueObject = 4 // 值对象
}

export enum DataStatus {
    Enable = 1, // 启用
    Disable = 2, // 停用

}

/**
 *  公共数据项
 */
export type Item = {
    id: number; // Id
    uuid: string;
    name: string; // 名称
    code: string; // 编码
    type: DataItemType; // 类型
    description: string | null; // 描述
    status: DataStatus; // 状态 
    updatedAt: Date | null;
    createdAt: Date | null;
};

/**
 *  公共数据
 */
export type PublicData = {
    id: string; // Id
    name: string; // 公共数据名称
    code: string; // 编码
    description: string; // 描述
    enable: boolean; // 启用状态
    items: Item[] // 数据项集合
};

/**
 *  数据
 */
export type Data = {
    id: string; // Id
    name: string; // 公共数据名称
    code: string; // 编码
    systemId: string; // 所属系统
    category: DataCategory; // 类别  
    enable: boolean; // 启用状态
    description: string; // 描述
    items: Item[] // 数据项集合
};

