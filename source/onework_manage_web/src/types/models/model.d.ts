
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

export enum DataCategory {
    Class = 1,
    Interface = 2,
    Abstract = 3,
    ValueObject = 4 // 值对象
}
export enum DataItemType {
    Character = 'character',
    Integer = 'integer',
    Digital = 'digital',
    Boolean = 'boolean',
    Enumerate = 'enumerate',
    Date = 'date',
    DateTime = 'datetime'
}
export enum DataStatus {
    Enable = "enable",
    Disable = "disable",

}
export type Item = {
    id: number; // Id
    uuid: string;
    name: string; // 名称
    code: string; // 编码
    type: DataItemType; // 类型
    status: DataStatus; // 状态 
    updatedAt: Date | null;
    createdAt: Date | null;
};
export type PublicData = {
    id: string; // Id
    name: string; // 公共数据名称
    code: string; // 编码
    description: string; // 描述
    enable: boolean; // 启用状态
    items: Item[]; // 数据项集合
};
