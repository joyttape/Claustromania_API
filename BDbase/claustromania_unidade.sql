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
-- Table structure for table `unidade`
--

DROP TABLE IF EXISTS `unidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unidade` (
  `id` char(36) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `capacidade` int DEFAULT NULL,
  `horario_abertura` time DEFAULT NULL,
  `horario_fechamento` time DEFAULT NULL,
  `telefone` varchar(255) DEFAULT NULL,
  `ativa` tinyint(1) DEFAULT '1',
  `fk_endereco` char(36) DEFAULT NULL,
  `fk_funcionario` char(36) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_endereco` (`fk_endereco`),
  KEY `fk_funcionario` (`fk_funcionario`),
  CONSTRAINT `unidade_ibfk_1` FOREIGN KEY (`fk_endereco`) REFERENCES `endereco` (`id`),
  CONSTRAINT `unidade_ibfk_2` FOREIGN KEY (`fk_funcionario`) REFERENCES `funcionario` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidade`
--

LOCK TABLES `unidade` WRITE;
/*!40000 ALTER TABLE `unidade` DISABLE KEYS */;
INSERT INTO `unidade` VALUES ('07094ae7-b3cd-4620-a678-aa2d014e3094','Unidade Leste',60,'08:00:00','21:00:00','(31)92345-6789',1,'37cefc53-1898-4603-87ca-944a1f8e1461','f26b5e34-b7ac-4834-acd9-6fc51c4df8b4'),('22df9c32-0b24-4595-9508-0f317b528a50','Unidade Nova',50,'10:00:00','23:00:00','(81)97890-1234',1,'43ae5fb1-5544-4c9e-9f27-d379c2e36735','e7a36ebc-c0d1-4793-b8c3-6932ea98b326'),('39f7f961-3049-4edf-ad96-93cc1568ffd6','Unidade Oeste',35,'09:30:00','22:30:00','(41)93456-7890',1,'cf3815b7-8727-45c7-b2a7-962a7f21ad21','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),('76ae53fc-2d4a-42ac-9c40-630dd7495ef0','Unidade Centro',50,'09:00:00','22:00:00','(11)98765-4321',1,'8d32289a-293c-4476-94e7-543e1ba4e847','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),('802b5a95-3481-4cea-9c63-8e30d24a405e','Unidade Central',30,'09:00:00','22:00:00','(85)96789-0123',1,'790e6332-5ee7-4395-aa2e-f83047f26c2d','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),('9f1d74a8-69cb-483b-a5f6-646c9e6c832d','Unidade Principal',60,'09:30:00','22:30:00','(92)99012-3456',1,'97ca4370-9aeb-4ba6-af67-7e9bfee7f182','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),('add79077-5527-40a4-81c5-14db67e84859','Unidade Sul',55,'08:30:00','21:30:00','(71)95678-9012',1,'1206851e-394f-4dc1-ada5-97ef8943c30e','f26b5e34-b7ac-4834-acd9-6fc51c4df8b4'),('c66d47fa-9384-4e85-823f-488cfe1367a5','Unidade Norte',45,'10:30:00','23:30:00','(51)94567-8901',1,'72e85a1b-8404-4354-9ade-b3d74439fb58','e7a36ebc-c0d1-4793-b8c3-6932ea98b326'),('ce46e340-b144-4942-b9a7-b2b80a18bdc8','Unidade Zona Sul',40,'10:00:00','23:00:00','(21)91234-5678',1,'aae85497-ce90-4a5e-ab99-174c246cdc07','e7a36ebc-c0d1-4793-b8c3-6932ea98b326'),('db584d96-76f9-4dad-9b59-316c47da6cf7','Unidade Antiga',40,'08:00:00','21:00:00','(61)98901-2345',1,'813769ee-b1fe-42a1-aaa8-e07c51d7c60c','f26b5e34-b7ac-4834-acd9-6fc51c4df8b4');
/*!40000 ALTER TABLE `unidade` ENABLE KEYS */;
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
