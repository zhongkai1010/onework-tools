package com.onework.tools.message;

import com.onework.tools.domain.entity.NameCodeValue;
import com.onework.tools.ModuleEnum;
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
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:41
 */
@Component
public class MessageModule extends ModuleRegister {

    @Override
    protected NameCodeValue getModuleNameCode() {
        return ModuleEnum.MESSAGE;
    }

    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        MessageException[] exceptions = MessageException.values();
        for (MessageException exception : exceptions) {
            String code = exception.getCode();
            String message = exception.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }

}
