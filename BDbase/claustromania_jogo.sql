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
-- Table structure for table `jogo`
--

DROP TABLE IF EXISTS `jogo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jogo` (
  `id` char(36) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `descricao` text,
  `duracao` varchar(20) DEFAULT NULL,
  `dificuldade` enum('Facil','Medio','Dificil') DEFAULT NULL,
  `preco` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jogo`
--

LOCK TABLES `jogo` WRITE;
/*!40000 ALTER TABLE `jogo` DISABLE KEYS */;
INSERT INTO `jogo` VALUES ('19349bab-dfe4-4785-b535-0eeb2ec3d76a','O Roubo do Diamante','Planeje e execute o roubo de um diamante valioso.',NULL,'Medio',NULL),('19b115d0-13b4-41b1-a7a3-7541cdf06ff5','Viagem no Tempo','Corrija anomalias temporais em diferentes épocas.',NULL,'Facil',NULL),('5f3a816d-f7dd-4d01-94b6-ed51baf2a97c','O Mistério do Faraó','Desvende os segredos de uma tumba egípcia antiga.',NULL,'Medio',NULL),('5f658f36-4011-4887-8715-7502faa48918','A Casa Assombrada','Explore uma casa mal-assombrada e descubra seus segredos.',NULL,'Facil',NULL),('63d4a632-c081-4422-b67f-6e8cb53f2c54','O Apocalipse Zumbi','Lute contra hordas de zumbis e encontre um refúgio seguro.',NULL,'Dificil',NULL),('6e501c34-0a79-4063-8e12-b915641f70dc','O Tesouro Pirata','Encontre o tesouro escondido de um lendário pirata.',NULL,'Medio',NULL),('789425b6-bae4-4aac-b00f-8a10274504a6','Aventura Espacial','Uma missão intergaláctica para salvar a humanidade.',NULL,'Dificil',NULL),('8dbf6e2e-6137-4b73-94b6-67598f2952cf','Laboratório Secreto','Escape de um laboratório secreto antes que seja tarde demais.',NULL,'Facil',NULL),('be08eb0d-395e-49e9-abe4-1e97d5a62f46','A Fuga da Prisão','Um jogo de fuga desafiador em uma prisão de segurança máxima.',NULL,'Dificil',NULL),('d3c1f5da-f52a-47f4-87d8-0a98c37aa614','A Maldição da Floresta','Sobreviva a uma floresta amaldiçoada e quebre o feitiço.',NULL,'Dificil',NULL);
/*!40000 ALTER TABLE `jogo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-08 12:51:25
