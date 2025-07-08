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
-- Table structure for table `sala`
--

DROP TABLE IF EXISTS `sala`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sala` (
  `id` char(36) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `capacidade` int DEFAULT NULL,
  `ativa` tinyint(1) DEFAULT '1',
  `fk_unidade` char(36) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_unidade` (`fk_unidade`),
  CONSTRAINT `sala_ibfk_1` FOREIGN KEY (`fk_unidade`) REFERENCES `unidade` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sala`
--

LOCK TABLES `sala` WRITE;
/*!40000 ALTER TABLE `sala` DISABLE KEYS */;
INSERT INTO `sala` VALUES ('0d32ca0f-126a-4590-81bc-0a9e3861d687','Sala Branca',4,1,NULL),('187608a5-62bb-41eb-bd69-f92d53c66b25','Sala Azul',8,1,NULL),('1d1b0e02-fb23-490e-88c7-38782ac50721','Sala Vermelha',6,1,NULL),('256b4c94-926a-4151-bf4a-2d4b51ce5e7b','Sala Dourada',8,1,NULL),('365d3645-fc23-48d5-b4b0-dc437b0fa55a','Sala Verde',4,1,NULL),('4555e756-0ed6-4fc3-93ba-53d584431520','Sala Amarela',6,1,NULL),('8260be36-035a-46eb-8f70-e7117a0f044d','Sala Roxa',5,1,NULL),('95b65723-4cf6-4365-8347-2979a0f1dd29','Sala Prata',5,1,NULL),('b2bb0646-0856-41ad-8304-d95e528aa865','Sala Laranja',7,1,NULL),('ca04bad3-78ae-4dee-bee2-b700c6efedbb','Sala Preta',6,1,NULL);
/*!40000 ALTER TABLE `sala` ENABLE KEYS */;
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
