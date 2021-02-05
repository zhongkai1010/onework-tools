/*
 * @Author: 钟凯
 * @Date: 2021-02-03 16:32:22
 * @LastEditTime: 2021-02-05 16:01:58
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\pages\Model\data.d.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

/**
 *   数据项类型
 */
enum DataItemType {
    Character, // 字符串
    Integer, // 整型
    Digital, // 数字
    Boolean, // 布尔
    Enumerate, // 枚举
    Date, // 日期
    DateTime, // 日期时间
    Object // 对象
}

/**
 *  数据类别
 */
enum DataCategory {
    Class, // 类
    Interface, // 接口
    Abstract, // 抽象
    ValueObject // 值对象
}

/**
 *  公共数据项
 */
type Item = {
    id: string; // Id
    name: string; // 名称
    code: string; // 编码
    type: DataItemType; // 类型
    allowNull: boolean; // 是否允许空
    rule?: string | null; // 规则
    length: number; // 长度
    precision?: number | null;// 精度
    defaultValue?: string| null; // 默认值
    description: string; // 描述
    isEnable: boolean; // 启用状态
    isDelete: boolean; // 是否删除
};

/**
 *  公共数据
 */
type PublicData = {
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

