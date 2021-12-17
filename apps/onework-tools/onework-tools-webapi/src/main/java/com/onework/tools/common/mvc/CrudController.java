package com.onework.tools.common.mvc;

import org.springframework.context.ApplicationContext;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import com.baomidou.mybatisplus.extension.service.IService;
import com.onework.tools.common.domain.BaseEntity;
import com.onework.tools.generator.entity.DatabaseConnection;

import io.swagger.v3.oas.annotations.Operation;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.mvc
 * @Description: 描述
 * @date Date : 2021年12月17日 14:21
 */
@RestController
public class CrudController<TEntity extends BaseEntity, TService extends IService<TEntity>> {

    private final ApplicationContext applicationContext;

    public CrudController(ApplicationContext applicationContext) {
        this.applicationContext = applicationContext;
    }

    /**
     * 新增
     * 
     * @param serviceName
     *            服务名
     * @param params
     *            参数
     * @return 结果
     */
    @Operation(description = "新增或删除", summary = "新增或删除")
    @PostMapping("{serviceName}/addOrUpdate")
    public R<?> addOrUpdate(@PathVariable String serviceName, @RequestBody Object params) {
        IService service = getService(serviceName);
        if (service == null) {
            return new R().validateFailed("该服务不存在，无法进行操作。");
        }
        service.saveOrUpdate(params);
        return new R<>().success().data(params);
    }

    /**
     * 移除
     * 
     * @param serviceName
     *            服务名
     * @param id
     *            参数
     * @return 结果
     */
    @Operation(description = "移除", summary = "移除")
    @PostMapping("{serviceName}/remove/{id}")
    public R remove(@PathVariable String serviceName, @PathVariable String id) {
        IService service = getService(serviceName);
        if (service == null) {
            return new R().validateFailed("该服务不存在，无法进行操作。");
        }
        Boolean result = service.removeById(id);
        if (result) {
            return new R<DatabaseConnection>().success();
        } else {
            return new R<DatabaseConnection>().validateFailed("该数据不存在，无法进行操作。");
        }
    }

    /* *//**
          * @param :
          *            参数
          * @return R<List<DatabaseConnection>> 结果
          * @author ZK
          * @description TODO
          * @date 2021/12/16 23:23
          */
    /*
    @Operation(description = "查询", summary = "查询")
    @GetMapping(value = "getAll")
    public R<List<DatabaseConnection>> getAll() {
     List<DatabaseConnection> databaseConnections = databaseConnectionService.list();
     return new R<List<DatabaseConnection>>().success().data(databaseConnections);
    }
    
    *//**
        * @param :
        *            参数
        * @return R<List<DatabaseConnection>> 结果
        * @author ZK
        * @description 分页查询
        * @date 2021/12/16 23:23
        *//*
          @Operation(description = "分页查询", summary = "分页查询")
          @GetMapping(value = "getPageAll")
          public R<List<DatabaseConnection>> getPageAll() {
           List<DatabaseConnection> databaseConnections = databaseConnectionService.list();
           return new R<List<DatabaseConnection>>().success().data(databaseConnections);
          }*/

    /**
     * 根据服务类名获取 Bean
     * 
     * @param serviceName
     * @return Bean
     */
    private IService getService(String serviceName) {
        String implClassName = String.format("%sServiceImpl", serviceName);
        implClassName = implClassName.substring(0, 1).toLowerCase() + implClassName.substring(1);
        String[] tempNames = applicationContext.getBeanDefinitionNames();
        Boolean isExis = applicationContext.containsBean(implClassName);
        if (!isExis) {
            return null;
        }

        IService<?> service = (IService)applicationContext.getBean(implClassName);
        return service;
    }
}
