package com.onework.tools.model.domain.repository.imlp;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.onework.tools.core.Check;
import com.onework.tools.core.error.AppException;
import com.onework.tools.model.ModelException;
import com.onework.tools.model.domain.repository.ModelDataRepository;
import com.onework.tools.model.domain.vo.ModelData;
import com.onework.tools.model.domain.vo.ModelDataBehavior;
import com.onework.tools.model.domain.vo.ModelDataItem;
import com.onework.tools.model.mapper.ModelDataBehaviorMapper;
import com.onework.tools.model.mapper.ModelDataItemMapper;
import com.onework.tools.model.mapper.ModelDataMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:51
 */
@Repository
public class ModelDataRepositoryImpl implements ModelDataRepository {

    private final ModelDataMapper modelDataMapper;

    private final ModelDataItemMapper modelDataItemMapper;

    private final ModelDataBehaviorMapper modelDataBehaviorMapper;

    private final ObjectMapper objectMapper;

    public ModelDataRepositoryImpl(ModelDataMapper modelDataMapper, ModelDataItemMapper modelDataItemMapper,
        ModelDataBehaviorMapper modelDataBehaviorMapper, ObjectMapper objectMapper) {
        this.modelDataMapper = modelDataMapper;
        this.modelDataItemMapper = modelDataItemMapper;
        this.modelDataBehaviorMapper = modelDataBehaviorMapper;
        this.objectMapper = objectMapper;
    }

    @Override
    public ModelData query(String code) {

        com.onework.tools.model.entity.ModelData modelData =
            new LambdaQueryChainWrapper<>(modelDataMapper).eq(com.onework.tools.model.entity.ModelData::getCode, code)
                .one();
        return BeanUtil.copyProperties(modelData, ModelData.class);
    }

    @Override
    public void insert(ModelData modelData) {

        com.onework.tools.model.entity.ModelData model =
            BeanUtil.copyProperties(modelData, com.onework.tools.model.entity.ModelData.class);

        int count = modelDataMapper.insert(model);

        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_DATA_ERROR));
    }

    @Override
    public void update(ModelData modelData) {

        boolean result =
            new LambdaUpdateChainWrapper<>(modelDataMapper).eq(com.onework.tools.model.entity.ModelData::getCode,
                    modelData.getCode()).set(com.onework.tools.model.entity.ModelData::getName, modelData.getName())
                .set(com.onework.tools.model.entity.ModelData::getUse, modelData.getUse())
                .set(com.onework.tools.model.entity.ModelData::getStatus, modelData.getStatus())
                .set(com.onework.tools.model.entity.ModelData::getDescription, modelData.getDescription()).update();

        Check.isTrue(!result, new AppException(ModelException.UPDATE_MODEL_DATA_ERROR));
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<com.onework.tools.model.entity.ModelData> queryChainWrapper =
            new LambdaQueryChainWrapper<>(modelDataMapper).eq(com.onework.tools.model.entity.ModelData::getCode, code);

        int count = modelDataMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new AppException(ModelException.DELETE_MODEL_DATA_ERROR));
    }

    @Override
    public List<ModelDataItem> getItems(String dataCode) {

        List<ModelDataItem> data = new ArrayList<>();
        List<com.onework.tools.model.entity.ModelDataItem> modelDataItems =
            new LambdaQueryChainWrapper<>(modelDataItemMapper).eq(
                com.onework.tools.model.entity.ModelDataItem::getDataCode, dataCode).list();

        modelDataItems.forEach(modelDataItem -> data.add(BeanUtil.copyProperties(modelDataItem, ModelDataItem.class)));

        return data;
    }

    @Override
    public List<ModelDataBehavior> getBehaviors(String dataCode) {
        List<ModelDataBehavior> data = new ArrayList<>();
        List<com.onework.tools.model.entity.ModelDataBehavior> modelDataItems =
            new LambdaQueryChainWrapper<>(modelDataBehaviorMapper).eq(
                com.onework.tools.model.entity.ModelDataBehavior::getDataCode, dataCode).list();

        modelDataItems.forEach(modelDataItem -> {
            ModelDataBehavior modelDataBehavior = new ModelDataBehavior();
            CopyOptions copyOptions = new CopyOptions();

            copyOptions.setIgnoreProperties("inputs");
            copyOptions.setIgnoreProperties("output");

            BeanUtil.copyProperties(modelDataItem, modelDataBehavior, copyOptions);

            List<ModelDataBehavior.ModelDataBehaviorInput> inputs = null;
            try {
                inputs = objectMapper.readValue(modelDataItem.getInputs(),
                    new TypeReference<List<ModelDataBehavior.ModelDataBehaviorInput>>() {{
                    }});
            } catch (JsonProcessingException e) {
                inputs = new ArrayList<>();
            }
            modelDataBehavior.setInputs(inputs);

            ModelDataBehavior.ModelDataBehaviorOutput output = null;
            try {
                output =
                    objectMapper.readValue(modelDataItem.getOutput(), ModelDataBehavior.ModelDataBehaviorOutput.class);
            } catch (JsonProcessingException e) {

            }
            modelDataBehavior.setOutput(output);

            data.add(modelDataBehavior);
        });

        return data;
    }
}
