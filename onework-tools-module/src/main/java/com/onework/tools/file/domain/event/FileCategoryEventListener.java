package com.onework.tools.file.domain.event;

import com.onework.tools.file.FileCategoryManager;
import com.onework.tools.file.domain.repository.FileCategoryRepository;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryConfigVo;
import com.onework.tools.file.domain.vo.FileCategoryVo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationListener;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file
 * @Description: 描述
 * @date Date : 2022年05月26日 14:51
 */
@Component
public class FileCategoryEventListener implements ApplicationListener<FileCategoryEvent> {

    @Autowired
    private FileCategoryRepository fileCategoryRepository;

    @Override
    public void onApplicationEvent(FileCategoryEvent event) {

        FileCategoryVo fileCategoryVo = event.getFileCategory();
        String code = fileCategoryVo.getCode();
        // list转换map
        List<FileCategoryConfigVo> configs = fileCategoryRepository.getAllFileCategoryConfig();
        Map<FileCategoryConfigType, String> fileCategoryConfigMap = new HashMap<>(configs.size());
        configs.forEach(fileCategoryConfigVo -> fileCategoryConfigMap.put(fileCategoryConfigVo.getType(),
            fileCategoryConfigVo.getValue()));
        // 更新对于key
        FileCategoryManager.Configs.put(code, fileCategoryConfigMap);
    }
}
