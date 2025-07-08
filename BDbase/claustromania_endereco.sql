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
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `endereco` (
  `id` char(36) NOT NULL,
  `logradouro` varchar(100) NOT NULL,
  `cep` char(9) NOT NULL,
  `cidade` varchar(100) NOT NULL,
  `numero` varchar(10) NOT NULL,
  `estado` char(2) NOT NULL,
  `bairro` varchar(100) NOT NULL,
  `complemento` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endereco`
--

LOCK TABLES `endereco` WRITE;
/*!40000 ALTER TABLE `endereco` DISABLE KEYS */;
INSERT INTO `endereco` VALUES ('05f148c3-09eb-4487-98f3-01a6fd2f34ea','Rua das Acácias','12345-001','São Paulo','101','SP','Jardim Paulista','Apto 11'),('1c36c4db-b8e5-4370-b6c2-46ef1d3d7801','Avenida Brasil','20010-002','Rio de Janeiro','502','RJ','Copacabana','Cobertura'),('328d1c2c-389a-447b-9828-04e98b728227','Rua 24 de Maio','70040-005','Brasília','890','DF','Asa Norte','Bloco C'),('47be403c-cb5a-41fd-8a97-02d6f8b4f020','Avenida Principal','02000-002','Rio de Janeiro','200','RJ','Copacabana',NULL),('4e7278a8-345b-46d6-80fc-8320bc06e60d','Rua do Sol','10000-010','Manaus','1000','AM','Centro',NULL),('5dcf1272-71d6-429b-8c8d-b262abdb2ebc','Avenida Sete','40060-007','Salvador','777','BA','Graça',NULL),('729801e2-06ea-44f7-95a1-ecdc0cce7cd8','Avenida Independência','30150-010','Belo Horizonte','999','MG','Savassi','Apto 204'),('b5b58f93-9e33-44b2-9c8f-f1b6a2d60fa8','Avenida da Liberdade','06000-006','Salvador','600','BA','Barra',NULL),('b60c5d55-0130-4691-b522-9de2a1f8d88a','Alameda Santos','01418-006','São Paulo','315','SP','Jardins','Sala 5'),('ba4e6487-cf85-47a2-8d81-983f0d3c7890','Rua do Comércio','80020-008','Curitiba','25','PR','Centro','Fundos'),('bc63e37e-b0ae-486c-b2e9-186b49ea9baf','Rua do Comércio','05000-005','Porto Alegre','500','RS','Moinhos de Vento','Sala 10'),('c11999f8-0198-4f87-8f61-b2c2ebadff3a','Praça do Carmo','04030-004','Salvador','12','BA','Centro','Loja 2'),('c88a71d7-e8c3-499d-8a84-4f65e7f56c14','Rua da Aurora','50020-003','Recife','77','PE','Boa Vista',NULL),('cfdc4e04-1d24-468b-bf14-7c41ab8cc678','Travessa da Paz','03000-003','Belo Horizonte','300','MG','Savassi','Casa 2'),('d8d9007a-8442-41d1-968a-00a80100ba30','Rua das Flores','01000-001','São Paulo','100','SP','Centro','Apto 1'),('db9912a9-561f-4f0e-839d-012a252a302f','Rua Floriano Peixoto','60060-009','Fortaleza','345','CE','Aldeota','Casa'),('dfe8327e-59e3-4ba6-bd0e-6ca84a69fc8f','Praça da Matriz','07000-007','Fortaleza','700','CE','Aldeota','Loja 5'),('e090ff67-5ef6-4b9f-8f31-b85e89d879d2','Estrada Velha','09000-009','Brasília','900','DF','Asa Sul','Bloco A'),('ebd69371-0a3f-420a-97fd-bc0df89de784','Alameda dos Anjos','04000-004','Curitiba','400','PR','Batel',NULL),('ff982d01-2d08-4848-8bba-8433b76922b7','Rua Nova','08000-008','Recife','800','PE','Boa Viagem',NULL);
/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;
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
