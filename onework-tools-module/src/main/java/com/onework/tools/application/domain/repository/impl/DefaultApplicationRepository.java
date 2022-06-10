package com.onework.tools.application.domain.repository.impl;

import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.vo.ApplicationVo;
import org.springframework.stereotype.Repository;

import java.util.HashMap;
import java.util.Map;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 15:55
 */
@Repository
public class DefaultApplicationRepository implements ApplicationRepository {

    private final Map<String, ApplicationVo> Data = new HashMap<>(0);

    @Override
    public ApplicationVo getApplicationByCode(String code) {
        if (Data.containsKey(code)) {
            return Data.get(code);
        }
        return null;
    }

    @Override
    public void insertApplication(ApplicationVo application) {
        if (!Data.containsKey(application.getCode())) {
            Data.put(application.getCode(), application);
        }
    }

    @Override
    public ApplicationVo getApplication(String uid) {
        return Data.values().stream().filter(applicationVo -> Objects.equals(applicationVo.getUid(), uid)).findFirst().get();
    }

    @Override
    public void updateApplication(ApplicationVo application) {
        if (Data.containsKey(application.getCode())) {
            Data.put(application.getCode(),application);
        }
    }

    @Override
    public void deleteApplication(ApplicationVo application) {
        Data.remove(application.getCode());
    }
}
