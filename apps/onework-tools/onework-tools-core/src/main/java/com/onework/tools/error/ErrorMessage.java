package com.onework.tools.error;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 描述
 * @date Date : 2022年05月23日 15:28
 */

public interface ErrorMessage {

    /**
     * 描述
     *
     * @return
     */
    String getCode();

    /**
     * 描述
     *
     * @return
     */
    String getMessage();
}
