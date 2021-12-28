package onework.springframework.sample.common;

import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Component;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.common
 * @className: DefaultTransactionManager
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/28 22:16
 * @version: 1.0
 */
@Component
@Primary
public class DefaultTransactionManager implements TransactionManager {
    /**
     * 开启事务
     *
     * @return void
     * @author ZK
     * @description TODO
     * @date 2021/12/28 22:12
     */
    @Override public void begin() {
        System.out.println("开启事务");
    }

    /**
     * 提交事务
     *
     * @return void
     * @author ZK
     * @description TODO
     * @date 2021/12/28 22:12
     */
    @Override public void submit() {
        System.out.println("提交事务");
    }

    /**
     * 回滚事务
     *
     * @return void
     * @author ZK
     * @description TODO
     * @date 2021/12/28 22:12
     */
    @Override public void rollback() {
        System.out.println("回滚事务");
    }
}
