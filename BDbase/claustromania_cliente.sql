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
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id` char(36) NOT NULL,
  `nivel_experiencia` enum('Explorador','Aventureiro','Veterano','Lendário') NOT NULL,
  `fk_pessoa` char(36) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pessoa` (`fk_pessoa`),
  CONSTRAINT `cliente_ibfk_1` FOREIGN KEY (`fk_pessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES ('030b94b3-355b-4599-8385-dac54a7b21a3','Explorador','1ed7dc33-c86a-4898-b5e5-50f04d4d1df9'),('148f49bd-508c-4aca-a504-66f065d88fb0','Veterano','f1e24097-f69b-49ab-9b63-077315fd9d1f'),('31ded6ab-9cd4-4d60-872d-44b9b02baa1e','Aventureiro','3fe37e18-cc0c-4a2e-9991-1b13b1dd17c6'),('44d91ed6-26b8-408d-9c5b-e662722562dd','Lendário','e1c2fc54-f199-42ca-a88c-7d656a53cd47'),('75225a5c-2e61-454f-82cd-926def203e00','Explorador','4f9473cf-2d77-4a79-b83b-1d1572bb1f21'),('8f4f1063-8568-4188-ae3e-ab7098a6585a','Explorador','8ff5e380-3d76-4cbe-9deb-0fedb6f20c78'),('d6b05066-19f6-412d-9b84-a3813aacb413','Aventureiro','a6c2a330-b330-4a3b-a8f4-5d445f55ceac'),('dbf10332-2c2f-4cee-ab01-79637bdfd4aa','Aventureiro','a7c8e304-0d56-40a2-91e3-9ea6909118c3'),('ed59f436-c8ca-486a-8f8a-d10e87c0eff3','Explorador','0d84c2cc-bf36-4a95-b80d-b8bdf513e28f'),('f2596d40-6a31-4e80-9cff-0217db5bd029','Veterano','07ca8a69-dcd1-46b3-9bfd-7d664273d27f');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
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
