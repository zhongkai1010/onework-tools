package com.onework.tools.model;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model
 * @Description: 描述
 * @date Date : 2022年04月22日 10:32
 */
public class ModelModule {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "3001";

    public final static String DELETE_MODEL_NOT_FIND = "0001";

    public final static String LINKED_MODEL_NOT_FIND = "0002";

    public final static String DELETE_MODEL_COLLECTION_EXIST = "0003";

    public final static String ADD_MODEL_COLLECTION_ITEM_NOT_FIND = "0004";

    public final static String DELETE_MODEL_ITEM_USE = "0005";

    public final static String SAVE_MODEL_DATA_NOT_FIND = "0006";

    public final static String DELETE_MODEL_DATA_ITEM_ERROR = "0007";

    public final static String SAVE_MODEL_DATA_ITEM_ERROR = "0008";

    public final static String SAVE_MODEL_DATA_BEHAVIOR_ERROR = "0009";

    public final static String INSERT_MODEL_COLLECTION_ERROR = "0001";
    public final static String UPDATE_MODEL_COLLECTION_ERROR = "0002";
    public final static String DELETE_MODEL_COLLECTION_ERROR = "0003";

    public final static String INSERT_MODEL_ITEM_ERROR = "0004";
    public final static String UPDATE_MODEL_ITEM_ERROR = "0005";
    public final static String DELETE_MODEL_ITEM_ERROR = "0006";

    public final static String INSERT_MODEL_DATA_ERROR = "0007";
    public final static String UPDATE_MODEL_DATA_ERROR = "0008";
    public final static String DELETE_MODEL_DATA_ERROR = "0009";

    public final static String INSERT_MODEL_DATA_BEHAVIOR_ERROR = "0010";

    public final static String INSERT_MODEL_DATA_ITEM_ERROR = "0011";

    public static String getModuleName() {
        return "数据模型领域模块";
    }

    public static String getModuleCode() {
        return MODULE_CODE;
    }

    public static Map<String, String> getErrorMessageMaps() {
        return new Hashtable<String, String>() {{
            put(DELETE_MODEL_NOT_FIND, "删除数据项操作失败，数据项不存在，Code：%s");
            put(LINKED_MODEL_NOT_FIND, "关联数据项操作失败，数据项不存在，Code：%s");
            put(DELETE_MODEL_COLLECTION_EXIST, "删除数据集合，集合不存在，Code：%s");
            put(ADD_MODEL_COLLECTION_ITEM_NOT_FIND, "添加数据集合，数据项不存在，Code：%s");
            put(DELETE_MODEL_ITEM_USE, "无法删除数据项，该数据项还在使用，Code：%s");
            put(SAVE_MODEL_DATA_NOT_FIND, "操作数据模型，该数据模型不存在，Code：%s");
            put(DELETE_MODEL_DATA_ITEM_ERROR, "删除数据模型项移除，Code：%s");
            put(SAVE_MODEL_DATA_ITEM_ERROR, "操作数据模型，数据项出现异常，Code：%s");
            put(SAVE_MODEL_DATA_BEHAVIOR_ERROR, "操作数据模型，行为出现异常，Code：%s");

            put(INSERT_MODEL_COLLECTION_ERROR, "插入数据项集合未成功");
            put(UPDATE_MODEL_COLLECTION_ERROR, "修改数据项集合未成功");
            put(DELETE_MODEL_COLLECTION_ERROR, "删除数据项集合未成功");

            put(INSERT_MODEL_ITEM_ERROR, "插入数据项未成功");
            put(UPDATE_MODEL_ITEM_ERROR, "修改数据项未成功");
            put(DELETE_MODEL_ITEM_ERROR, "删除数据项未成功");

            put(INSERT_MODEL_DATA_ERROR, "插入数据模型未成功");
            put(UPDATE_MODEL_DATA_ERROR, "修改数据模型未成功");
            put(DELETE_MODEL_DATA_ERROR, "删除数据模型未成功");

            put(INSERT_MODEL_DATA_BEHAVIOR_ERROR, "插入数据模型行为未成功");

            put(INSERT_MODEL_DATA_ITEM_ERROR, "插入数据模型数据项未成功");

        }};
    }
}
