package com.onework.tools.generator.controller;

import com.onework.tools.common.mvc.R;
import com.onework.tools.generator.entity.DatabaseConnection;
import com.onework.tools.generator.service.IDatabaseConnectionService;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.media.Schema;

import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
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
@RequestMapping("/databaseConnection")
public class DatabaseConnectionController {

    private final IDatabaseConnectionService databaseConnectionService;

    public DatabaseConnectionController(IDatabaseConnectionService databaseConnectionService) {
        this.databaseConnectionService = databaseConnectionService;
    }

    @RequestMapping(value = "getTest1", method = RequestMethod.GET)
    public R<String> getTest1(@RequestParam String params) {

        return new R<String>().success().data(params);
    }

    @PostMapping("getTest2")
    public R<TestData> getTest2(@RequestBody TestData params) {
        return new R<TestData>().success().data(params);
    }

    /**
     * @param params 新增参数
     * @return 结果
     */
    @RequestMapping(value = "insert", method = RequestMethod.POST)
    public R<DatabaseConnection> insert(@RequestBody DatabaseConnection params) {
        databaseConnectionService.save(params);
        return new R<DatabaseConnection>().success().data(params);
    }

    /**
     * @return 结果
     */
    @Operation(description = "查询", summary = "a")
    @RequestMapping(value = "getAll", method = RequestMethod.GET)
    public R<List<DatabaseConnection>> getAll() {
        List<DatabaseConnection> databaseConnections = databaseConnectionService.list();
        return new R<List<DatabaseConnection>>().success().data(databaseConnections);
    }
}
