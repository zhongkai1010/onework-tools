//package com.onework.tools.webapi.controller.database;
//
//import cn.hutool.core.bean.BeanUtil;
//import com.onework.tools.ExecuteResult;
//import com.onework.tools.modularity.database.domain.DatabaseDomainService;
//import com.onework.tools.modularity.database.domain.vo.Connection;
//import com.onework.tools.modularity.database.entity.DatabaseConnection;
//import com.onework.tools.modularity.database.service.IDatabaseConnectionService;
//import com.onework.tools.web.R;
//import com.onework.tools.webapi.controller.database.dto.ConnectionDto;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.web.bind.annotation.*;
//
//import java.util.ArrayList;
//import java.util.List;
//
///**
// * @author : zhongkai1010@163.com
// * @version V1.0
// * @Project: onework-tools
// * @Package com.onework.tools.webapi.controller
// * @Description: 描述
// * @date Date : 2022年04月27日 14:39
// */
//@RestController
//@RequestMapping("/database")
//public class DataBaseController {
//
//    @Autowired
//    private DatabaseDomainService databaseDomainService;
//
//    @Autowired
//    private IDatabaseConnectionService databaseConnectionService;
//
//    @PostMapping("connection/save")
//    public R<ConnectionDto> save(@RequestBody ConnectionDto input) {
//
//        Connection connection = BeanUtil.copyProperties(input, Connection.class);
//        ExecuteResult<Boolean> executeResult = databaseDomainService.saveConnection(connection, false);
//        if (executeResult.compare(ExecuteResult.SUCCESS)) {
//            return new R<ConnectionDto>().data(input).success();
//        } else {
//            return new R<ConnectionDto>().forbidden("error");
//        }
//    }
//
//    @GetMapping("connection/getList")
//    public R<ArrayList<ConnectionDto>> getConnectionList() {
//
//        List<DatabaseConnection> databaseConnections = databaseConnectionService.list();
//        ArrayList<ConnectionDto> connections = new ArrayList<>();
//        databaseConnections.forEach((databaseConnection) -> {
//            ConnectionDto dto = BeanUtil.copyProperties(databaseConnection, ConnectionDto.class);
//            connections.add(dto);
//        });
//        return new R<ArrayList<ConnectionDto>>().data(connections).success();
//    }
//
//    @PostMapping("connection/remove")
//    public R<Object> removeConnection(@RequestBody ArrayList<String> input) {
//
//        databaseDomainService.deleteConnection("");
//        return new R<>().success();
//    }
//}
