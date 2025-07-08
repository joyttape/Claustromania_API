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
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funcionario` (
  `id` char(36) NOT NULL,
  `cargo` varchar(100) NOT NULL,
  `salario` decimal(10,2) DEFAULT NULL,
  `data_contratacao` date DEFAULT NULL,
  `turno` varchar(20) DEFAULT NULL,
  `fk_pessoa` char(36) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pessoa` (`fk_pessoa`),
  CONSTRAINT `funcionario_ibfk_1` FOREIGN KEY (`fk_pessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES ('9aa87fa5-7a06-4d65-a115-e27d0acf6ea2','Recepcionista',NULL,NULL,NULL,'b48f3787-bef1-455e-9605-61ec3986a359'),('ab037fbc-29fa-47ad-a2b5-cdf20d559eb9','Limpeza',NULL,NULL,NULL,'67a612dc-8917-4196-9fe0-5149cef564ed'),('bafe18c7-0d88-4bd0-bdc8-7a5ff13f728d','Segurança',NULL,NULL,NULL,'b6b4a6be-61ba-4575-a707-5a70df80bfda'),('cc71cc61-b5fe-418e-a4cd-1e8bf5641839','Gerente',NULL,NULL,NULL,'d8d9007a-8442-41d1-968a-00a80100ba30'),('d0e58598-01b9-4f95-a137-de856c63440a','Manutenção',NULL,NULL,NULL,'11f17839-cb18-43df-8b93-089dd169d3d0'),('d9f73fcc-ffa0-4379-bd0b-a97bb791aabb','Recepcionista',NULL,NULL,NULL,'176704d6-0a6b-43a9-af79-28425634f63c'),('e7a36ebc-c0d1-4793-b8c3-6932ea98b326','Gerente',NULL,NULL,NULL,'ea707d12-48f3-47a1-b17d-579224d5911f'),('f26b5e34-b7ac-4834-acd9-6fc51c4df8b4','Gerente',NULL,NULL,NULL,'d66edf5e-8e93-47f6-8858-f38d77be6b88'),('f5fef7c3-7e2c-462d-a0bd-0eeb1be1853b','Atendente',NULL,NULL,NULL,'a47b8caf-bc98-43f0-8a80-2e4aa4848b9f'),('fb3905ec-6b92-4f94-8fa6-90d9794e2c0b','Atendente',NULL,NULL,NULL,'91f7b9bb-28c2-4f45-abc9-f6cb14cc5d47');
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
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
