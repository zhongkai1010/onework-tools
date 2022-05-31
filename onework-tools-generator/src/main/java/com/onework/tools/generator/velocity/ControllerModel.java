package com.onework.tools.generator.velocity;

import lombok.Data;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.velocity.model
 * @Description: 描述
 * @date Date : 2022年04月19日 17:48
 */
@Data
public class ControllerModel {

    private String className;

    private List<ControllerActionModel> actions = new ArrayList<>();
}


