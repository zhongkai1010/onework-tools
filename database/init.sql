/*
 Navicat Premium Data Transfer

 Source Server         : 101.37.81.183
 Source Server Type    : MySQL
 Source Server Version : 80025
 Source Host           : 101.37.81.183:8033
 Source Schema         : onework

 Target Server Type    : MySQL
 Target Server Version : 80025
 File Encoding         : 65001

 Date: 09/05/2022 09:55:47
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for ow_database_columns
-- ----------------------------
DROP TABLE IF EXISTS `ow_database_columns`;
CREATE TABLE `ow_database_columns`  (
                                        `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                        `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                        `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                        `cn_uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '连接uid',
                                        `db_uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据库uid',
                                        `tb_uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据库表uid',
                                        `db_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据库uid',
                                        `type` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '类型',
                                        `is_null` tinyint(1) NOT NULL COMMENT '是否为空',
                                        `is_unique` tinyint(1) NOT NULL COMMENT '是否主键',
                                        `length` bigint NULL DEFAULT NULL COMMENT '长度',
                                        `precision` int NULL DEFAULT NULL COMMENT '精度',
                                        `oredr` int NULL DEFAULT NULL COMMENT '序号',
                                        `default_value` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '默认值',
                                        `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '描述',
                                        `created_at` datetime NOT NULL,
                                        `updated_at` datetime NOT NULL,
                                        `deleted_at` datetime NULL DEFAULT NULL,
                                        PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_database_connections
-- ----------------------------
DROP TABLE IF EXISTS `ow_database_connections`;
CREATE TABLE `ow_database_connections`  (
                                            `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                            `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '连接名称',
                                            `db_type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据库类型',
                                            `database` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '默认数据库',
                                            `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '连接用户名',
                                            `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '连接密码',
                                            `host` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主机地址',
                                            `port` int NOT NULL COMMENT '端口',
                                            `config` json NULL COMMENT '其它配置',
                                            `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                                            `created_at` datetime NOT NULL,
                                            `updated_at` datetime NOT NULL,
                                            `deleted_at` datetime NULL DEFAULT NULL,
                                            PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_database_dbs
-- ----------------------------
DROP TABLE IF EXISTS `ow_database_dbs`;
CREATE TABLE `ow_database_dbs`  (
                                    `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                    `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                    `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                    `cn_uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '连接uid',
                                    `is_sync` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否同步',
                                    `last_sync_date` datetime NULL DEFAULT NULL COMMENT '最后同步时间',
                                    `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                                    `created_at` datetime NOT NULL,
                                    `updated_at` datetime NOT NULL,
                                    `deleted_at` datetime NULL DEFAULT NULL,
                                    PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_database_tables
-- ----------------------------
DROP TABLE IF EXISTS `ow_database_tables`;
CREATE TABLE `ow_database_tables`  (
                                       `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                       `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                       `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                       `cn_uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '连接uid',
                                       `db_uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '数据库uid',
                                       `db_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '数据库名称',
                                       `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '描述',
                                       `created_at` datetime NOT NULL,
                                       `updated_at` datetime NOT NULL,
                                       `deleted_at` datetime NULL DEFAULT NULL,
                                       PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_model_collections
-- ----------------------------
DROP TABLE IF EXISTS `ow_model_collections`;
CREATE TABLE `ow_model_collections`  (
                                         `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                         `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                         `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                         `items` json NOT NULL COMMENT '数据项集合',
                                         `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                                         `created_at` datetime NOT NULL,
                                         `updated_at` datetime NOT NULL,
                                         `deleted_at` datetime NULL DEFAULT NULL,
                                         PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_model_data_behaviors
-- ----------------------------
DROP TABLE IF EXISTS `ow_model_data_behaviors`;
CREATE TABLE `ow_model_data_behaviors`  (
                                            `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                            `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                            `data_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '数据模型code',
                                            `data_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '数据模型name',
                                            `inputs` json NULL COMMENT '输入参数，多条记录，[{type:AppCode.model.itemType,valueValue:\"\",value:\"\"}]',
                                            `output` json NULL COMMENT '输出参数,单条记录， {type:AppCode.model.itemType,valueValue:\"\",value:\"\"}]',
                                            `operation_type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作类型',
                                            `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                                            `created_at` datetime NOT NULL,
                                            `updated_at` datetime NOT NULL,
                                            `deleted_at` datetime NULL DEFAULT NULL,
                                            PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_model_data_items
-- ----------------------------
DROP TABLE IF EXISTS `ow_model_data_items`;
CREATE TABLE `ow_model_data_items`  (
                                        `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                        `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                        `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                        `type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'string' COMMENT '数据项类型',
                                        `data_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '数据项code',
                                        `data_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '数据项name',
                                        `ref_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '对象类型引用值',
                                        `array_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'string' COMMENT '数组类型子类型',
                                        `default_value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '默认值',
                                        `extData` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '扩展属性',
                                        `created_at` datetime NOT NULL,
                                        `updated_at` datetime NOT NULL,
                                        `deleted_at` datetime NULL DEFAULT NULL,
                                        PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_model_datas
-- ----------------------------
DROP TABLE IF EXISTS `ow_model_datas`;
CREATE TABLE `ow_model_datas`  (
                                   `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                   `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                   `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                   `use` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'universal' COMMENT '用途',
                                   `status` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'enable' COMMENT '状态',
                                   `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                                   `created_at` datetime NOT NULL,
                                   `updated_at` datetime NOT NULL,
                                   `deleted_at` datetime NULL DEFAULT NULL,
                                   PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_model_items
-- ----------------------------
DROP TABLE IF EXISTS `ow_model_items`;
CREATE TABLE `ow_model_items`  (
                                   `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                   `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                   `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                   `type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'string' COMMENT '数据项类型',
                                   `cumulate` int NOT NULL DEFAULT 0 COMMENT '使用累计总数',
                                   `created_at` datetime NOT NULL,
                                   `updated_at` datetime NOT NULL,
                                   `deleted_at` datetime NULL DEFAULT NULL,
                                   PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_module_error_messages
-- ----------------------------
DROP TABLE IF EXISTS `ow_module_error_messages`;
CREATE TABLE `ow_module_error_messages`  (
                                             `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '主键',
                                             `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '异常消息编码',
                                             `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '异常消息',
                                             `module_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块编码',
                                             `module_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块名称',
                                             `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '描述',
                                             `created_at` datetime NOT NULL,
                                             `updated_at` datetime NOT NULL,
                                             `deleted_at` datetime NULL DEFAULT NULL,
                                             PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_module_features
-- ----------------------------
DROP TABLE IF EXISTS `ow_module_features`;
CREATE TABLE `ow_module_features`  (
                                       `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                       `module_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块编码',
                                       `module_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块名称',
                                       `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                       `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                       `state` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '状态',
                                       `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                                       `ext_data` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '扩展信息',
                                       `created_at` datetime NOT NULL,
                                       `updated_at` datetime NOT NULL,
                                       `deleted_at` datetime NULL DEFAULT NULL,
                                       PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_modules
-- ----------------------------
DROP TABLE IF EXISTS `ow_modules`;
CREATE TABLE `ow_modules`  (
                               `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                               `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块编码，服务名',
                               `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块名称',
                               `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                               `created_at` datetime NOT NULL,
                               `updated_at` datetime NOT NULL,
                               `deleted_at` datetime NULL DEFAULT NULL,
                               PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_systems
-- ----------------------------
DROP TABLE IF EXISTS `ow_systems`;
CREATE TABLE `ow_systems`  (
                               `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                               `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
                               `created_at` datetime NOT NULL,
                               `updated_at` datetime NOT NULL,
                               `deleted_at` datetime NULL DEFAULT NULL,
                               PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_tool_comparisons
-- ----------------------------
DROP TABLE IF EXISTS `ow_tool_comparisons`;
CREATE TABLE `ow_tool_comparisons`  (
                                        `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                        `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                                        `code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
                                        `default_value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '缺省值',
                                        `datas` json NOT NULL COMMENT '对照数据',
                                        `created_at` datetime NOT NULL,
                                        `updated_at` datetime NOT NULL,
                                        `deleted_at` datetime NULL DEFAULT NULL,
                                        PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_tool_translations
-- ----------------------------
DROP TABLE IF EXISTS `ow_tool_translations`;
CREATE TABLE `ow_tool_translations`  (
                                         `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                                         `source` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '翻译来源，例如：百度',
                                         `dst` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '翻译后文本',
                                         `src` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '翻译前的文本',
                                         `from` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '需要翻译的语言',
                                         `to` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '翻译后的语言',
                                         `created_at` datetime NOT NULL,
                                         `updated_at` datetime NOT NULL,
                                         `deleted_at` datetime NULL DEFAULT NULL,
                                         PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_user_accounts
-- ----------------------------
DROP TABLE IF EXISTS `ow_user_accounts`;
CREATE TABLE `ow_user_accounts`  (
                                     `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
                                     `user_uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
                                     `account_type` int NOT NULL,
                                     `created_at` datetime NOT NULL,
                                     `updated_at` datetime NOT NULL,
                                     `deleted_at` datetime NULL DEFAULT NULL,
                                     PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for ow_users
-- ----------------------------
DROP TABLE IF EXISTS `ow_users`;
CREATE TABLE `ow_users`  (
                             `uid` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '唯一值，不重复',
                             `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '系统uid',
                             `display_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '模块uid',
                             `sex` int NULL DEFAULT NULL,
                             `birthday` datetime NULL DEFAULT NULL,
                             `mail` datetime NULL DEFAULT NULL,
                             `phone` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL,
                             `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
                             `enable_state` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT '0',
                             `active_state` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
                             `last_login_date` datetime NULL DEFAULT NULL,
                             `created_at` datetime NOT NULL,
                             `updated_at` datetime NOT NULL,
                             `deleted_at` datetime NOT NULL,
                             PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for version
-- ----------------------------
DROP TABLE IF EXISTS `version`;
CREATE TABLE `version`  (
    `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
