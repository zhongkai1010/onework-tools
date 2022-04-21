package com.onework.tools.server.model.repository;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.alibaba.fastjson.JSON;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.domain.model.dao.ModelData;
import com.onework.tools.domain.model.dao.ModelDataBehavior;
import com.onework.tools.domain.model.dao.ModelDataItem;
import com.onework.tools.domain.model.repository.ModelDataRepository;
import com.onework.tools.server.model.ServerModelException;
import com.onework.tools.server.model.ServerModelModule;
import com.onework.tools.server.model.mapper.ModelDataBehaviorMapper;
import com.onework.tools.server.model.mapper.ModelDataItemMapper;
import com.onework.tools.server.model.mapper.ModelDataMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:51
 */
@Repository
public class ModelDataRepositoryImpl implements ModelDataRepository {

    private final ModelDataMapper modelDataMapper;

    private final ModelDataItemMapper modelDataItemMapper;

    private final ModelDataBehaviorMapper modelDataBehaviorMapper;

    public ModelDataRepositoryImpl(ModelDataMapper modelDataMapper, ModelDataItemMapper modelDataItemMapper,
        ModelDataBehaviorMapper modelDataBehaviorMapper) {
        this.modelDataMapper = modelDataMapper;
        this.modelDataItemMapper = modelDataItemMapper;
        this.modelDataBehaviorMapper = modelDataBehaviorMapper;
    }

    @Override
    public ModelData query(String code) {

        com.onework.tools.server.model.entity.ModelData modelData =
            new LambdaQueryChainWrapper<>(modelDataMapper).eq(com.onework.tools.server.model.entity.ModelData::getCode,
                code).one();
        return BeanUtil.copyProperties(modelData, ModelData.class);
    }

    @Override
    public void insert(ModelData modelData) {

        com.onework.tools.server.model.entity.ModelData model =
            BeanUtil.copyProperties(modelData, com.onework.tools.server.model.entity.ModelData.class);

        int count = modelDataMapper.insert(model);

        Check.isTrue(count == 0, new ServerModelException(ServerModelModule.INSERT_MODEL_DATA_ERROR));
    }

    @Override
    public void update(ModelData modelData) {

        boolean result =
            new LambdaUpdateChainWrapper<>(modelDataMapper).eq(com.onework.tools.server.model.entity.ModelData::getCode,
                    modelData.getCode()).set(com.onework.tools.server.model.entity.ModelData::getName, modelData.getName())
                .set(com.onework.tools.server.model.entity.ModelData::getUse, modelData.getUse())
                .set(com.onework.tools.server.model.entity.ModelData::getStatus, modelData.getStatus())
                .set(com.onework.tools.server.model.entity.ModelData::getDescription, modelData.getDescription())
                .update();

        Check.isTrue(!result, new ServerModelException(ServerModelModule.UPDATE_MODEL_DATA_ERROR));
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<com.onework.tools.server.model.entity.ModelData> queryChainWrapper =
            new LambdaQueryChainWrapper<>(modelDataMapper).eq(com.onework.tools.server.model.entity.ModelData::getCode,
                code);

        int count = modelDataMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new ServerModelException(ServerModelModule.DELETE_MODEL_DATA_ERROR));
    }

    @Override
    public List<ModelDataItem> getItems(String dataCode) {

        List<ModelDataItem> data = new ArrayList<>();
        List<com.onework.tools.server.model.entity.ModelDataItem> modelDataItems =
            new LambdaQueryChainWrapper<>(modelDataItemMapper).eq(
                com.onework.tools.server.model.entity.ModelDataItem::getDataCode, dataCode).list();

        modelDataItems.forEach(modelDataItem -> data.add(BeanUtil.copyProperties(modelDataItem, ModelDataItem.class)));

        return data;
    }

    @Override
    public List<ModelDataBehavior> getBehaviors(String dataCode) {
        List<ModelDataBehavior> data = new ArrayList<>();
        List<com.onework.tools.server.model.entity.ModelDataBehavior> modelDataItems =
            new LambdaQueryChainWrapper<>(modelDataBehaviorMapper).eq(
                com.onework.tools.server.model.entity.ModelDataBehavior::getDataCode, dataCode).list();

        modelDataItems.forEach(modelDataItem -> {
            ModelDataBehavior modelDataBehavior = new ModelDataBehavior();
            CopyOptions copyOptions = new CopyOptions();

            copyOptions.setIgnoreProperties("inputs");
            copyOptions.setIgnoreProperties("output");

            BeanUtil.copyProperties(modelDataItem, modelDataBehavior, copyOptions);

            List<ModelDataBehavior.ModelDataBehaviorInput> inputs =
                JSON.parseArray(modelDataItem.getInputs(), ModelDataBehavior.ModelDataBehaviorInput.class);
            modelDataBehavior.setInputs(inputs);

            ModelDataBehavior.ModelDataBehaviorOutput output =
                JSON.parseObject(modelDataItem.getOutput(), ModelDataBehavior.ModelDataBehaviorOutput.class);
            modelDataBehavior.setOutput(output);

            data.add(modelDataBehavior);
        });

        return data;
    }
}
