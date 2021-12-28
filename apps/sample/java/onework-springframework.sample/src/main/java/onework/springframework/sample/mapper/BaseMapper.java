package onework.springframework.sample.mapper;

import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.mapper.impl
 * @className: BaseMapper
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/28 21:43
 * @version: 1.0
 */
@Component
public interface BaseMapper<T> {

    /**
     * 获取所有实体对象
     *
     * @return long
     * @author ZK
     * @description 获取所有实体对象
     * @date 2021/12/28 21:44
     */
    List<T> getAll();

    /**
     * 添加
     * @param t:
     * @return T
     * @author ZK
     * @description 添加
     * @date 2021/12/28 21:49
     */
    T add(T t);
}
