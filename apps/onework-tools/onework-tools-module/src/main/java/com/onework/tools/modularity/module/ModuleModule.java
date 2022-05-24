package com.onework.tools.modularity.module;

import com.onework.tools.ErrorMessage;
import com.onework.tools.ErrorMessageImlp;
import com.onework.tools.domain.module.AppFeature;
import com.onework.tools.domain.module.ModuleRegister;
import com.onework.tools.domain.module.AppFeatureOperate;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:41
 */
@Component
public class ModuleModule extends ModuleRegister {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "B010";

    @Override
    protected String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    protected String getModuleName() {
        return "基础模块";
    }

    @Override
    protected List<AppFeature> getFeatures() {

        AppFeature feature = new AppFeature("module", "模块管理");

        // @formatter:off
        feature.addFeature(
            new AppFeature("module_list", "模块维护")
                .addOperate(new AppFeatureOperate("select", "查询")
                ),

            new AppFeature("module_error", "模块异常")
                .addOperate(
                    new AppFeatureOperate("select", "查询"),
                    new AppFeatureOperate("update", "修改")
                )
        );
        // @formatter:on
        return new ArrayList<AppFeature>() {{
            add(feature);
        }};
    }

    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        ModuleException[] exceptions = ModuleException.values();
        for (ModuleException exception : exceptions) {
            String code = exception.getCode();
            String message = exception.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }

}
