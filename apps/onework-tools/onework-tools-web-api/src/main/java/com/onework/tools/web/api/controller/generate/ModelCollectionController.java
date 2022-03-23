package com.onework.tools.web.api.controller.generate;

import com.onework.tools.web.api.entity.ModelCollection;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import com.onework.tools.common.web.AbstractCrudController;

/**
 * <p>
 *  前端控制器
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-23
 */
@RestController
@RequestMapping("/modelCollection")
public class ModelCollectionController extends AbstractCrudController<ModelCollection> {

}
