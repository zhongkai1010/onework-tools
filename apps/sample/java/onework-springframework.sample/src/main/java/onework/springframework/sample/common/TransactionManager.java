package onework.springframework.sample.common;

import org.springframework.stereotype.Component;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.common
 * @className: TransactionManager
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/28 22:11
 * @version: 1.0
 */
@Component
public interface TransactionManager {

    /**
     * 开启事务
     *
     * @return void
     * @author ZK
     * @description TODO
     * @date 2021/12/28 22:12
     */
    void begin();

    /**
     * 提交事务
     *
     * @return void
     * @author ZK
     * @description TODO
     * @date 2021/12/28 22:12
     */
    void submit();

    /**
     * 回滚事务
     *
     * @return void
     * @author ZK
     * @description TODO
     * @date 2021/12/28 22:12
     */
    void rollback();
}
