package onework.springframework.sample.common;

import org.springframework.stereotype.Component;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.common
 * @className: CacheManager
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/28 22:24
 * @version: 1.0
 */
@Component
public interface CacheManager {

    /**
     * 获取缓存
     *
     * @param key: key
     * @return T
     * @author ZK
     * @description 获取缓存
     * @date 2021/12/28 22:37
     */
    <T> T get(String key);

    /**
     * 是否存在缓存
     *
     * @param key:
     * @return Boolean
     * @author ZK
     * @description 是否存在缓存
     * @date 2021/12/28 22:41
     */
    Boolean exist(String key);

    /**
     * 移除缓存
     * @param key:
     * @return void
     * @author ZK
     * @description 移除缓存
     * @date 2021/12/28 22:45
     */
    void remove(String key);

    /**
     * 设置缓存
     *
     * @param key:
     * @param t:
     * @return void
     * @author ZK
     * @description 设置缓存
     * @date 2021/12/28 22:37
     */
    <T> void set(String key, T t);
}
