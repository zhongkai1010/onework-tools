package onework.springframework.sample.common;

import org.springframework.stereotype.Component;

import java.util.HashMap;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.common
 * @className: DefaultCacheManager
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/28 22:26
 * @version: 1.0
 */
@Component
public class DefaultCacheManager implements CacheManager {

    private HashMap<String, Object> cacheStore;

    public DefaultCacheManager() {
        this.cacheStore = new HashMap<String, Object>();
    }

    /**
     * 获取缓存
     *
     * @param key :
     * @return T
     * @author ZK
     * @description 获取缓存
     * @date 2021/12/28 22:25
     */
    @Override public <T> T get(String key) {
        System.out.println("获取缓存:" + key);
        T t = (T)cacheStore.get(key);
        return t;
    }

    /**
     * 是否存在缓存
     *
     * @param key :
     * @return Boolean
     * @author ZK
     * @description 是否存在缓存
     * @date 2021/12/28 22:41
     */
    @Override public Boolean exist(String key) {
        return cacheStore.containsKey(key);
    }

    /**
     * 移除缓存
     *
     * @param key :
     * @return void
     * @author ZK
     * @description 移除缓存
     * @date 2021/12/28 22:45
     */
    @Override public void remove(String key) {
        cacheStore.remove(key);
    }

    /**
     * 设置缓存
     *
     * @param key :
     * @param <T> :
     * @return T
     * @author ZK
     * @description 设置缓存
     * @date 2021/12/28 22:25
     */
    @Override public <T> void set(String key, T t) {
        cacheStore.put(key, t);
        System.out.println("设置缓存:" + key);
    }
}
