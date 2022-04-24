package com.onework.tools.model;

import com.onework.tools.core.error.ErrorMessage;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model
 * @Description: 描述
 * @date Date : 2022年04月22日 10:32
 */
public enum ModelException implements ErrorMessage {
    /**
     *
     */
    DELETE_MODEL_NOT_FIND("1000", "删除数据项操作失败，数据项不存在，Code：%s"),
    LINKED_MODEL_NOT_FIND("1000", "关联数据项操作失败，数据项不存在，Code：%s"),
    DELETE_MODEL_COLLECTION_EXIST("1000", "删除数据集合，集合不存在，Code：%s"),
    ADD_MODEL_COLLECTION_ITEM_NOT_FIND("1000", "添加数据集合，数据项不存在，Code：%s"),
    DELETE_MODEL_ITEM_USE("1000", "无法删除数据项，该数据项还在使用，Code：%s"),
    SAVE_MODEL_DATA_NOT_FIND("1000", "操作数据模型，该数据模型不存在，Code：%s"),
    DELETE_MODEL_DATA_ITEM_ERROR("1000", "删除数据模型项移除，Code：%s"),
    SAVE_MODEL_DATA_ITEM_ERROR("1000", "操作数据模型，数据项出现异常，Code：%s"),
    SAVE_MODEL_DATA_BEHAVIOR_ERROR("1000", "操作数据模型，行为出现异常，Code：%s"),

    INSERT_MODEL_COLLECTION_ERROR("1000", "插入数据项集合未成功"),
    UPDATE_MODEL_COLLECTION_ERROR("1000", "修改数据项集合未成功"),
    DELETE_MODEL_COLLECTION_ERROR("1000", "删除数据项集合未成功"),

    INSERT_MODEL_ITEM_ERROR("1000", "插入数据项未成功"),
    UPDATE_MODEL_ITEM_ERROR("1000", "修改数据项未成功"),
    DELETE_MODEL_ITEM_ERROR("1000", "删除数据项未成功"),

    INSERT_MODEL_DATA_ERROR("1000", "插入数据模型未成功"),
    UPDATE_MODEL_DATA_ERROR("1000", "修改数据模型未成功"),
    DELETE_MODEL_DATA_ERROR("1000", "删除数据模型未成功"),

    INSERT_MODEL_DATA_BEHAVIOR_ERROR("1000", "插入数据模型行为未成功"),

    INSERT_MODEL_DATA_ITEM_ERROR("1000", "插入数据模型数据项未成功");

    /**
     * 错误码
     */
    private final String code;

    /**
     * 错误描述
     */
    private final String message;

    ModelException(String code, String message) {
        this.code = code;
        this.message = message;
    }

    @Override
    public String getCode() {
        return code;
    }

    @Override
    public String getMessage() {
        return message;
    }

    @Override
    public String getModuleCode() {
        return ModelModule.MODULE_CODE;
    }
}
