-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: claustromania
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `caixa`
--

DROP TABLE IF EXISTS `caixa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `caixa` (
  `id` char(36) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `fk_unidade` char(36) NOT NULL,
  `fk_funcionario` char(36) NOT NULL,
  `data_hora_abertura` datetime NOT NULL,
  `data_hora_fechamento` datetime DEFAULT NULL,
  `valor_inicial` decimal(10,2) NOT NULL,
  `valor_final` decimal(10,2) DEFAULT NULL,
  `total_transacoes` int DEFAULT '0',
  `status` varchar(50) NOT NULL,
  `observacoes` text,
  PRIMARY KEY (`id`),
  KEY `fk_unidade` (`fk_unidade`),
  KEY `fk_funcionario` (`fk_funcionario`),
  CONSTRAINT `caixa_ibfk_1` FOREIGN KEY (`fk_unidade`) REFERENCES `unidade` (`id`),
  CONSTRAINT `caixa_ibfk_2` FOREIGN KEY (`fk_funcionario`) REFERENCES `funcionario` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caixa`
--

LOCK TABLES `caixa` WRITE;
/*!40000 ALTER TABLE `caixa` DISABLE KEYS */;
INSERT INTO `caixa` VALUES ('0f12d74e-69a1-4d40-a157-2b0af09af20e','Caixa 6 - U006','add79077-5527-40a4-81c5-14db67e84859','f5fef7c3-7e2c-462d-a0bd-0eeb1be1853b','2024-07-03 09:00:00',NULL,300.00,NULL,8,'Aberto',''),('475e811a-b988-45cc-a6b8-72b8b877d8a5','Caixa 7 - U007','802b5a95-3481-4cea-9c63-8e30d24a405e','9aa87fa5-7a06-4d65-a115-e27d0acf6ea2','2024-07-04 10:00:00','2024-07-04 19:00:00',800.00,1000.00,25,'Fechado',''),('592c0681-1d96-492e-bf7f-a31ac396b76a','Caixa 1 - U001','76ae53fc-2d4a-42ac-9c40-630dd7495ef0','f5fef7c3-7e2c-462d-a0bd-0eeb1be1853b','2024-07-01 09:00:00','2024-07-01 18:00:00',1000.00,1500.50,50,'Fechado','Caixa do dia 01/07'),('820a55e2-256c-4c65-8c43-07eadeb9c649','Caixa 4 - U004','39f7f961-3049-4edf-ad96-93cc1568ffd6','fb3905ec-6b92-4f94-8fa6-90d9794e2c0b','2024-07-02 11:00:00',NULL,200.00,NULL,5,'Aberto',''),('82a7f146-562e-431a-91bc-1ce1d017b828','Caixa 5 - U005','c66d47fa-9384-4e85-823f-488cfe1367a5','d9f73fcc-ffa0-4379-bd0b-a97bb791aabb','2024-07-03 08:00:00','2024-07-03 16:00:00',1200.00,1350.00,40,'Fechado',''),('95a4817b-7332-4936-8e64-e4fa3a84e190','Caixa 8 - U008','22df9c32-0b24-4595-9508-0f317b528a50','bafe18c7-0d88-4bd0-bdc8-7a5ff13f728d','2024-07-04 11:00:00',NULL,400.00,NULL,12,'Aberto',''),('ab75c695-5079-48db-865e-b2095f9fbdf7','Caixa 3 - U003','07094ae7-b3cd-4620-a678-aa2d014e3094','bafe18c7-0d88-4bd0-bdc8-7a5ff13f728d','2024-07-02 09:30:00','2024-07-02 17:30:00',750.00,900.25,30,'Fechado',''),('d068bef9-adbb-49b2-a548-e16bed5c07c7','Caixa 9 - U009','db584d96-76f9-4dad-9b59-316c47da6cf7','fb3905ec-6b92-4f94-8fa6-90d9794e2c0b','2024-07-05 09:00:00','2024-07-05 17:00:00',900.00,1100.00,35,'Fechado',''),('d57793cc-63cf-4d5c-a82f-c23d88a10d08','Caixa 2 - U002','ce46e340-b144-4942-b9a7-b2b80a18bdc8','9aa87fa5-7a06-4d65-a115-e27d0acf6ea2','2024-07-01 10:00:00',NULL,500.00,NULL,10,'Aberto',''),('da3d9ea4-a50a-4cd2-ac2c-8b60b3341ed3','Caixa 10 - U010','9f1d74a8-69cb-483b-a5f6-646c9e6c832d','d9f73fcc-ffa0-4379-bd0b-a97bb791aabb','2024-07-05 10:00:00',NULL,600.00,NULL,15,'Aberto','');
/*!40000 ALTER TABLE `caixa` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-08 12:51:24
