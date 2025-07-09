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
-- Table structure for table `transacao`
--

DROP TABLE IF EXISTS `transacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transacao` (
  `id` char(36) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `data_hora` datetime NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `fk_pessoa` char(36) DEFAULT NULL,
  `fk_caixa` char(36) DEFAULT NULL,
  `forma_pagamento` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pessoa` (`fk_pessoa`),
  KEY `fk_caixa` (`fk_caixa`),
  CONSTRAINT `transacao_ibfk_1` FOREIGN KEY (`fk_pessoa`) REFERENCES `pessoa` (`id`) ON DELETE SET NULL,
  CONSTRAINT `transacao_ibfk_2` FOREIGN KEY (`fk_caixa`) REFERENCES `caixa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transacao`
--

LOCK TABLES `transacao` WRITE;
/*!40000 ALTER TABLE `transacao` DISABLE KEYS */;
INSERT INTO `transacao` VALUES ('04218088-24f0-460e-a8c6-ec9c56ed09f8',75.00,'2024-07-02 09:45:00','Saida','0d84c2cc-bf36-4a95-b80d-b8bdf513e28f','ab75c695-5079-48db-865e-b2095f9fbdf7',NULL),('108d51b4-73cb-40ac-b3a3-4b33519b4aa7',250.00,'2024-07-04 16:00:00','Entrada','e1c2fc54-f199-42ca-a88c-7d656a53cd47','95a4817b-7332-4936-8e64-e4fa3a84e190',NULL),('15aed839-a1d6-47e1-ba93-7096dc59e494',90.00,'2024-07-04 10:45:00','Saida','3fe37e18-cc0c-4a2e-9991-1b13b1dd17c6','475e811a-b988-45cc-a6b8-72b8b877d8a5',NULL),('588aa7df-6015-4e0d-87af-68e4e5ba76a5',50.00,'2024-07-01 10:30:00','Saida','a7c8e304-0d56-40a2-91e3-9ea6909118c3','592c0681-1d96-492e-bf7f-a31ac396b76a',NULL),('6b8b14a0-fb58-4e20-adf5-0e1f364bb272',180.00,'2024-07-03 11:00:00','Entrada','4f9473cf-2d77-4a79-b83b-1d1572bb1f21','0f12d74e-69a1-4d40-a157-2b0af09af20e',NULL),('7b943d52-8634-4144-84e8-ede18c4be725',300.00,'2024-07-02 15:00:00','Entrada','a6c2a330-b330-4a3b-a8f4-5d445f55ceac','820a55e2-256c-4c65-8c43-07eadeb9c649',NULL),('9f76d6cb-608f-487d-a368-5c9412a80d6f',60.00,'2024-07-05 09:15:00','Saida','1ed7dc33-c86a-4898-b5e5-50f04d4d1df9','d068bef9-adbb-49b2-a548-e16bed5c07c7',NULL),('b66da4bd-c3c2-402c-8635-a623b3a75280',120.00,'2024-07-03 08:30:00','Saida','f1e24097-f69b-49ab-9b63-077315fd9d1f','82a7f146-562e-431a-91bc-1ce1d017b828',NULL),('c9cb8381-c06b-47c6-86a0-f1b1a0b9a59f',200.00,'2024-07-01 14:00:00','Entrada','07ca8a69-dcd1-46b3-9bfd-7d664273d27f','d57793cc-63cf-4d5c-a82f-c23d88a10d08',NULL),('e0704893-2b6c-409e-b717-268672e32cf8',150.00,'2024-07-01 10:15:00','Entrada','8ff5e380-3d76-4cbe-9deb-0fedb6f20c78','592c0681-1d96-492e-bf7f-a31ac396b76a',NULL);
/*!40000 ALTER TABLE `transacao` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-08 20:50:24
