package com.onework.tools.generator.controller;

import com.baomidou.mybatisplus.core.conditions.query.QueryWrapper;
import com.onework.tools.common.mvc.R;
import com.onework.tools.generator.entity.DatabaseConnection;
import com.onework.tools.generator.service.IDatabaseConnectionService;
import io.swagger.v3.oas.annotations.Operation;
import org.springframework.web.bind.annotation.*;

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

    /**
     * @param params:
     *            参数
     * @return R<DatabaseConnection> 结果
     * @author ZK
     * @description 新增或删除
     * @date 2021/12/16 23:21
     */
    @Operation(description = "新增或删除", summary = "新增或删除")
    @PostMapping("addOrUpdate")
    public R<DatabaseConnection> addOrUpdate(@RequestBody DatabaseConnection params) {
        databaseConnectionService.saveOrUpdate(params);
        return new R<DatabaseConnection>().success().data(params);
    }

    /**
     * @param params:
     *            参数
     * @return R 结果
     * @author ZK
     * @description 移除
     * @date 2021/12/16 23:24
     */
    @Operation(description = "移除", summary = "移除")
    @PostMapping("remove")
    public R remove(@RequestBody DatabaseConnection params) {
        QueryWrapper<DatabaseConnection> queryWrapper = new QueryWrapper<>();
        queryWrapper.lambda().eq(DatabaseConnection::getUid, params.getUid());
        databaseConnectionService.remove(queryWrapper);
        return new R<DatabaseConnection>().success().data(params);
    }

    /**
     * @param :
     *            参数
     * @return R<List<DatabaseConnection>> 结果
     * @author ZK
     * @description TODO
     * @date 2021/12/16 23:23
     */
    @Operation(description = "查询", summary = "查询")
    @GetMapping(value = "getAll")
    public R<List<DatabaseConnection>> getAll() {
        List<DatabaseConnection> databaseConnections = databaseConnectionService.list();
        return new R<List<DatabaseConnection>>().success().data(databaseConnections);
    }

    /**
     * @param :
     *            参数
     * @return R<List<DatabaseConnection>> 结果
     * @author ZK
     * @description 分页查询
     * @date 2021/12/16 23:23
     */
    @Operation(description = "分页查询", summary = "分页查询")
    @GetMapping(value = "getPageAll")
    public R<List<DatabaseConnection>> getPageAll() {
        List<DatabaseConnection> databaseConnections = databaseConnectionService.list();
        return new R<List<DatabaseConnection>>().success().data(databaseConnections);
    }
}
