package com.onework.tools.dictionary;

import com.onework.tools.ModuleEnum;
import com.onework.tools.dictionary.domain.DictionaryItemDomainService;
import com.onework.tools.domain.entity.NameCodeValue;
import com.onework.tools.domain.module.ModuleRegister;
import com.onework.tools.error.ErrorMessage;
import com.onework.tools.error.ErrorMessageImlp;
import org.springframework.beans.factory.annotation.Autowired;
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
public class DictionaryModule extends ModuleRegister {

    @Autowired
    private DictionaryItemDomainService dictionaryDomainService;

    @Override
    protected NameCodeValue getModuleNameCode() {
        return ModuleEnum.DICTIONARY;
    }

    @Override
    protected List<ErrorMessage> getErrorMessages() {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        DictionaryException[] exceptions = DictionaryException.values();
        for (DictionaryException exception : exceptions) {
            String code = exception.getCode();
            String message = exception.getMessage();
            errorMessages.add(new ErrorMessageImlp(code, message));
        }
        return errorMessages;
    }

    @Override
    public void init() {
        super.init();
//        List<DictionaryGroupVo> errorMessages = new ArrayList<>();
//        DictionaryGroupEnum[] groupData = DictionaryGroupEnum.values();
//        for (DictionaryGroupValue dictionaryGroup : groupData) {
//            // 添加字典组
//            DictionaryGroupVo dictionaryGroupVo = new DictionaryGroupVo();
//            dictionaryGroupVo.setName(dictionaryGroup.getName());
//            dictionaryGroupVo.setCode(dictionaryGroup.getCode());
//            dictionaryGroupVo.setType(DictionaryGroupType.ONE);
//            dictionaryDomainService.addDictionaryGroup(dictionaryGroupVo);
//            // 添加字典项
//            List<DictionaryItemVo> dictionaryItemVos = new ArrayList<>();
//            Map<String, String> items = dictionaryGroup.getItems();
//            if (items != null) {
//                items.forEach((k, v) -> {
//                    DictionaryItemVo dictionaryItemVo = new DictionaryItemVo();
//                    dictionaryItemVo.setName(k);
//                    dictionaryItemVo.setValue(v);
//                    dictionaryItemVos.add(dictionaryItemVo);
//                });
//
//            }
//
//            dictionaryDomainService.addDictionaryGroupItems(dictionaryGroupVo.getUid(), dictionaryItemVos);
//        }
    }
}
