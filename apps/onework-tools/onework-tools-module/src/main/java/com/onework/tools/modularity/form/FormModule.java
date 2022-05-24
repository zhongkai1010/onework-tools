package com.onework.tools.modularity.form;

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
public class FormModule extends ModuleRegister {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "B006";

    @Override
    protected String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    protected String getModuleName() {
        return "表单模块";
    }

    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        FormException[] exceptions = FormException.values();
        for (FormException exception : exceptions) {
            String code = exception.getCode();
            String message = exception.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }
}
