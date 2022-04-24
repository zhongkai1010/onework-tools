package com.onework.tools.core.error;

import com.onework.tools.common.CacheKeys;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.core.error
 * @className: ErrorMessageStoreImpl
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/4/24 21:52
 * @version: 1.0
 */
@Component
public class ErrorMessageStoreImpl implements ErrorMessageStore {
    /**
     * 获取异常消息，当异常消息不存在则添加异常消息到数据库
     *
     * @param errorMessage : 异常消息
     * @return List<ErrorMessage>
     */
    @Override
    @Cacheable(cacheNames = CacheKeys.ERROR_MESSAGE)
    public Map<String, String> getOrAddErrorMessage(Map<String, String> errorMessage) {
        return errorMessage;
    }
}
