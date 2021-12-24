DROP TABLE IF EXISTS personnels;

CREATE TABLE personnels
(
    id    BIGINT(20)  NOT NULL COMMENT '主键ID',
    name  VARCHAR(30) NULL DEFAULT NULL COMMENT '姓名',
    age   INT(11)     NULL DEFAULT NULL COMMENT '年龄',
    email VARCHAR(50) NULL DEFAULT NULL COMMENT '邮箱',
    PRIMARY KEY (id)
);

DROP TABLE IF EXISTS `ow_accounts`;
CREATE TABLE `ow_accounts`
(
    `uid`        char(32)     NOT NULL COMMENT '主键',
    `user_id`    char(32)     NOT NULL COMMENT '用户Id',
    `type`       char(50)     NOT NULL COMMENT '账户类型，密码、微信、QQ',
    `data`       varchar(255) NULL DEFAULT NULL COMMENT '数据',
    `created_at` datetime     NOT NULL COMMENT '创建时间',
    `updated_at` datetime     NULL DEFAULT NULL COMMENT '修改时间',
    `deleted_at` datetime     NULL DEFAULT NULL COMMENT '删除时间',
    PRIMARY KEY (`uid`) USING BTREE
);

DROP TABLE IF EXISTS `ow_user_articles`;
CREATE TABLE `ow_user_articles`
(
    `uid`             char(32)     NOT NULL COMMENT '主键',
    `user_id`         char(32)     NOT NULL COMMENT '用户id',
    `title`           varchar(200) NOT NULL COMMENT '标题',
    `content`         longtext     NOT NULL COMMENT '内容',
    `created_at`      datetime     NOT NULL COMMENT '创建时间',
    `updated_at`      datetime     NULL DEFAULT NULL COMMENT '修改时间',
    `deleted_at`      datetime     NULL DEFAULT NULL COMMENT '删除时间',
    `deleted_user_id` char(32)     NULL DEFAULT NULL COMMENT '删除用户',
    PRIMARY KEY (`uid`) USING BTREE
);

DROP TABLE IF EXISTS `ow_users`;
CREATE TABLE `ow_users`
(
    `uid`        char(32)     NOT NULL COMMENT '主键',
    `user_name`  varchar(200) NOT NULL COMMENT '用户名',
    `user_email` varchar(255) NULL DEFAULT NULL COMMENT '用户邮箱',
    `user_phone` char(20)     NULL DEFAULT NULL COMMENT '用户手机',
    `created_at` datetime     NOT NULL COMMENT '创建时间',
    `updated_at` datetime     NULL DEFAULT NULL COMMENT '修改时间',
    `deleted_at` datetime     NULL DEFAULT NULL COMMENT '删除时间',
    PRIMARY KEY (`uid`) USING BTREE
);