package com.onework.tools.model.domain.repository.imlp;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.model.entity.ModelData;
import com.onework.tools.model.entity.ModelDataBehavior;
import com.onework.tools.model.entity.ModelDataItem;
import com.onework.tools.model.mapper.ModelDataBehaviorMapper;
import com.onework.tools.model.mapper.ModelDataItemMapper;
import com.onework.tools.model.mapper.ModelDataMapper;
import com.onework.tools.model.ModelException;
import com.onework.tools.model.domain.repository.ModelDataRepository;
import com.onework.tools.model.domain.vo.ModelDataBehaviorVo;
import com.onework.tools.model.domain.vo.ModelDataItemVo;
import com.onework.tools.model.domain.vo.ModelDataVo;
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
    public ModelDataVo query(String code) {

        ModelData modelData =
            new LambdaQueryChainWrapper<>(modelDataMapper).eq(ModelData::getCode, code)
                .one();
        return BeanUtil.copyProperties(modelData, ModelDataVo.class);
    }

    @Override
    public void insert(ModelDataVo modelData) {

        ModelData model =
            BeanUtil.copyProperties(modelData, ModelData.class);

        int count = modelDataMapper.insert(model);

        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_DATA_ERROR));
    }

    @Override
    public void update(ModelDataVo modelData) {

        boolean result =
            new LambdaUpdateChainWrapper<>(modelDataMapper).eq(ModelData::getCode,
                    modelData.getCode()).set(ModelData::getName, modelData.getName())
                .set(ModelData::getUse, modelData.getUse())
                .set(ModelData::getStatus, modelData.getStatus())
                .set(ModelData::getDescription, modelData.getDescription()).update();

        Check.isTrue(!result, new AppException(ModelException.UPDATE_MODEL_DATA_ERROR));
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<ModelData> queryChainWrapper =
            new LambdaQueryChainWrapper<>(modelDataMapper).eq(ModelData::getCode, code);

        int count = modelDataMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new AppException(ModelException.DELETE_MODEL_DATA_ERROR));
    }

    @Override
    public List<ModelDataItemVo> getItems(String dataCode) {

        List<ModelDataItemVo> data = new ArrayList<>();
        List<ModelDataItem> modelDataItems = new LambdaQueryChainWrapper<>(modelDataItemMapper).eq(
                ModelDataItem::getDataCode, dataCode).list();

        modelDataItems.forEach(modelDataItem -> data.add(BeanUtil.copyProperties(modelDataItem, ModelDataItemVo.class)));

        return data;
    }

    @Override
    public List<ModelDataBehaviorVo> getBehaviors(String dataCode) {
        List<ModelDataBehaviorVo> data = new ArrayList<>();
        List<ModelDataBehavior> modelDataItems =
            new LambdaQueryChainWrapper<>(modelDataBehaviorMapper).eq(
                ModelDataBehavior::getDataCode, dataCode).list();

        modelDataItems.forEach(modelDataItem -> {
            ModelDataBehaviorVo modelDataBehavior = new ModelDataBehaviorVo();
            CopyOptions copyOptions = new CopyOptions();

            copyOptions.setIgnoreProperties("inputs");
            copyOptions.setIgnoreProperties("output");

            BeanUtil.copyProperties(modelDataItem, modelDataBehavior, copyOptions);

            List<ModelDataBehaviorVo.ModelDataBehaviorInput> inputs = null;
            try {
                inputs = objectMapper.readValue(modelDataItem.getInputs(),
                    new TypeReference<List<ModelDataBehaviorVo.ModelDataBehaviorInput>>() {{
                    }});
            } catch (JsonProcessingException e) {
                inputs = new ArrayList<>();
            }
            modelDataBehavior.setInputs(inputs);

            ModelDataBehaviorVo.ModelDataBehaviorOutput output = null;
            try {
                output =
                    objectMapper.readValue(modelDataItem.getOutput(), ModelDataBehaviorVo.ModelDataBehaviorOutput.class);
            } catch (JsonProcessingException e) {

            }
            modelDataBehavior.setOutput(output);

            data.add(modelDataBehavior);
        });

        return data;
    }
}
