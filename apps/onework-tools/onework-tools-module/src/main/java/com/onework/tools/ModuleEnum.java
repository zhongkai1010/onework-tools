package com.onework.tools;

import com.onework.tools.domain.entity.NameCodeValue;
import lombok.Getter;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.contract
 * @Description: 描述
 * @date Date : 2022年05月25日 9:58
 */
public enum ModuleEnum implements NameCodeValue {

    /**
     * 应用模块
     */
    APPLICATION("B013", "应用模块"),
    AUTHORIZE("B001", "权限模块"),
    DATABASE("B002", "数据库模块"),
    DICTIONARY("B003", "数据字典模块"),
    FILE("B004", "文件模块"),
    FLOW("B005", "流程模块"),
    FORM("B006", "表单模块"),
    MESSAGE("B008", "消息模块"),
    MODEL("B009", "数据模型模块"),
    MODULE("B010", "基础模块"),
    ORGANIZATION("B011", "机构组织模块"),
    TRANSLATION("B012", "翻译辅助模块"),
    ;

    @Getter
    private final String code;

    @Getter
    private final String name;

    ModuleEnum(String code, String name) {
        this.code = code;
        this.name = name;
    }
}
