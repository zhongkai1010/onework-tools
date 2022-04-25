package com.onework.tools.service.model.repository;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.alibaba.fastjson.JSON;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.core.error.AppException;
import com.onework.tools.domain.model.ModelException;
import com.onework.tools.domain.model.entity.ModelDataBehavior;
import com.onework.tools.domain.model.repository.ModelDataBehaviorRepository;
import com.onework.tools.service.model.mapper.ModelDataBehaviorMapper;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.dao.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:52
 */
@Repository
public class ModelDataBehaviorRepositoryImpl implements ModelDataBehaviorRepository {

    private final ModelDataBehaviorMapper modelDataBehaviorMapper;

    public ModelDataBehaviorRepositoryImpl(ModelDataBehaviorMapper modelDataBehaviorMapper) {
        this.modelDataBehaviorMapper = modelDataBehaviorMapper;
    }

    @Override
    public void deleteModeDataBehaviors(String dataCode) {
        LambdaQueryWrapper<com.onework.tools.service.model.entity.ModelDataBehavior> lambdaQueryWrapper =
            new LambdaQueryWrapper<>();
        lambdaQueryWrapper.eq(com.onework.tools.service.model.entity.ModelDataBehavior::getDataCode, dataCode);
        modelDataBehaviorMapper.delete(lambdaQueryWrapper);
    }

    @Override
    public void insert(ModelDataBehavior modelDataBehavior) {
        com.onework.tools.service.model.entity.ModelDataBehavior behavior =
            new com.onework.tools.service.model.entity.ModelDataBehavior();

        CopyOptions copyOptions = new CopyOptions();
        copyOptions.setIgnoreProperties("inputs");
        copyOptions.setIgnoreProperties("output");

        BeanUtil.copyProperties(modelDataBehavior, behavior, copyOptions);

        String inputs = JSON.toJSONString(modelDataBehavior.getInputs());
        String output = JSON.toJSONString(modelDataBehavior.getOutput());

        behavior.setInputs(inputs);
        behavior.setOutput(output);

        int count = modelDataBehaviorMapper.insert(behavior);

        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_DATA_BEHAVIOR_ERROR));
    }
}
