package com.onework.tools.domain.model;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.model.dao.ModelData;
import com.onework.tools.domain.model.dao.ModelDataBehavior;
import com.onework.tools.domain.model.dao.ModelDataItem;
import com.onework.tools.domain.model.dao.ModelItem;
import com.onework.tools.domain.model.repository.ModelDataBehaviorRepository;
import com.onework.tools.domain.model.repository.ModelDataItemRepository;
import com.onework.tools.domain.model.repository.ModelDataRepository;
import com.onework.tools.domain.model.repository.ModelItemRepository;
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
public class ModelDataServiceImpl implements ModelDataService {

    private final ModelDataRepository modelDataRepository;
    private final ModelDataItemRepository modelDataItemRepository;
    private final ModelItemRepository modelItemRepository;
    private final ModelService modelService;
    private final ModelDataBehaviorRepository modelDataBehaviorRepository;

    public ModelDataServiceImpl(ModelDataRepository modelDataRepository,
        ModelDataItemRepository modelDataItemRepository, ModelItemRepository modelItemRepository,
        ModelService modelService, ModelDataBehaviorRepository modelDataBehaviorRepository) {
        this.modelDataRepository = modelDataRepository;
        this.modelDataItemRepository = modelDataItemRepository;
        this.modelItemRepository = modelItemRepository;
        this.modelService = modelService;
        this.modelDataBehaviorRepository = modelDataBehaviorRepository;
    }

    @Override
    public ExecuteResult saveModelData(ModelData modelData) {

        ModelData model = handleModelData(modelData);

        return ExecuteResult.success();
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult saveModelData(ModelData modelData, List<ModelDataItem> items,
        List<ModelDataBehavior> behaviors, String description) {

        ModelData model = handleModelData(modelData);

        deleteModelDataItems(modelData);
        items.forEach(modelDataItem -> handleModelDataItem(modelData, modelDataItem));

        handleModelDatabehaviors(model, behaviors);

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult saveModelDataItems(String code, List<ModelDataItem> items) {

        ModelData model = modelDataRepository.query(code);
        Check.notNull(model, new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_NOT_FIND, code));

        deleteModelDataItems(model);
        items.forEach(modelDataItem -> handleModelDataItem(model, modelDataItem));

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult saveModelDataBehaviors(String code, List<ModelDataBehavior> behaviors) {

        ModelData model = modelDataRepository.query(code);

        Check.notNull(model, new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_NOT_FIND, code));

        handleModelDatabehaviors(model, behaviors);
        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult deleteModelData(String code) {

        ModelData model = modelDataRepository.query(code);

        Check.notNull(model, new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_NOT_FIND, code));

        modelDataBehaviorRepository.deleteModeDataBehaviors(code);
        deleteModelDataItems(model);
        deleteModelDataItems(model);

        return ExecuteResult.success();
    }

    private ModelData handleModelData(ModelData modelData) {

        ModelData model = modelDataRepository.query(modelData.getCode());

        boolean isNew = false;
        if (model == null) {
            isNew = true;
            model = new ModelData();
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

    private void deleteModelDataItems(ModelData modelData) {
        List<ModelDataItem> modelDataItems = modelDataRepository.getItems(modelData.getCode());

        modelDataItems.forEach(modelDataItem -> {
            ExecuteResult executeResult = modelService.linkModelItem(modelDataItem.getCode(), false);
            Check.compareResult(executeResult,
                new DomainModelException(DomainModelModule.DELETE_MODEL_DATA_ITEM_ERROR, modelDataItem.getCode()));
        });

        modelDataItemRepository.deleteModeDataItems(modelData.getCode());
    }

    private void handleModelDataItem(ModelData modelData, ModelDataItem modelDataItem) {

        ModelItem modelItem = modelItemRepository.query(modelDataItem.getCode());

        if (modelItem == null) {
            // 添加数据项
            ExecuteResult executeResult =
                modelService.saveModelItem(modelDataItem.getCode(), modelDataItem.getName(), modelDataItem.getType());

            Check.compareResult(executeResult,
                new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getCode()));
        }

        if (modelDataItem.getType() == ModelItemType.OBJECT) {
            ModelData refModelData = modelDataRepository.query(modelDataItem.getRefCode());
            Check.notNull(refModelData,
                new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getRefCode()));
        }

        if (modelDataItem.getType() == ModelItemType.ARRAY) {
            ModelData arrayModelData = modelDataRepository.query(modelDataItem.getArrayCode());
            Check.notNull(arrayModelData,
                new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getArrayCode()));
        }

        // 添加数据模型数据项
        modelDataItem.setDataCode(modelData.getCode());
        modelDataItem.setDataName(modelData.getName());
        modelDataItemRepository.insert(modelDataItem);

        // 计数数据项
        ExecuteResult executeResult = modelService.linkModelItem(modelDataItem.getCode(), true);
        if (executeResult.compare(ExecuteResult.FAIL)) {
            throw new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_ITEM_ERROR, modelDataItem.getCode());
        }
    }

    private void handleModelDatabehaviors(ModelData modelData, List<ModelDataBehavior> behaviors) {

        modelDataBehaviorRepository.deleteModeDataBehaviors(modelData.getCode());
        behaviors.forEach(modelDataBehavior -> {
            modelDataBehavior.setDataCode(modelData.getCode());
            modelDataBehavior.setDataName(modelData.getName());

            if (modelDataBehavior.getInputs() != null) {
                modelDataBehavior.getInputs().forEach((s) -> {
                    ModelData refsModelData = modelDataRepository.query(s.getCode());
                    Check.notNull(refsModelData,
                        new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_BEHAVIOR_ERROR, s.getCode()));
                });
            }

            if (modelDataBehavior.getOutput() != null) {
                ModelData refsModelData = modelDataRepository.query(modelDataBehavior.getOutput().getCode());
                Check.notNull(refsModelData, new DomainModelException(DomainModelModule.SAVE_MODEL_DATA_BEHAVIOR_ERROR,
                    modelDataBehavior.getOutput().getCode()));
            }

            modelDataBehaviorRepository.insert(modelDataBehavior);
        });
    }
}
