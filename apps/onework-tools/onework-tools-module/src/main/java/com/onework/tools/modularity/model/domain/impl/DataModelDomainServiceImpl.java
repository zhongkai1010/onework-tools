package com.onework.tools.modularity.model.domain.impl;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.model.ModelException;
import com.onework.tools.modularity.model.domain.DataModelDomainService;
import com.onework.tools.modularity.model.domain.ModelDomainService;
import com.onework.tools.modularity.model.domain.repository.ModelDataBehaviorRepository;
import com.onework.tools.modularity.model.domain.repository.ModelDataItemRepository;
import com.onework.tools.modularity.model.domain.repository.ModelDataRepository;
import com.onework.tools.modularity.model.domain.repository.ModelItemRepository;
import com.onework.tools.modularity.model.domain.vo.*;
import org.springframework.stereotype.Component;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model
 * @Description: 描述
 * @date Date : 2022年04月20日 15:29
 */
@Component
public class DataModelDomainServiceImpl implements DataModelDomainService {

    private final ModelDataRepository modelDataRepository;
    private final ModelDataItemRepository modelDataItemRepository;
    private final ModelItemRepository modelItemRepository;
    private final ModelDomainService modelDomainService;
    private final ModelDataBehaviorRepository modelDataBehaviorRepository;

    public DataModelDomainServiceImpl(ModelDataRepository modelDataRepository,
        ModelDataItemRepository modelDataItemRepository, ModelItemRepository modelItemRepository,
        ModelDomainService modelDomainService, ModelDataBehaviorRepository modelDataBehaviorRepository) {
        this.modelDataRepository = modelDataRepository;
        this.modelDataItemRepository = modelDataItemRepository;
        this.modelItemRepository = modelItemRepository;
        this.modelDomainService = modelDomainService;
        this.modelDataBehaviorRepository = modelDataBehaviorRepository;
    }

    @Override
    public ExecuteResult saveModelData(ModelDataVo modelData) {

        ModelDataVo model = handleModelData(modelData);

        return ExecuteResult.success();
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult saveModelData(ModelDataVo modelData, List<ModelDataItemVo> items,
        List<ModelDataBehaviorVo> behaviors, String description) {

        ModelDataVo model = handleModelData(modelData);

        deleteModelDataItems(modelData);
        items.forEach(modelDataItem -> handleModelDataItem(modelData, modelDataItem));

        handleModelDatabehaviors(model, behaviors);

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult saveModelDataItems(String code, List<ModelDataItemVo> items) {

        ModelDataVo model = modelDataRepository.query(code);
        Check.notNull(model, new AppException(ModelException.SAVE_MODEL_DATA_NOT_FIND, code));

        deleteModelDataItems(model);
        items.forEach(modelDataItem -> handleModelDataItem(model, modelDataItem));

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult saveModelDataBehaviors(String code, List<ModelDataBehaviorVo> behaviors) {

        ModelDataVo model = modelDataRepository.query(code);

        Check.notNull(model, new AppException(ModelException.SAVE_MODEL_DATA_NOT_FIND, code));

        handleModelDatabehaviors(model, behaviors);
        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult deleteModelData(String code) {

        ModelDataVo model = modelDataRepository.query(code);

        Check.notNull(model, new AppException(ModelException.SAVE_MODEL_DATA_NOT_FIND, code));

        modelDataBehaviorRepository.deleteModeDataBehaviors(code);
        deleteModelDataItems(model);
        deleteModelDataItems(model);

        return ExecuteResult.success();
    }

    private ModelDataVo handleModelData(ModelDataVo modelData) {

        ModelDataVo model = modelDataRepository.query(modelData.getCode());

        boolean isNew = false;
        if (model == null) {
            isNew = true;
            model = new ModelDataVo();
        }

        // 添加或修改数据模型
        BeanUtil.copyProperties(modelData, model);
        if (isNew) {
            modelDataRepository.insert(model);
        } else {
            modelDataRepository.update(model);
        }

        return model;
    }

    private void deleteModelDataItems(ModelDataVo modelData) {
        List<ModelDataItemVo> modelDataItems = modelDataRepository.getItems(modelData.getCode());

        modelDataItems.forEach(modelDataItem -> {
            ExecuteResult executeResult = modelDomainService.linkModelItem(modelDataItem.getCode(), false);
            Check.compareResult(executeResult,
                new AppException(ModelException.DELETE_MODEL_DATA_ITEM_ERROR, modelDataItem.getCode()));
        });

        modelDataItemRepository.deleteModeDataItems(modelData.getCode());
    }

    private void handleModelDataItem(ModelDataVo modelData, ModelDataItemVo modelDataItem) {

        ModelItemVo modelItem = modelItemRepository.query(modelDataItem.getCode());

        if (modelItem == null) {
            // 添加数据项
            ExecuteResult executeResult = modelDomainService.saveModelItem(modelDataItem.getCode(),
                modelDataItem.getName(), modelDataItem.getType());

            Check.compareResult(executeResult,
                new AppException(ModelException.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getCode()));
        }

        if (modelDataItem.getType() == ModelItemType.OBJECT) {
            ModelDataVo refModelData = modelDataRepository.query(modelDataItem.getRefCode());
            Check.notNull(refModelData,
                new AppException(ModelException.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getRefCode()));
        }

        if (modelDataItem.getType() == ModelItemType.ARRAY) {
            ModelDataVo arrayModelData = modelDataRepository.query(modelDataItem.getArrayCode());
            Check.notNull(arrayModelData,
                new AppException(ModelException.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getArrayCode()));
        }

        // 添加数据模型数据项
        modelDataItem.setDataCode(modelData.getCode());
        modelDataItem.setDataName(modelData.getName());
        modelDataItemRepository.insert(modelDataItem);

        // 计数数据项
        ExecuteResult executeResult = modelDomainService.linkModelItem(modelDataItem.getCode(), true);
        if (executeResult.compare(ExecuteResult.FAIL)) {
            throw new AppException(ModelException.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getCode());
        }
    }

    private void handleModelDatabehaviors(ModelDataVo modelData, List<ModelDataBehaviorVo> behaviors) {

        modelDataBehaviorRepository.deleteModeDataBehaviors(modelData.getCode());
        behaviors.forEach(modelDataBehavior -> {
            modelDataBehavior.setDataCode(modelData.getCode());
            modelDataBehavior.setDataName(modelData.getName());

            if (modelDataBehavior.getInputs() != null) {
                modelDataBehavior.getInputs().forEach((s) -> {
                    ModelDataVo refsModelData = modelDataRepository.query(s.getCode());
                    Check.notNull(refsModelData,
                        new AppException(ModelException.SAVE_MODEL_DATA_BEHAVIOR_ERROR, s.getCode()));
                });
            }

            if (modelDataBehavior.getOutput() != null) {
                ModelDataVo refsModelData = modelDataRepository.query(modelDataBehavior.getOutput().getCode());
                Check.notNull(refsModelData, new AppException(ModelException.SAVE_MODEL_DATA_BEHAVIOR_ERROR,
                    modelDataBehavior.getOutput().getCode()));
            }

            modelDataBehaviorRepository.insert(modelDataBehavior);
        });
    }
}
