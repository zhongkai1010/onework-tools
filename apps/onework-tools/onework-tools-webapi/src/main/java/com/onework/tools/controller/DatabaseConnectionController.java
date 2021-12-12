package com.onework.tools.controller;

import com.onework.tools.generator.entity.DatabaseConnection;
import com.onework.tools.generator.mapper.DatabaseConnectionMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * <p>
 * 前端控制器
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-12
 */
@RestController
@RequestMapping("/databaseConnection")
public class DatabaseConnectionController {

    private final DatabaseConnectionMapper databaseConnectionMapper;

    public DatabaseConnectionController(DatabaseConnectionMapper databaseConnectionMapper) {
        this.databaseConnectionMapper = databaseConnectionMapper;
    }

    /**
     * 描述
     * 
     * @return ArrayList<DatabaseConnection>
     */
    @RequestMapping(value = "/getAll", method = RequestMethod.GET)
    @ResponseBody
    public List<DatabaseConnection> getAll() {
        List<DatabaseConnection> databaseConnections = databaseConnectionMapper.selectList(null);
        return databaseConnections;
    }
}
