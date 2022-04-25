package com.onework.tools.domain.module.store;

import com.onework.tools.domain.module.entity.Module;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module.repository
 * @Description: 描述
 * @date Date : 2022年04月25日 15:33
 */
@Repository
public interface ModuleStore {

    /**
     * 根据code获取Module，无则返回null
     *
     * @param code
     * @return
     */
    Module getModule(String code);

    /**
     * 添加模块
     *
     * @param module
     * @return
     */
    boolean addModule(Module module);
}
