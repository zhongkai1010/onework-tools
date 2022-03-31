package com.onework.tools.generator;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.IFill;
import com.baomidou.mybatisplus.generator.config.DataSourceConfig;
import com.baomidou.mybatisplus.generator.config.converts.MySqlTypeConvert;
import com.baomidou.mybatisplus.generator.config.po.LikeTable;
import com.baomidou.mybatisplus.generator.config.querys.MySqlQuery;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.fill.Column;
import com.baomidou.mybatisplus.generator.keywords.MySqlKeyWordsHandler;
import com.onework.tools.generator.config.GeneratorConfigValue;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator
 * @Description: 描述
 * @date Date : 2022年03月28日 14:16
 */
public class App {

    public static void main(String[] args) {

        final String jdbcUrl =
            "jdbc:mysql://101.37.81.183:8033/onework?characterEncoding=utf8&serverTimezone=Asia/Shanghai&useSSL=false";
        final String user = "root";
        final String password = "123qwe!@#mysql_root";

        // @formatter:off

        DataSourceConfig.Builder dataSourceConfig = new DataSourceConfig
            .Builder(jdbcUrl, user, password)
            .dbQuery(new MySqlQuery())
            .typeConvert(new MySqlTypeConvert())
            .keyWordsHandler(new MySqlKeyWordsHandler());
        FastAutoGenerator fastAutoGenerator = FastAutoGenerator.create(dataSourceConfig);

        GeneratorConfigValue generatorConfigValue = new GeneratorConfigValue();

        generatorConfigValue.getPackageConfigValue()
            .setParent("com.onework.tools.server")
            .setModuleName("database");

        generatorConfigValue.getTemplateConfigValue()
            .setDisableController(true);

        generatorConfigValue.getStrategyConfigValue()
            .setAddTablePrefix(new String[] { "ow_" })
            .setAddTableSuffix(new String[] { "s" })
            .setEnableCapitalMode(true)
            .setLikeTable(new LikeTable("database"))
        .getEntityBuilder()
            .setIdType(IdType.ASSIGN_ID)
            .setNaming(NamingStrategy.underline_to_camel)
            .setColumnNaming(NamingStrategy.underline_to_camel)
            .setLogicDeleteColumnName("deleted_at")
            .setEnableTableFieldAnnotation(true)
            .setAddTableFills( new IFill[] {
                    new Column("created_at", FieldFill.INSERT),
                    new Column("updated_at", FieldFill.INSERT_UPDATE),
                    new Column("deleted_at", FieldFill.DEFAULT),
            })
            .setEnableLombok(true).setEnableChainModel(true);

        GeneratorTool generatorTool = new GeneratorTool(fastAutoGenerator, generatorConfigValue);
        generatorTool.execute();

        // @formatter:on
    }
}
