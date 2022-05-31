package com.onework.tools.web;

import lombok.Data;

import java.util.List;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.common.web
 * @className: PageResult
 * @author: 钟凯
 * @description: 分页结果
 * @date: 2021/12/18 21:12
 * @version: 1.0
 */

@Data
public class PageResult<T> {

    private List<T> data;

    private long total;

    public PageResult(List<T> data, long total) {
        this.data = data;
        this.total = total;
    }
}
