package com.onework.tools.database;

import com.onework.tools.domain.entity.NameCodeValue;
import com.onework.tools.ModuleEnum;
import com.onework.tools.error.ErrorMessage;
import com.onework.tools.error.ErrorMessageImlp;
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
public class DatabaseModule extends ModuleRegister {

    @Override
    protected NameCodeValue getModuleNameCode() {
        return ModuleEnum.DATABASE;
    }

    @Override
    protected List<AppFeature> getFeatures() {
        AppFeature feature = new AppFeature("database", "数据库管理");
        // @formatter:off
        feature.addFeature(
            new AppFeature("database_connection", "连接维护")
                .addOperate(new AppFeatureOperate("add", "添加连接"))
                .addOperate(new AppFeatureOperate("update", "修改连接"))
                .addOperate(new AppFeatureOperate("delete", "删除连接"))
                .addOperate(new AppFeatureOperate("sync", "同步数据库"))
        );
        // @formatter:on
        return new ArrayList<AppFeature>() {{
            add(feature);
        }};
    }


    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        DatabaseException[] exceptions = DatabaseException.values();
        for (DatabaseException exception : exceptions) {
            String code = exception.getCode();
            String message = exception.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }
}
