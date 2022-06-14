package com.onework.tools.file.domain;

import cn.hutool.core.collection.ListUtil;
import com.onework.tools.ApplicationBoot;
import com.onework.tools.file.domain.repository.FileCategoryRepository;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryConfigVo;
import com.onework.tools.file.domain.vo.FileCategoryVo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file
 * @Description: 描述
 * @date Date : 2022年05月26日 11:01
 */
@Component
public class FileCategoryManager implements ApplicationBoot {

    public static Map<String, Map<FileCategoryConfigType, String>> Configs = new HashMap<>();

    @Autowired
    private FileCategoryRepository fileCategoryRepository;

    @Override
    public void init() {
//        Configs = loadFileCategory();
    }

    public Map<String, Map<FileCategoryConfigType, String>> loadFileCategory() {
        List<FileCategoryVo> fileCategoryVos = fileCategoryRepository.getAllFileCategory();
        List<FileCategoryConfigVo> fileCategoryConfigVos = fileCategoryRepository.getAllFileCategoryConfig();

        Map<String, Map<FileCategoryConfigType, String>> fileCategories = new HashMap<>(fileCategoryVos.size());

        fileCategoryVos.forEach(fileCategoryVo -> {
            // 筛选对于文件类别配置
            List<FileCategoryConfigVo> configs = ListUtil.filter(fileCategoryConfigVos, fileCategoryConfigVo -> {
                if (Objects.equals(fileCategoryVo.getUid(), fileCategoryConfigVo.getCategoryId())) {
                    return fileCategoryConfigVo;
                }
                return null;
            });
            // 组合文件类别配置
            Map<FileCategoryConfigType, String> fileCategoryConfigMap = new HashMap<>(configs.size());
            configs.forEach(fileCategoryConfigVo -> fileCategoryConfigMap.put(fileCategoryConfigVo.getType(),
                fileCategoryConfigVo.getValue()));
            fileCategories.put(fileCategoryVo.getCode(), fileCategoryConfigMap);
        });
        return fileCategories;
    }
}
