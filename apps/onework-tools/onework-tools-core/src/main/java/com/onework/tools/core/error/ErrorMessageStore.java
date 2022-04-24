package com.onework.tools.core.error;

import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.core.error
 * @className: ErrorMessageStroe
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/4/24 21:09
 * @version: 1.0
 */
@Component
public interface ErrorMessageStore {

    /**
     * 获取异常消息，当异常消息不存在则添加异常消息到数据库
     *
     * @param errorMessage:
     * @return List<ErrorMessage>
     * @author ZK
     * @description TODO
     * @date 2022/4/24 21:14
     */
    Map<String, String> getOrAddErrorMessage(Map<String, String> errorMessage);
}
