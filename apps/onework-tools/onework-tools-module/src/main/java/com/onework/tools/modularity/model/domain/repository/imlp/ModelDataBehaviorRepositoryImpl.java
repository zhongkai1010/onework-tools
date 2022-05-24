package com.onework.tools.modularity.model.domain.repository.imlp;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.modularity.model.ModelException;
import com.onework.tools.modularity.model.domain.repository.ModelDataBehaviorRepository;
import com.onework.tools.modularity.model.domain.vo.ModelDataBehaviorVo;
import com.onework.tools.modularity.model.entity.ModelDataBehavior;
import com.onework.tools.modularity.model.mapper.ModelDataBehaviorMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:52
 */
@Repository
public class ModelDataBehaviorRepositoryImpl implements ModelDataBehaviorRepository {

    private final ModelDataBehaviorMapper modelDataBehaviorMapper;

    @Autowired
    private ObjectMapper objectMapper;

    public ModelDataBehaviorRepositoryImpl(ModelDataBehaviorMapper modelDataBehaviorMapper) {
        this.modelDataBehaviorMapper = modelDataBehaviorMapper;
    }

    @Override
    public void deleteModeDataBehaviors(String dataCode) {
        LambdaQueryWrapper<ModelDataBehavior> lambdaQueryWrapper
            = new LambdaQueryWrapper<>();
        lambdaQueryWrapper.eq(com.onework.tools.modularity.model.entity.ModelDataBehavior::getDataCode, dataCode);
        modelDataBehaviorMapper.delete(lambdaQueryWrapper);
    }


    @Override
    public void insert(ModelDataBehaviorVo modelDataBehavior)  {
        ModelDataBehavior behavior
            = new ModelDataBehavior();

        CopyOptions copyOptions = new CopyOptions();
        copyOptions.setIgnoreProperties("inputs");
        copyOptions.setIgnoreProperties("output");

        BeanUtil.copyProperties(modelDataBehavior, behavior, copyOptions);

        String inputs = null;
        try {
            inputs = objectMapper.writeValueAsString(modelDataBehavior.getInputs());
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        String output = null;
        try {
            output = objectMapper.writeValueAsString(modelDataBehavior.getOutput());
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }

        behavior.setInputs(inputs);
        behavior.setOutput(output);

        int count = modelDataBehaviorMapper.insert(behavior);

        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_DATA_BEHAVIOR_ERROR));
    }
}
