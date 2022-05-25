package com.onework.tools.modularity.translate;

import com.onework.tools.domain.entity.NameCodeValue;
import com.onework.tools.ModuleCode;
import com.onework.tools.error.ErrorMessage;
import com.onework.tools.error.ErrorMessageImlp;
import com.onework.tools.domain.module.ModuleRegister;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 15:41
 */
@Component
public class TranslationModule extends ModuleRegister {

    @Override
    protected NameCodeValue getModuleNameCode() {
        return ModuleCode.TRANSLATION;
    }

    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        TranslateException[] exceptions = TranslateException.values();
        for (TranslateException exception : exceptions) {
            String code = exception.getCode();
            String message = exception.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }
}
