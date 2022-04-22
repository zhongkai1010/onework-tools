package com.onework.tools.web;

import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.core.conditions.query.QueryWrapper;
import com.baomidou.mybatisplus.core.metadata.OrderItem;
import com.baomidou.mybatisplus.core.toolkit.ReflectionKit;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import com.baomidou.mybatisplus.extension.service.IService;
import io.swagger.v3.oas.annotations.Operation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.mvc
 * @Description: 描述
 * @date Date : 2021年12月17日 14:21
 */
public abstract class AbstractCrudController<T> {

    /**
     * 泛型类型
     */
    protected Class<T> entityClass = currentModelClass();

    /**
     * 存放泛型成员与数据库字段映射关系
     */
    protected Map<String, String> modelColumns = currentModelColumns();

    @Autowired
    protected IService<T> service;

    /**
     * @param params: 参数
     * @return R<T> 返回结果
     * @author ZK
     * @description 添加或修改数据
     * @date 2021/12/17 22:07
     */
    @Operation(description = "新增或删除", summary = "新增或删除")
    @PostMapping("addOrUpdate")
    public R<T> addOrUpdate(@RequestBody T params) {
        service.saveOrUpdate(params);
        return new R<T>().success().data(params);
    }

    /**
     * @param id: 数据id
     * @return R<Boolean>
     * @author ZK
     * @description 根据id获取数据
     * @date 2021/12/17 22:07
     */
    @Operation(description = "移除", summary = "移除")
    @PostMapping("remove/{id}")
    public R<Boolean> remove(@PathVariable String id) {
        return new R<Boolean>().success().data(service.removeById(id));
    }

    /**
     * @param id: 数据Id
     * @return R<T>
     * @author ZK
     * @description 获取详情
     * @date 2021/12/18 0:27
     */
    @Operation(description = "获取详情", summary = "获取详情")
    @PostMapping("get/{id}")
    public R<T> get(@PathVariable String id) {
        return new R<T>().success().data(service.getById(id));
    }

    /**
     * @param params: 查询参数
     * @return R<List < T>> 查询结果
     * @author ZK
     * @description 检索列表数据
     * @date 2021/12/18 0:35
     */
    @Operation(description = "查询", summary = "查询")
    @GetMapping("getAll")
    public R<List<T>> getAll(T params) {
        Map<String, Object> queryParams = getTypeValues(params);
        List<T> resultData = service.listByMap(queryParams);
        return new R<List<T>>().success().data(resultData);
    }

    /**
     * @param params: 查询条件
     * @param page:   页数
     * @param limit:  限制数
     * @param order:  排序
     * @return R<PageResult < T>>
     * @author ZK
     * @description 分页查询
     * @date 2021/12/18 23:22
     */
    @Operation(description = "分页查询", summary = "分页查询")
    @GetMapping("getPageAll")
    public R<PageResult<T>> getPageList(@RequestParam(value = "page", defaultValue = "1") long page,
        @RequestParam(value = "limit", defaultValue = "10") long limit,
        @RequestParam(value = "order", defaultValue = "uid desc") String order, T params) {

        Page<T> queryPage = new Page<>(page, limit);
        OrderItem orderItem = getOrderItem(order);
        if (orderItem != null) {
            queryPage.addOrder(orderItem);
        }
        Map<String, Object> queryMap = getTypeValues(params);
        QueryWrapper<T> queryWrapper = new QueryWrapper<>();
        queryMap.forEach(queryWrapper::eq);
        service.page(queryPage, queryWrapper);

        List<T> data = queryPage.getRecords();
        PageResult<T> pageResult = new PageResult<>(data, queryPage.getTotal());
        return new R<PageResult<T>>().success().data(pageResult);
    }

    /**
     * @return Class<T> 泛型类型
     * @author ZK
     * @description 获取泛型类型
     * @date 2021/12/19 11:53
     */
    protected Class<T> currentModelClass() {
        return (Class<T>)ReflectionKit.getSuperClassGenericType(getClass(), AbstractCrudController.class, 0);
    }

    /**
     * @return Map<String, String>
     * @author ZK
     * @description 获取泛型属性与表字段映射，便于构建查询条件
     * @date 2021/12/19 11:58
     */
    protected Map<String, String> currentModelColumns() {
        Field[] fields = currentModelClass().getDeclaredFields();
        Map<String, String> propertyMap = new HashMap<>(fields.length);
        for (Field field : fields) {
            String column = field.getName();
            TableField tableField = field.getAnnotation(TableField.class);
            if (tableField != null) {
                column = tableField.value();
            } else {
                TableId tableId = field.getAnnotation(TableId.class);
                if (tableId != null) {
                    column = tableId.value();
                }
            }
            propertyMap.put(field.getName(), column);
        }
        return propertyMap;
    }

    /**
     * @param order: 排序值
     * @return OrderItem 排序对象
     * @author ZK
     * @description 构建排序对象
     * @date 2021/12/19 9:36
     */
    private OrderItem getOrderItem(String order) {
        if (order == null) {
            return null;
        }
        if (order.length() == 0) {
            return null;
        }
        String[] values = order.split(" ");
        String propertyName = values[0];

        if (!modelColumns.containsKey(propertyName)) {
            return null;
        }
        String columnName = modelColumns.get(propertyName);

        boolean asc = false;
        if (values.length > 1) {
            asc = Objects.equals(values[1], "asc");
        }
        return new OrderItem(columnName, asc);
    }

    /**
     * @param entity: 参数值
     * @return Map<String, Object> 实体转换Map对象值
     * @author ZK
     * @description 转换查询条件
     * @date 2021/12/18 23:10
     */
    private Map<String, Object> getTypeValues(T entity) {
        Class<?> aClass = entity.getClass();
        Field[] declaredFields = aClass.getDeclaredFields();
        Map<String, Object> values = new HashMap<>(declaredFields.length);
        for (Field declaredField : declaredFields) {
            try {
                TableField tableField = declaredField.getAnnotation(TableField.class);
                if (tableField != null) {
                    declaredField.setAccessible(true);
                    String propertyName = declaredField.getName();
                    propertyName = propertyName.replaceFirst(propertyName.substring(0, 1),
                        propertyName.substring(0, 1).toUpperCase());
                    Method method = aClass.getMethod("get" + propertyName);
                    Object value = method.invoke(entity);
                    if (value != null) {
                        values.put(tableField.value(), value);
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return values;
    }
}