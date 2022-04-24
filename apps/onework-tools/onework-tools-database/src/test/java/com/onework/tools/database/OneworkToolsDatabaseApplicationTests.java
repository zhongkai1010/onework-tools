package com.onework.tools.database;

import cn.hutool.core.util.EnumUtil;
import com.onework.tools.core.error.ErrorMessage;
import com.onework.tools.core.error.ExceptionEnum;
import com.onework.tools.core.module.ModuleManager;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

@SpringBootTest
class OneworkToolsDatabaseApplicationTests {

    @Test
    void contextLoads() {
        printEnum(DatabaseException.class);
    }

    private <E extends Enum<E> & ErrorMessage> void printEnum(Class<E> c) {

        Map<String, String> messageMap = new HashMap<>(17);

        EnumUtil.getEnumMap(c).values().forEach(ex -> {
            String code = ex.getCode();
            String key = String.format("%s.%s", "1200", code);
            if (!messageMap.containsKey(key)) {
                throw new RuntimeException(String.format("load module exception enum error key is repeat，key:%s", key));
            }
            messageMap.put(key, ex.getMessage());
        });
    }

    public <E extends Enum<E>& ErrorMessage> Map<String, String> getExceptionEnum(Class<E> enumClass) {

        Collection<E> exceptions =  EnumUtil.getEnumMap(enumClass).values();
        Map<String, String> messageMap = new HashMap<>(exceptions.size());

        for (E ex : exceptions) {
            String code = ex.getCode();
            String key = String.format("%s.%s", "1200", code);
            if (!messageMap.containsKey(key)) {
                throw new RuntimeException(String.format("load module exception enum error key is repeat，key:%s", key));
            }
            messageMap.put(key, ex.getMessage());
        }
        return messageMap;
    }
}
