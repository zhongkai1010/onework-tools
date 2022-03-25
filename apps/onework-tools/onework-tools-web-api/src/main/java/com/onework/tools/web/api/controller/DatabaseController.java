package com.onework.tools.web.api.controller;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.onework.tools.common.web.R;
import com.onework.tools.web.api.controller.model.database.ConnectionInput;
import com.onework.tools.web.api.controller.model.database.ConnectionOutput;
import com.onework.tools.web.api.entity.DatabaseConnection;
import com.onework.tools.web.api.service.IDatabaseConnectionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.web.api.controller
 * @Description: 描述
 * @date Date : 2022年03月25日 17:02
 */
@RestController
@RequestMapping("/database")
public class DatabaseController {

    @Autowired
    private IDatabaseConnectionService databaseConnectionService;

    @PostMapping("/connection/add")
    public R<ConnectionOutput> addConnection(@RequestBody ConnectionInput input) {
        R<ConnectionOutput> output = new R<>();

        DatabaseConnection databaseConnection = BeanUtil.copyProperties(input, DatabaseConnection.class);
         databaseConnectionService.save(databaseConnection);

        return output;
    }
}
