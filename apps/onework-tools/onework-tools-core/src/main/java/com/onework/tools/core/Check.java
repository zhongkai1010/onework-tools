package com.onework.tools.core;

import lombok.NonNull;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.domain
 * @Description: 描述
 * @date Date : 2022年03月29日 11:30
 */
public class Check {

    public static <T, E extends Throwable> void notNull(T value, E exception) throws E {
        if (value == null) {
            throw exception;
        }
    }

    public static <E extends Throwable> void notNull(E exception, Object... value) throws E {
        if (value == null) {
            throw exception;
        }
        for (Object obj : value) {
            if (obj == null) {
                throw exception;
            }
        }
    }

    public static <E extends Throwable> void notData(@NonNull ArrayList arrayList, E exception) throws E {
        if (arrayList.size() == 0) {
            throw exception;
        }
    }

    public static <T, E extends Throwable> void notData(@NonNull List<T> list, E exception) throws E {
        if (list.size() == 0) {
            throw exception;
        }
    }

    public static <T, E extends Throwable> void notData(@NonNull T[] list, E exception) throws E {
        if (Arrays.stream(list).count() == 0) {
            throw exception;
        }
    }

    public static <E extends Throwable> void notExecute(long count, E exception) throws E {
        if (count == 0) {
            throw exception;
        }
    }
}
