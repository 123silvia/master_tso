-- Adminer 4.7.8 MySQL dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

USE `tso`;

SET NAMES utf8mb4;

DROP TABLE IF EXISTS `act_check_work`;
CREATE TABLE `act_check_work` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_registration` int NOT NULL,
  `master_text` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `date_act` datetime NOT NULL,
  `master_sto` int NOT NULL,
  UNIQUE KEY `id` (`id`),
  KEY `master_sto` (`master_sto`),
  KEY `id_registration` (`id_registration`),
  CONSTRAINT `act_check_work_ibfk_2` FOREIGN KEY (`master_sto`) REFERENCES `master_sto` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `act_check_work_ibfk_3` FOREIGN KEY (`id_registration`) REFERENCES `registration_new_client` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `act_check_work`;
INSERT INTO `act_check_work` (`id`, `id_registration`, `master_text`, `date_act`, `master_sto`) VALUES
(1,	6,	'yuyuyuyuyuyuyuyuyuuyu',	'2021-03-14 17:21:38',	1),
(2,	1,	'tyuutuyuyuyuyu',	'2021-03-14 17:22:44',	3),
(4,	4,	'sdsdssdsdsdsds',	'2021-03-14 17:27:02',	4),
(5,	10,	'grtrtrtrtrtrtrtrtrtrtrtrtr',	'2021-03-14 17:50:05',	3),
(7,	8,	'gfgfgfgfg',	'2021-03-14 17:52:27',	1),
(8,	16,	'ggfgfgfgfgfgfgfgfg',	'2021-03-14 17:53:09',	1),
(10,	1,	'',	'2021-03-14 17:55:44',	1),
(11,	11,	'gfgfgfgfgfgfgfgfgf',	'2021-03-14 22:42:25',	3);

DROP TABLE IF EXISTS `after_list_service`;
CREATE TABLE `after_list_service` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_act_reg` int NOT NULL,
  `id_service` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_service` (`id_service`),
  KEY `id_act_reg` (`id_act_reg`),
  CONSTRAINT `after_list_service_ibfk_3` FOREIGN KEY (`id_service`) REFERENCES `service` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `after_list_service_ibfk_4` FOREIGN KEY (`id_act_reg`) REFERENCES `act_check_work` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `after_list_service`;
INSERT INTO `after_list_service` (`id`, `id_act_reg`, `id_service`) VALUES
(2,	4,	1),
(3,	4,	4),
(4,	5,	1),
(5,	5,	4),
(6,	5,	5),
(7,	7,	2),
(8,	7,	1),
(9,	11,	1),
(10,	11,	5),
(11,	11,	3);

DROP TABLE IF EXISTS `auto`;
CREATE TABLE `auto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `auto`;
INSERT INTO `auto` (`id`, `name`) VALUES
(1,	'Жигули'),
(2,	'Волга'),
(3,	'Джип'),
(4,	'Мерседес'),
(5,	'Лемузин');

DROP TABLE IF EXISTS `before_list_service`;
CREATE TABLE `before_list_service` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_reg_client` int NOT NULL,
  `id_service` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_reg_client` (`id_reg_client`),
  KEY `id_service` (`id_service`),
  CONSTRAINT `before_list_service_ibfk_2` FOREIGN KEY (`id_reg_client`) REFERENCES `registration_new_client` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `before_list_service_ibfk_3` FOREIGN KEY (`id_service`) REFERENCES `service` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `before_list_service`;
INSERT INTO `before_list_service` (`id`, `id_reg_client`, `id_service`) VALUES
(1,	4,	1),
(2,	4,	4),
(3,	4,	5),
(4,	5,	4),
(5,	5,	5),
(6,	6,	1),
(7,	7,	4),
(8,	8,	2),
(9,	8,	4),
(10,	8,	5),
(11,	9,	1),
(12,	9,	4),
(13,	109,	1),
(14,	109,	2);

DROP TABLE IF EXISTS `buff_client_auto`;
CREATE TABLE `buff_client_auto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_client` int NOT NULL,
  `id_auto` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_client` (`id_client`),
  KEY `id_auto` (`id_auto`),
  CONSTRAINT `buff_client_auto_ibfk_1` FOREIGN KEY (`id_client`) REFERENCES `client` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `buff_client_auto_ibfk_2` FOREIGN KEY (`id_auto`) REFERENCES `auto` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `buff_client_auto`;
INSERT INTO `buff_client_auto` (`id`, `id_client`, `id_auto`) VALUES
(1,	1,	1),
(2,	1,	2),
(3,	1,	3),
(4,	1,	4),
(6,	2,	1),
(8,	1,	5),
(9,	2,	5);

DROP TABLE IF EXISTS `client`;
CREATE TABLE `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `client`;
INSERT INTO `client` (`id`, `name`) VALUES
(1,	'Алла'),
(2,	'Наталья'),
(3,	'Юля'),
(4,	'Марина'),
(5,	'Надежда');

DROP TABLE IF EXISTS `master_sto`;
CREATE TABLE `master_sto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `master_sto`;
INSERT INTO `master_sto` (`id`, `name`) VALUES
(1,	'Инженер Миша'),
(2,	'Инженер Женя'),
(3,	'Инженер Андрей'),
(4,	'Инженер Вася'),
(5,	'Инженер Саша');

DROP TABLE IF EXISTS `registration_new_client`;
CREATE TABLE `registration_new_client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_client_n` int NOT NULL,
  `id_auto_n` int NOT NULL,
  `data_new` datetime NOT NULL,
  `client_text` text CHARACTER SET utf8 COLLATE utf8_general_mysql500_ci NOT NULL,
  `master_tso` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_client_n` (`id_client_n`),
  KEY `id_auto_n` (`id_auto_n`),
  KEY `master_tso` (`master_tso`),
  CONSTRAINT `registration_new_client_ibfk_1` FOREIGN KEY (`id_client_n`) REFERENCES `buff_client_auto` (`id_client`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `registration_new_client_ibfk_2` FOREIGN KEY (`id_auto_n`) REFERENCES `buff_client_auto` (`id_auto`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `registration_new_client_ibfk_3` FOREIGN KEY (`master_tso`) REFERENCES `master_sto` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `registration_new_client`;
INSERT INTO `registration_new_client` (`id`, `id_client_n`, `id_auto_n`, `data_new`, `client_text`, `master_tso`) VALUES
(1,	1,	1,	'2021-03-13 20:49:26',	'',	1),
(2,	1,	1,	'2021-03-13 20:53:25',	'',	1),
(3,	2,	5,	'2021-03-13 21:00:13',	'',	1),
(4,	1,	4,	'2021-03-25 22:51:14',	'ghghghghghghgh',	3),
(5,	2,	5,	'2021-03-13 23:03:01',	'ghbggkgkdfdfdfdfdfdfdf',	3),
(6,	1,	3,	'2021-03-13 23:07:51',	'ghghghghghgh',	3),
(7,	1,	2,	'2021-03-13 23:08:09',	'ghghghgh',	4),
(8,	1,	5,	'2021-03-13 23:12:25',	'fgfgfgfgfgfg',	4),
(9,	2,	5,	'2021-03-13 23:21:24',	'ghghghgh',	2),
(10,	1,	1,	'2021-03-13 23:25:50',	'',	1),
(11,	1,	1,	'2021-03-13 23:26:28',	'',	1),
(12,	1,	1,	'2021-03-13 23:47:04',	'',	1),
(13,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(14,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(15,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(16,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(17,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(18,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(19,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(20,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(21,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(22,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(23,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(24,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(25,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(26,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(27,	1,	1,	'2021-03-14 00:47:49',	'',	1),
(28,	1,	1,	'2021-03-14 00:48:43',	'',	1),
(29,	1,	1,	'2021-03-14 00:48:43',	'',	1),
(30,	1,	1,	'2021-03-14 00:48:43',	'',	1),
(31,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(32,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(33,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(34,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(35,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(36,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(37,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(38,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(39,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(40,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(41,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(42,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(43,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(44,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(45,	1,	1,	'2021-03-14 00:49:45',	'',	1),
(46,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(47,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(48,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(49,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(50,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(51,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(52,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(53,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(54,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(55,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(56,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(57,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(58,	1,	1,	'2021-03-14 00:51:02',	'',	1),
(59,	1,	1,	'2021-03-14 01:00:50',	'',	1),
(60,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(61,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(62,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(63,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(64,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(65,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(66,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(67,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(68,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(69,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(70,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(71,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(72,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(73,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(74,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(75,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(76,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(77,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(78,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(79,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(80,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(81,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(82,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(83,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(84,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(85,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(86,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(87,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(88,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(89,	1,	1,	'2021-03-14 01:03:48',	'',	1),
(90,	1,	1,	'2021-03-14 01:04:24',	'',	1),
(91,	1,	1,	'2021-03-14 01:04:24',	'',	1),
(92,	1,	1,	'2021-03-14 01:04:24',	'',	1),
(93,	1,	1,	'2021-03-14 01:04:24',	'',	1),
(94,	1,	1,	'2021-03-14 01:04:24',	'',	1),
(95,	1,	1,	'2021-03-14 01:04:24',	'',	1),
(96,	1,	1,	'2021-03-14 01:25:39',	'',	1),
(97,	2,	1,	'2021-03-14 01:26:17',	'',	1),
(98,	1,	1,	'2021-03-14 01:27:12',	'',	1),
(99,	1,	1,	'2021-03-14 01:27:12',	'',	1),
(100,	1,	1,	'2021-03-14 01:28:33',	'',	1),
(101,	1,	1,	'2021-03-14 01:28:33',	'',	1),
(102,	1,	1,	'2021-03-14 01:29:12',	'',	1),
(103,	1,	1,	'2021-03-14 01:30:12',	'',	1),
(104,	1,	1,	'2021-03-14 01:31:59',	'',	1),
(105,	2,	1,	'2021-03-14 01:32:17',	'fgffgfgfgfg',	1),
(106,	1,	1,	'2021-03-14 01:33:14',	'',	1),
(107,	1,	1,	'2021-03-14 01:33:24',	'',	1),
(108,	1,	1,	'2021-03-14 01:33:29',	'',	1),
(109,	1,	4,	'2021-03-14 22:41:30',	'fgfgfgf',	3),
(110,	1,	2,	'2021-03-14 22:42:02',	'hghghgh',	3);

DROP TABLE IF EXISTS `service`;
CREATE TABLE `service` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

TRUNCATE `service`;
INSERT INTO `service` (`id`, `name`) VALUES
(1,	'Замена масла'),
(2,	'Очистка салона машины'),
(3,	'Замена масляного фильтра'),
(4,	'Замена топливного фильтра'),
(5,	'Замена двигателя');

-- 2021-03-14 15:49:15
