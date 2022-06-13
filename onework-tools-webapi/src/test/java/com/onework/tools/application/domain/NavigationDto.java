package com.onework.tools.application.domain;

import lombok.Data;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain
 * @Description: 描述
 * @date Date : 2022年06月13日 17:55
 */
@Data
public class NavigationDto {

    private String name;

    private String parentId;

    private List<NavigationDto> child;
}
