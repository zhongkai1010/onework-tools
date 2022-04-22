package com.onework.tools.database.controller;

import com.onework.tools.database.controller.model.db.DbInput;
import com.onework.tools.database.schema.DatabaseType;
import com.onework.tools.database.schema.DbSchemaFactory;
import com.onework.tools.database.schema.DbSchemaServer;
import com.onework.tools.database.schema.entity.DataColumn;
import com.onework.tools.database.schema.entity.DataDatabase;
import com.onework.tools.database.schema.entity.DataTable;
import com.onework.tools.web.R;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.function.Function;

/**
 * @author Administrator
 */
@RestController
public class DbController {

    @PostMapping("/db/{type}/all")
    public R<List<DataDatabase>> getAll(@PathVariable("type") String dbType, @RequestBody DbInput input) {

        R<List<DataDatabase>> defaultResult = new R<List<DataDatabase>>().forbidden("not data");

        return outResult(dbType, defaultResult, input, server -> {
            List<DataDatabase> dataDatabases = server.getDatabaseAndTables();

            return new R<List<DataDatabase>>().data(dataDatabases).success();
        });
    }

    @PostMapping("/db/{type}/{database}")
    public R<List<DataTable>> getTables(@PathVariable("type") String dbType, @PathVariable("database") String database,
        @RequestBody DbInput input) {

        R<List<DataTable>> defaultResult = new R<List<DataTable>>().forbidden("not data");

        return outResult(dbType, defaultResult, input, server -> {
            List<DataTable> dataTables = server.getDataTables(database);
            return new R<List<DataTable>>().data(dataTables).success();
        });
    }

    @PostMapping("/db/{type}/{database}/{table}")
    public R<List<DataColumn>> getColumns(@PathVariable("type") String dbType,
        @PathVariable("database") String database, @PathVariable(value = "table") String table,
        @RequestBody DbInput input) {

        input.setDatabase(database);
        R<List<DataColumn>> defaultResult = new R<List<DataColumn>>().forbidden("not data");

        return outResult(dbType, defaultResult, input, server -> {
            List<DataColumn> dataBaseColumns = server.getDataColumns(database, table);
            return new R<List<DataColumn>>().data(dataBaseColumns).success();
        });
    }

    @PostMapping("/db/{type}")
    public R<List<DataDatabase>> getDatabase(@PathVariable("type") String dbType, @RequestBody DbInput input) {

        R<List<DataDatabase>> defaultResult = new R<List<DataDatabase>>().forbidden("not data");

        return outResult(dbType, defaultResult, input, server -> {
            List<DataDatabase> dataDatabases = server.getDatabases();
            return new R<List<DataDatabase>>().data(dataDatabases).success();
        });
    }

    private <T> T outResult(String dbType, T defaultResult, DbInput input, Function<DbSchemaServer, T> func) {
        DatabaseType databaseType = DatabaseType.Map.get(dbType);
        if (databaseType == null) {
            return defaultResult;
        }
        DbSchemaServer dbSchemaServer =
            DbSchemaFactory.getDbSchemaServer(databaseType, input.getHost(), input.getPort(), input.getDatabase(),
                input.getUser(), input.getPassword());

        return func.apply(dbSchemaServer);
    }
}
