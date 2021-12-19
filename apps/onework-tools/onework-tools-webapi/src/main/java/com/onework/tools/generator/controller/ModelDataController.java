package com.onework.tools.generator.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.onework.tools.common.web.AbstractCrudController;
import com.onework.tools.generator.entity.ModelData;

/**
 * <p>
 * 前端控制器
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-18
 */
@RestController
@RequestMapping("/modelData")
public class ModelDataController extends AbstractCrudController<ModelData> {

}
