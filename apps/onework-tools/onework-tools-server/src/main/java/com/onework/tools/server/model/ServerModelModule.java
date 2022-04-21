package com.onework.tools.server.model;

import com.onework.tools.core.module.Module;
import org.springframework.stereotype.Component;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 17:33
 */
@Component
public class ServerModelModule implements Module {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "3003";

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

    @Override
    public String getModuleName() {
        return "数据模型模块";
    }

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorMessageMaps() {
        return new Hashtable<String, String>() {
            {
                put(ServerModelModule.INSERT_MODEL_COLLECTION_ERROR, "插入数据项集合未成功");
                put(ServerModelModule.UPDATE_MODEL_COLLECTION_ERROR, "修改数据项集合未成功");
                put(ServerModelModule.DELETE_MODEL_COLLECTION_ERROR, "删除数据项集合未成功");

                put(ServerModelModule.INSERT_MODEL_ITEM_ERROR, "插入数据项未成功");
                put(ServerModelModule.UPDATE_MODEL_ITEM_ERROR, "修改数据项未成功");
                put(ServerModelModule.DELETE_MODEL_ITEM_ERROR, "删除数据项未成功");

                put(ServerModelModule.INSERT_MODEL_DATA_ERROR, "插入数据模型未成功");
                put(ServerModelModule.UPDATE_MODEL_DATA_ERROR, "修改数据模型未成功");
                put(ServerModelModule.DELETE_MODEL_DATA_ERROR, "删除数据模型未成功");

                put(ServerModelModule.INSERT_MODEL_DATA_BEHAVIOR_ERROR, "插入数据模型行为未成功");

                put(ServerModelModule.INSERT_MODEL_DATA_ITEM_ERROR, "插入数据模型数据项未成功");
            }
        };
    }
}
