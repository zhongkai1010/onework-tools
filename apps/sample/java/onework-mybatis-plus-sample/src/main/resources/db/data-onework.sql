DELETE
FROM personnels;

INSERT INTO personnels (id, name, age, email)
VALUES (1, 'Jone', 18, 'test1@baomidou.com'),
       (2, 'Jack', 20, 'test2@baomidou.com'),
       (3, 'Tom', 28, 'test3@baomidou.com'),
       (4, 'Sandy', 21, 'test4@baomidou.com'),
       (5, 'Billie', 24, 'test5@baomidou.com');

DELETE
FROM `ow_accounts`;

INSERT INTO `ow_accounts`
VALUES ('1', '1', 'password', '{\"password\":\"123456\"}', '2021-12-23 14:40:35', NULL, NULL);

DELETE
FROM `ow_user_articles`;
INSERT INTO `ow_user_articles`
VALUES ('1', '1', '第一篇', '我是内容', '2021-12-23 14:42:25', NULL, NULL,NULL);

DELETE
FROM `ow_users`;
INSERT INTO `ow_users`
VALUES ('1', 'zhongkai1010', 'zhongkai1010@163.com', '00000000000', '2021-12-23 14:39:55', NULL, NULL);