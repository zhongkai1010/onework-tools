package com.onework.tools.generator;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.IFill;
import com.baomidou.mybatisplus.generator.config.DataSourceConfig;
import com.baomidou.mybatisplus.generator.config.OutputFile;
import com.baomidou.mybatisplus.generator.config.converts.MySqlTypeConvert;
import com.baomidou.mybatisplus.generator.config.po.LikeTable;
import com.baomidou.mybatisplus.generator.config.querys.MySqlQuery;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.fill.Column;
import com.baomidou.mybatisplus.generator.keywords.MySqlKeyWordsHandler;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.onework.tools.generator.mybaits.GeneratorConfigValue;
import com.onework.tools.generator.openapi.OpenApiParseFactory;
import com.onework.tools.generator.velocity.ControllerActionModel;
import com.onework.tools.generator.velocity.ControllerModel;
import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.VelocityEngine;

import java.io.IOException;
import java.io.StringWriter;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Properties;

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

        generatorCode();
    }

    private static void velocityTemplate() {
        // 初始化模板引擎
        VelocityEngine ve = new VelocityEngine();
        ve.setProperty("resource.loader", "class");
        //如果从文件系统中读取模板，那么属性值为org.apache.velocity.runtime.resource.loader.FileResourceLoader
        ve.setProperty("class.resource.loader.class",
            "org.apache.velocity.runtime.resource.loader.ClasspathResourceLoader");
        // 配置引擎上下文对象
        VelocityContext ctx = new VelocityContext();

        ControllerModel controllerModel = new ControllerModel();
        controllerModel.setClassName("TestController");

        ArrayList<ControllerActionModel> actions = new ArrayList<>();

        ControllerActionModel insertAction = new ControllerActionModel();
        insertAction.setMethodName("insert");
        actions.add(insertAction);

        ControllerActionModel updateAction = new ControllerActionModel();
        updateAction.setMethodName("update");
        actions.add(updateAction);

        controllerModel.setActions(actions);

        ctx.put("Controller", controllerModel);
        // 加载模板文件
        Template template = ve.getTemplate("text.java.vm");
        StringWriter sw = new StringWriter();
        // 渲染模板
        template.merge(ctx, sw);
        System.out.print(sw);
    }

    private static void parseJson() {

        String context = getFileContext();
        OpenApiParseFactory.parseJson(context);
    }

    private static String getFileContext() {
        try {
            String fileName =
                System.getProperty("user.dir").concat("/onework-tools-generator/src/main/resources/openapi3.json");
            Path path = Paths.get(fileName);
            byte[] bytes = Files.readAllBytes(path);
            List<String> allLines = Files.readAllLines(path, StandardCharsets.UTF_8);
            StringBuilder stringBuilder = new StringBuilder();
            allLines.forEach((o) -> stringBuilder.append(o));
            System.out.println(stringBuilder);
            return stringBuilder.toString();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    private static void readJsonFile() {
        String context = getFileContext();
        ObjectMapper objectMapper = new ObjectMapper();
        Object model = null;
        try {
            model = objectMapper.readValue(context, Object.class);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        System.out.println(model.getClass());
    }

    private static void generatorCode() {
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

        generatorConfigValue.getGlobalConfigValue()
            .setOutputDir(System.getProperty("user.dir").concat("/onework-tools-module/src/main/java"));

        generatorConfigValue.getPackageConfigValue()
            .setParent("com.onework.tools")
            .setModuleName("authentication")
            .setEntity("entity")
            .setMapper("mapper")
            .setService("service")
            .setServiceImpl("service.impl")
            .setPathInfo(new HashMap<OutputFile, String>(16) {private static final long serialVersionUID = -4418335994349371423L;{
                    put(OutputFile.mapperXml, System.getProperty("user.dir").concat("/onework-tools-module/src/main/resources/mapper/authentication"));
            }});

        generatorConfigValue.getTemplateConfigValue()
            .setDisableController(true);

        generatorConfigValue.getStrategyConfigValue()
            .setAddTablePrefix(new String[] { "ow_" })
            .setAddTableSuffix(new String[] { "s" })
            .setEnableCapitalMode(true)
            .setLikeTable(new LikeTable("user"))
        .getEntityBuilder()
//            .setConvertFileName(entityName-> {
//                System.out.printf("------------------------- %s",entityName);
//                return  entityName;
//            })
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

    private static void printSystemProperties() {

        /**
         * 获取系统配置值
         * sun.cpu.isalist
         * sun.desktop
         * sun.io.unicode.encoding
         * sun.cpu.endian
         * java.vendor.url.bug
         * file.separator
         * java.vendor
         * sun.boot.class.path
         * java.ext.dirs
         * java.version
         * java.vm.info
         * awt.toolkit
         * user.language
         * java.specification.vendor
         * sun.java.command
         * java.home
         * sun.arch.data.model
         * java.vm.specification.version
         * java.class.path
         * user.name
         * file.encoding
         * java.specification.version
         * java.awt.printerjob
         * user.timezone
         * user.home
         * os.version
         * sun.management.compiler
         * java.specification.name
         * java.class.version
         * java.library.path
         * sun.jnu.encoding
         * os.name
         * user.variant
         * java.vm.specification.vendor
         * java.io.tmpdir
         * line.separator
         * java.endorsed.dirs
         * os.arch
         * java.awt.graphicsenv
         * java.runtime.version
         * java.vm.specification.name
         * user.dir
         * user.country
         * user.script
         * sun.java.launcher
         * sun.os.patch.level
         * java.vm.name
         * file.encoding.pkg
         * path.separator
         * java.vm.vendor
         * java.vendor.url
         * sun.boot.library.path
         * java.vm.version
         * java.runtime.name
         */

        Properties properties = System.getProperties();
        properties.forEach((o, o2) -> System.out.println(String.format("%s:%s", o, System.getProperty(o.toString()))));
    }
}
