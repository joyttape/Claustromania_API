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
-- Table structure for table `sala_jogo`
--

DROP TABLE IF EXISTS `sala_jogo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sala_jogo` (
  `id` char(36) NOT NULL,
  `fk_sala` char(36) NOT NULL,
  `fk_jogo` char(36) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_sala` (`fk_sala`),
  KEY `fk_jogo` (`fk_jogo`),
  CONSTRAINT `sala_jogo_ibfk_1` FOREIGN KEY (`fk_sala`) REFERENCES `sala` (`id`),
  CONSTRAINT `sala_jogo_ibfk_2` FOREIGN KEY (`fk_jogo`) REFERENCES `jogo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sala_jogo`
--

LOCK TABLES `sala_jogo` WRITE;
/*!40000 ALTER TABLE `sala_jogo` DISABLE KEYS */;
INSERT INTO `sala_jogo` VALUES ('0b87ceee-9bd8-435d-9632-e4083f4833f8','0d32ca0f-126a-4590-81bc-0a9e3861d687','d3c1f5da-f52a-47f4-87d8-0a98c37aa614'),('45ef8415-c45d-4935-9291-6b7dc13add7b','187608a5-62bb-41eb-bd69-f92d53c66b25','5f3a816d-f7dd-4d01-94b6-ed51baf2a97c'),('5057883e-a784-417d-b3b9-d69c7e3caec4','8260be36-035a-46eb-8f70-e7117a0f044d','6e501c34-0a79-4063-8e12-b915641f70dc'),('51241b56-aafb-45ce-94ef-bae1ff7762e8','b2bb0646-0856-41ad-8304-d95e528aa865','8dbf6e2e-6137-4b73-94b6-67598f2952cf'),('64e845a7-ee65-4dff-aa76-cb91c246e83e','256b4c94-926a-4151-bf4a-2d4b51ce5e7b','19b115d0-13b4-41b1-a7a3-7541cdf06ff5'),('7137a2db-4112-48db-a3fe-db78a90a922e','ca04bad3-78ae-4dee-bee2-b700c6efedbb','19349bab-dfe4-4785-b535-0eeb2ec3d76a'),('7869772f-4dd0-4b04-80bc-30cd0bc1a6bd','95b65723-4cf6-4365-8347-2979a0f1dd29','63d4a632-c081-4422-b67f-6e8cb53f2c54'),('7db7cb96-37b2-48b2-bd47-398b6d88216e','1d1b0e02-fb23-490e-88c7-38782ac50721','be08eb0d-395e-49e9-abe4-1e97d5a62f46'),('8fc5f2ef-e485-4a4a-96a6-46c4294f9273','4555e756-0ed6-4fc3-93ba-53d584431520','789425b6-bae4-4aac-b00f-8a10274504a6'),('a20c8118-8661-4a2e-98de-40a3c17ea25f','365d3645-fc23-48d5-b4b0-dc437b0fa55a','5f658f36-4011-4887-8715-7502faa48918');
/*!40000 ALTER TABLE `sala_jogo` ENABLE KEYS */;
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
