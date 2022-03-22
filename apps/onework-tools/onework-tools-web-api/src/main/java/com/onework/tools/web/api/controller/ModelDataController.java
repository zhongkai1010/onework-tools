package com.onework.tools.web.api.controller;

import com.onework.tools.web.api.entity.ModelData;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import com.onework.tools.common.web.AbstractCrudController;

/**
 * <p>
 *  前端控制器
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-22
 */
@RestController
@RequestMapping("/modelData")
public class ModelDataController extends AbstractCrudController<ModelData> {

}
