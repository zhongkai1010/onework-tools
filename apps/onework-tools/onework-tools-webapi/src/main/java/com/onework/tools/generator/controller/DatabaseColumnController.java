package com.onework.tools.generator.controller;


import com.onework.tools.generator.entity.DatabaseColumn;
import com.onework.tools.generator.service.IDatabaseColumnService;
import io.swagger.v3.oas.annotations.Operation;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

/**
 * <p>
 * 前端控制器
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-16
 */
@RestController
@RequestMapping("/databaseColumn")
public class DatabaseColumnController {

    private final IDatabaseColumnService databaseColumnService;

    public DatabaseColumnController(IDatabaseColumnService databaseColumnService) {
        this.databaseColumnService = databaseColumnService;
    }

    /**
     * @param params
     * @return
     */
    @Operation(description = "新增", summary = "b")
    @RequestMapping(value = "insert", method = RequestMethod.POST)
    public DatabaseColumn insert(DatabaseColumn params) {
        databaseColumnService.save(params);
        return params;
    }

    /**
     * @return
     */
    @Operation(description = "查询", summary = "a")
    @RequestMapping(value = "getAll", method = RequestMethod.GET)
    public List<DatabaseColumn> getAll() {
        List<DatabaseColumn> databaseColumns = databaseColumnService.list();
        return databaseColumns;
    }
}

