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
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `id` char(36) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `CPF` varchar(14) NOT NULL,
  `data_nascimento` date DEFAULT NULL,
  `sexo` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `fk_endereco` char(36) DEFAULT NULL,
  `senha_hash` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cpf` (`CPF`),
  UNIQUE KEY `email` (`email`),
  KEY `fk_endereco` (`fk_endereco`),
  CONSTRAINT `pessoa_ibfk_1` FOREIGN KEY (`fk_endereco`) REFERENCES `endereco` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES ('07ca8a69-dcd1-46b3-9bfd-7d664273d27f','Mariana Ribeiro','333.444.555-66','1999-09-01','Feminino','mariana.ribeiro@email.com',NULL,'729801e2-06ea-44f7-95a1-ecdc0cce7cd8',NULL),('0d84c2cc-bf36-4a95-b80d-b8bdf513e28f','Nuno Fernandes','444.555.666-77','1994-12-24','Masculino','nuno.fernandes@email.com',NULL,'cfdc4e04-1d24-468b-bf14-7c41ab8cc678',NULL),('11f17839-cb18-43df-8b93-089dd169d3d0','Hugo Pereira','88888888888','1993-02-14','Masculino','hugo.pereira@email.com',NULL,'e090ff67-5ef6-4b9f-8f31-b85e89d879d2',NULL),('176704d6-0a6b-43a9-af79-28425634f63c','Julio Santos','10000000000','1991-08-08','Masculino','julio.santos@email.com',NULL,'4e7278a8-345b-46d6-80fc-8320bc06e60d',NULL),('1ed7dc33-c86a-4898-b5e5-50f04d4d1df9','Tiago Almeida','000.111.222-33','1989-08-16','Masculino','tiago.almeida@email.com',NULL,'ebd69371-0a3f-420a-97fd-bc0df89de784',NULL),('3fe37e18-cc0c-4a2e-9991-1b13b1dd17c6','Ricardo Silva','888.999.000-11','1996-02-28','Masculino','ricardo.silva@email.com',NULL,'328d1c2c-389a-447b-9828-04e98b728227',NULL),('4f9473cf-2d77-4a79-b83b-1d1572bb1f21','Quiteria Rocha','777.888.999-00','1993-11-11','Feminino','quiteria.rocha@email.com',NULL,'ba4e6487-cf85-47a2-8d81-983f0d3c7890',NULL),('67a612dc-8917-4196-9fe0-5149cef564ed','Gabriela Alves','77777777777','1980-06-25','Feminino','gabriela.alves@email.com',NULL,'bc63e37e-b0ae-486c-b2e9-186b49ea9baf',NULL),('8ff5e380-3d76-4cbe-9deb-0fedb6f20c78','Karen Oliveira','111.222.333-44','1998-01-20','Feminino','karen.oliveira@email.com',NULL,'05f148c3-09eb-4487-98f3-01a6fd2f34ea',NULL),('91f7b9bb-28c2-4f45-abc9-f6cb14cc5d47','Isabela Gomes','99999999999','1987-10-01','Feminino','isabela.gomes@email.com',NULL,'ff982d01-2d08-4848-8bba-8433b76922b7',NULL),('a47b8caf-bc98-43f0-8a80-2e4aa4848b9f','Bruno Costa','22222222222','1990-07-22','Masculino','bruno.costa@email.com',NULL,'1c36c4db-b8e5-4370-b6c2-46ef1d3d7801',NULL),('a6c2a330-b330-4a3b-a8f4-5d445f55ceac','Olivia Castro','555.666.777-88','2000-03-03','Feminino','olivia.castro@email.com',NULL,'5dcf1272-71d6-429b-8c8d-b262abdb2ebc',NULL),('a7c8e304-0d56-40a2-91e3-9ea6909118c3','Lucas Martins','222.333.444-55','1996-05-15','Masculino','lucas.martins@email.com',NULL,'b60c5d55-0130-4691-b522-9de2a1f8d88a',NULL),('b48f3787-bef1-455e-9605-61ec3986a359','Daniel Lima','44444444444','1995-01-18','Masculino','daniel.lima@email.com',NULL,'ba4e6487-cf85-47a2-8d81-983f0d3c7890',NULL),('b6b4a6be-61ba-4575-a707-5a70df80bfda','Fernando Rocha','66666666666','1992-04-12','Masculino','fernando.rocha@email.com',NULL,'b60c5d55-0130-4691-b522-9de2a1f8d88a',NULL),('d66edf5e-8e93-47f6-8858-f38d77be6b88','Eliana Souza','55555555555','1988-09-30','Feminino','eliana.souza@email.com',NULL,'c11999f8-0198-4f87-8f61-b2c2ebadff3a',NULL),('d8d9007a-8442-41d1-968a-00a80100ba30','Ana Silva','11111111111','1985-03-10','Feminino','ana.silva@email.com',NULL,'d8d9007a-8442-41d1-968a-00a80100ba30',NULL),('e1c2fc54-f199-42ca-a88c-7d656a53cd47','Sofia Mendes','999.000.111-22','1990-04-04','Feminino','sofia.mendes@email.com',NULL,'db9912a9-561f-4f0e-839d-012a252a302f','pessoa1'),('ea707d12-48f3-47a1-b17d-579224d5911f','Carla Dias','33333333333','1982-11-05','Feminino','carla.dias@email.com',NULL,'729801e2-06ea-44f7-95a1-ecdc0cce7cd8',NULL),('f1e24097-f69b-49ab-9b63-077315fd9d1f','Pedro Goncalves','666.777.888-99','1997-07-07','Masculino','pedro.goncalves@email.com',NULL,'b60c5d55-0130-4691-b522-9de2a1f8d88a',NULL);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
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
