package com.onework.tools.modularity.flow;

import com.onework.tools.ErrorMessage;
import com.onework.tools.ErrorMessageImlp;
import com.onework.tools.domain.module.ModuleRegister;
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
public class FlowModule extends ModuleRegister {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "B005";

    @Override
    protected String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    protected String getModuleName() {
        return "流程模块";
    }

    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        FlowException[] databaseExceptions = FlowException.values();
        for (FlowException databaseException : databaseExceptions) {
            String code = databaseException.getCode();
            String message = databaseException.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }
}
