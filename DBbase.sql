-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
DROP DATABASE Claustromania;
CREATE DATABASE Claustromania;
USE Claustromania;
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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `migration_id` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `product_version` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`migration_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20250616211238_InitialCreate','8.0.15'),('20250622011359_CorrigirRelacionamentosTransacao','8.0.15');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `caixa` VALUES ('0e456ad3-4b23-4d2a-94b2-f3030793a54b','Caixa Matutino','96306959-ff52-486f-8cb8-83881244421d','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 08:00:00','2025-07-12 12:00:00',500.00,1320.50,35,'Fechado','Fechamento realizado com sucesso. Nenhuma divergência identificada, Apocalipse nuclear.'),('0f12d74e-69a1-4d40-a157-2b0af09af20e','Caixa 6 - U006','add79077-5527-40a4-81c5-14db67e84859','f5fef7c3-7e2c-462d-a0bd-0eeb1be1853b','2024-07-03 09:00:00',NULL,300.00,NULL,8,'Aberto',''),('21bfcb7f-4aeb-4529-b6f7-7574bf0b5759','Caixa Matutino','96306959-ff52-486f-8cb8-83881244421d','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 08:00:00','2025-07-12 12:00:00',500.00,1320.50,35,'Fechado','Fechamento realizado com sucesso. Nenhuma divergência identificada, Apocalipse nuclear.'),('29c7aef6-e39a-403b-9cf5-7dec849e3a2f','Caixa Matutino','96306959-ff52-486f-8cb8-83881244421d','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 08:00:00','2025-07-12 12:00:00',500.00,1320.50,35,'Fechado','Fechamento realizado com sucesso. Nenhuma divergência identificada, Apocalipse nuclear.'),('2d543c21-7fcf-4adb-bb7b-7b68611916b4','Caixa Matutino','96306959-ff52-486f-8cb8-83881244421d','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 08:00:00','2025-07-12 12:00:00',500.00,1320.50,35,'Fechado','Fechamento realizado com sucesso. Nenhuma divergência identificada, Apocalipse nuclear.'),('475e811a-b988-45cc-a6b8-72b8b877d8a5','Caixa 7 - U007','802b5a95-3481-4cea-9c63-8e30d24a405e','9aa87fa5-7a06-4d65-a115-e27d0acf6ea2','2024-07-04 10:00:00','2024-07-04 19:00:00',800.00,1000.00,25,'Fechado',''),('520558a2-f866-4af3-bb69-7b3bd0e610a9','Caixa Matutino','96306959-ff52-486f-8cb8-83881244421d','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 08:00:00','2025-07-12 12:00:00',500.00,1320.50,35,'Fechado','Fechamento realizado com sucesso. Nenhuma divergência identificada, Apocalipse nuclear.'),('592c0681-1d96-492e-bf7f-a31ac396b76a','Caixa 1 - U001','76ae53fc-2d4a-42ac-9c40-630dd7495ef0','f5fef7c3-7e2c-462d-a0bd-0eeb1be1853b','2024-07-01 09:00:00','2024-07-01 18:00:00',1000.00,1500.50,50,'Fechado','Caixa do dia 01/07'),('80c2a6b2-0bc0-44e5-8f4c-626efbca5d35','Caixa Noturno','914c81ad-3e51-4b78-a9f2-8eb90eec8844','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 18:00:00','2025-07-12 23:00:00',750.00,1820.75,42,'Encerrado','Turno tranquilo. Movimento moderado. Nenhuma inconsistência encontrada.'),('820a55e2-256c-4c65-8c43-07eadeb9c649','Caixa 4 - U004','39f7f961-3049-4edf-ad96-93cc1568ffd6','fb3905ec-6b92-4f94-8fa6-90d9794e2c0b','2024-07-02 11:00:00',NULL,200.00,NULL,5,'Aberto',''),('82a7f146-562e-431a-91bc-1ce1d017b828','Caixa 5 - U005','c66d47fa-9384-4e85-823f-488cfe1367a5','d9f73fcc-ffa0-4379-bd0b-a97bb791aabb','2024-07-03 08:00:00','2024-07-03 16:00:00',1200.00,1350.00,40,'Fechado',''),('8dbe6b28-20d2-4a1a-bd19-c8acfeeae156','Caixa Principal','08ddc0d6-dbd0-4238-8162-085fe8377e60','08ddc0d6-dbd0-4036-8caa-4d7b5581149f','2025-07-11 08:00:00','2025-07-11 18:00:00',500.00,1500.00,25,'Fechado','Fechamento realizado sem divergências.'),('95a4817b-7332-4936-8e64-e4fa3a84e190','Caixa 8 - U008','22df9c32-0b24-4595-9508-0f317b528a50','bafe18c7-0d88-4bd0-bdc8-7a5ff13f728d','2024-07-04 11:00:00',NULL,400.00,NULL,12,'Aberto',''),('973938d1-1490-4a01-afeb-5bce507f0cc9','Caixa Noturno','914c81ad-3e51-4b78-a9f2-8eb90eec8844','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 18:00:00','2025-07-12 23:00:00',750.00,1820.75,42,'Encerrado','Turno tranquilo. Movimento moderado. Nenhuma inconsistência encontrada.'),('a91e269b-12e3-4851-ae5d-8ac1fe2bf32c','Caixa Noturno','914c81ad-3e51-4b78-a9f2-8eb90eec8844','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 18:00:00','2025-07-12 23:00:00',750.00,1820.75,42,'Encerrado','Turno tranquilo. Movimento moderado. Nenhuma inconsistência encontrada.'),('ab75c695-5079-48db-865e-b2095f9fbdf7','Caixa 3 - U003','07094ae7-b3cd-4620-a678-aa2d014e3094','bafe18c7-0d88-4bd0-bdc8-7a5ff13f728d','2024-07-02 09:30:00','2024-07-02 17:30:00',750.00,900.25,30,'Fechado',''),('ace9e3ad-a6ea-417b-996b-bde3cd0ae7a4','Caixa 12 - U010','07094ae7-b3cd-4620-a678-aa2d014e3094','dd7d907e-2e0c-4283-a5c8-9661851818a7','2025-07-12 08:30:00','2025-07-12 16:30:00',150.00,1345.75,98,'Fechado','Sem discrepâncias; venda promocional concluída.'),('c4c81ee5-c5c6-4179-b94d-e482a0a1c868','Caixa Principal','08ddc0d5-d453-4d95-8951-f39a1c03ece5','08ddc0d5-d453-4be8-8caa-2de64231e656','2025-07-11 08:00:00','2025-07-11 18:00:00',500.00,1500.00,25,'Fechado','Fechamento realizado sem divergências.'),('d068bef9-adbb-49b2-a548-e16bed5c07c7','Caixa 9 - U009','db584d96-76f9-4dad-9b59-316c47da6cf7','fb3905ec-6b92-4f94-8fa6-90d9794e2c0b','2024-07-05 09:00:00','2024-07-05 17:00:00',900.00,1100.00,35,'Fechado',''),('d57793cc-63cf-4d5c-a82f-c23d88a10d08','Caixa 2 - U002','ce46e340-b144-4942-b9a7-b2b80a18bdc8','9aa87fa5-7a06-4d65-a115-e27d0acf6ea2','2024-07-01 10:00:00',NULL,500.00,NULL,10,'Aberto',''),('da3d9ea4-a50a-4cd2-ac2c-8b60b3341ed3','Caixa 10 - U010','9f1d74a8-69cb-483b-a5f6-646c9e6c832d','d9f73fcc-ffa0-4379-bd0b-a97bb791aabb','2024-07-05 10:00:00',NULL,600.00,NULL,15,'Aberto',''),('e3a8f091-385d-484e-b561-dd7ca7344b5f','Caixa Principal','1e4c837b-14cf-4d8f-bc80-21841127b4a4','0728c020-1828-4ce5-9305-cc16e5fe88ea','2025-07-12 08:00:00','2025-07-12 18:00:00',1000.00,2500.00,42,'Fechado','Caixa fechado com sucesso, sem divergências.');
/*!40000 ALTER TABLE `caixa` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `cliente` VALUES ('030b94b3-355b-4599-8385-dac54a7b21a3','Explorador','1ed7dc33-c86a-4898-b5e5-50f04d4d1df9'),('148f49bd-508c-4aca-a504-66f065d88fb0','Veterano','f1e24097-f69b-49ab-9b63-077315fd9d1f'),('31ded6ab-9cd4-4d60-872d-44b9b02baa1e','Aventureiro','3fe37e18-cc0c-4a2e-9991-1b13b1dd17c6'),('44d91ed6-26b8-408d-9c5b-e662722562dd','Lendário','e1c2fc54-f199-42ca-a88c-7d656a53cd47'),('75225a5c-2e61-454f-82cd-926def203e00','Explorador','4f9473cf-2d77-4a79-b83b-1d1572bb1f21'),('8d5cbad1-48e4-43ba-824c-14b9f7c25a78','Aventureiro','08ddc002-0684-4dc9-8c2f-db7c7216bac2'),('8e1621fe-f03a-4505-a370-099f69b5c9a2','Lendário','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('8f4f1063-8568-4188-ae3e-ab7098a6585a','Explorador','8ff5e380-3d76-4cbe-9deb-0fedb6f20c78'),('97c97006-7e39-426a-b362-07f88856d223','Veterano','20dbb5d9-3a72-4ace-8f00-37d496a62c19'),('d6b05066-19f6-412d-9b84-a3813aacb413','Aventureiro','a6c2a330-b330-4a3b-a8f4-5d445f55ceac'),('dbf10332-2c2f-4cee-ab01-79637bdfd4aa','Aventureiro','a7c8e304-0d56-40a2-91e3-9ea6909118c3'),('ed59f436-c8ca-486a-8f8a-d10e87c0eff3','Explorador','0d84c2cc-bf36-4a95-b80d-b8bdf513e28f'),('f2596d40-6a31-4e80-9cff-0217db5bd029','Veterano','07ca8a69-dcd1-46b3-9bfd-7d664273d27f');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `endereco` VALUES ('05f148c3-09eb-4487-98f3-01a6fd2f34ea','Rua das Acácias','12345-001','São Paulo','101','SP','Jardim Paulista','Apto 11'),('08ddc002-0689-4cc7-86ef-c73f3adee274','Rua das Flores','12345-678','São Paulo','100','SP','Jardins','Apartamento 101'),('08ddc0bd-2bbc-498c-86a9-a0695703354a','Rua das Laranjeiras','04567-000','São Paulo','120A','SP','Jardim Paulista','Bloco B, apto 202'),('08ddc0c0-31f7-4af9-8598-94f7e6074b12','Avenida Atlântica','22010-000','Rio de Janeiro','1234','RJ','Copacabana','Cobertura 01'),('08ddc0c5-1720-49aa-8b01-0f1345545475','Rua das Acácias','04094-050','São Paulo','235','SP','Vila Mariana','Apto 202'),('08ddc0d5-d453-4d24-802b-f06b822d3cae','Rua das Flores','12345-678','São Paulo','123','SP','Jardim Primavera','Apartamento 101'),('08ddc0d6-dbd0-41aa-87fa-c7d2951c389c','Rua das Flores','12345-678','São Paulo','123','SP','Jardim Primavera','Apartamento 101'),('08ddc102-f0bb-4e54-8ab2-08b407122dd2','Rua Galvão Bueno','01506-000','São Paulo','120','SP','Liberdade','Sala 10'),('08ddc111-d265-4a95-83e3-448c6cdd25cb','Rua das Camélias','01455-000','São Paulo','456','SP','Jardins','Apartamento 12B'),('08ddc181-fabf-415d-820a-20521fc24bdc','Av. das Nações Unidas','04578-000','São Paulo','2450','SP','Vila Olímpia','Bloco B, Apto 82'),('1c36c4db-b8e5-4370-b6c2-46ef1d3d7801','Avenida Brasil','20010-002','Rio de Janeiro','502','RJ','Copacabana','Cobertura'),('2d767e42-8281-4197-91af-27c5ad5a94ce','Rua da Unidade Antiga','70000-001','Brasília','10','DF','Setor Central','Prédio Principal'),('328d1c2c-389a-447b-9828-04e98b728227','Rua 24 de Maio','70040-005','Brasília','890','DF','Asa Norte','Bloco C'),('3364bf8a-274f-46b3-b7de-44d351194434','Avenida Paulista','01310-000','São Paulo','1578','SP','Bela Vista','Andar 10'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','aondeCresciEFuiCriado','7962000','Pau-Fincado','666','Ro','Liberal','Casa Muito Engraçada'),('44325f16-b846-46c2-ac34-7e3ed0aee584','Travessa da Guerra','03000-003','Rio De Janeiro','1939','RJ','Botafogo','Favela n°8541'),('47be403c-cb5a-41fd-8a97-02d6f8b4f020','Avenida Principal','02000-002','Rio de Janeiro','200','RJ','Copacabana',NULL),('4e7278a8-345b-46d6-80fc-8320bc06e60d','Rua do Sol','10000-010','Manaus','1000','AM','Centro',NULL),('5dcf1272-71d6-429b-8c8d-b262abdb2ebc','Avenida Sete','40060-007','Salvador','777','BA','Graça',NULL),('67fa379d-90b8-498e-9d01-76c23ca7b39e','Avenida Paulista','01311-200','São Paulo','1500','SP','Bela Vista','10º andar'),('729801e2-06ea-44f7-95a1-ecdc0cce7cd8','Avenida Independência','30150-010','Belo Horizonte','999','MG','Savassi','Apto 204'),('b5b58f93-9e33-44b2-9c8f-f1b6a2d60fa8','Avenida da Liberdade','06000-006','Salvador','600','BA','Barra',NULL),('b60c5d55-0130-4691-b522-9de2a1f8d88a','Alameda Santos','01418-006','São Paulo','315','SP','Jardins','Sala 5'),('ba4e6487-cf85-47a2-8d81-983f0d3c7890','Rua do Comércio','80020-008','Curitiba','25','PR','Centro','Fundos'),('bc63e37e-b0ae-486c-b2e9-186b49ea9baf','Rua do Comércio','05000-005','Porto Alegre','500','RS','Moinhos de Vento','Sala 10'),('c11999f8-0198-4f87-8f61-b2c2ebadff3a','Praça do Carmo','04030-004','Salvador','12','BA','Centro','Loja 2'),('c88a71d7-e8c3-499d-8a84-4f65e7f56c14','Rua da Aurora','50020-003','Recife','77','PE','Boa Vista',NULL),('cfdc4e04-1d24-468b-bf14-7c41ab8cc678','Travessa da Paz','03000-003','Belo Horizonte','300','MG','Savassi','Casa 2'),('d2b2d769-8b9b-4f57-a23d-b56812280670','nasci','0652123','ViusPintus','41','RO','Barro','ao lado do bataclã'),('d8d9007a-8442-41d1-968a-00a80100ba30','Rua das Flores','01000-001','São Paulo','100','SP','Centro','Apto 1'),('db9912a9-561f-4f0e-839d-012a252a302f','Rua Floriano Peixoto','60060-009','Fortaleza','345','CE','Aldeota','Casa'),('dfe8327e-59e3-4ba6-bd0e-6ca84a69fc8f','Praça da Matriz','07000-007','Fortaleza','700','CE','Aldeota','Loja 5'),('e090ff67-5ef6-4b9f-8f31-b85e89d879d2','Estrada Velha','09000-009','Brasília','900','DF','Asa Sul','Bloco A'),('ebd69371-0a3f-420a-97fd-bc0df89de784','Alameda dos Anjos','04000-004','Curitiba','400','PR','Batel',NULL),('fd841f01-bab6-4f16-ac8f-5ed7228ec2da','Rua das Acácias','04567-890','São Paulo','456','SP','Vila Mariana','Casa 02'),('ff982d01-2d08-4848-8bba-8433b76922b7','Rua Nova','08000-008','Recife','800','PE','Boa Viagem',NULL);
/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;
UNLOCK TABLES;

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
  `status` boolean DEFAULT NULL,
  `senha_hash` varchar(255) DEFAULT NULL,
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
INSERT INTO `funcionario` VALUES ('0728c020-1828-4ce5-9305-cc16e5fe88ea','Caixa',2800.00,'2023-06-15','Manhã','73c47a23-3534-4ebf-bffb-ae0bcba30a7b',NULL, NULL),
('08ddc0d5-d453-4be8-8caa-2de64231e656','Caixa',2200.00,'2023-03-01','Manhã','08ddc0d5-d453-4c78-8ec2-eebe8f9a68e0',NULL, NULL),
('08ddc0d6-dbd0-4036-8caa-4d7b5581149f','Caixa',2200.00,'2023-03-01','Manhã','08ddc0d6-dbd0-411c-8a2d-fe1408144443',NULL, NULL),
('08ddc111-d260-4002-818a-3437b3185476','Gerente Geral',7500.00,'2023-02-15','Integral','08ddc111-d263-443d-892c-bf27e292838d',NULL, NULL),
('38b8e7c2-8648-4700-b1c3-c6f48eb53f38','Atendente de Caixa',2500.00,'2024-05-10','Tarde','08ddc0c5-1720-48b4-8958-8c8115410cf8',NULL, null),
('76385048-285c-4b5d-85e9-2e13624b16f7','Atendente',2800.00,'2025-07-11','Tarde','08ddc0bd-2bae-4c19-8808-6ae772e068a5',NULL, NULL),
('9aa87fa5-7a06-4d65-a115-e27d0acf6ea2','Recepcionista',NULL,NULL,NULL,'b48f3787-bef1-455e-9605-61ec3986a359',NULL, NULL),
('ab037fbc-29fa-47ad-a2b5-cdf20d559eb9','Limpeza',NULL,NULL,NULL,'67a612dc-8917-4196-9fe0-5149cef564ed',NULL, NULL),
('bafe18c7-0d88-4bd0-bdc8-7a5ff13f728d','Segurança',NULL,NULL,NULL,'b6b4a6be-61ba-4575-a707-5a70df80bfda',NULL, NULL),
('cc71cc61-b5fe-418e-a4cd-1e8bf5641839','Gerente',NULL,NULL,NULL,'d8d9007a-8442-41d1-968a-00a80100ba30',NULL, NULL),
('d0e58598-01b9-4f95-a137-de856c63440a','Manutenção',NULL,NULL,NULL,'11f17839-cb18-43df-8b93-089dd169d3d0',NULL, NULL),
('d9f73fcc-ffa0-4379-bd0b-a97bb791aabb','Recepcionista',NULL,NULL,NULL,'176704d6-0a6b-43a9-af79-28425634f63c',NULL, NULL),
('dd7d907e-2e0c-4283-a5c8-9661851818a7','Gerente de Operações',5200.00,'2025-07-12','Integral','08ddc181-faba-4ced-879c-1e727b7ba115',NULL, NULL),
('e750adcd-1f7b-4aa5-ac65-b070caaed431','Gerente de Unidade',5200.00,'2023-03-01','Manhã','08ddc0c0-31f2-4b50-8e4a-1b22400d2261',NULL, NULL),
('e7a36ebc-c0d1-4793-b8c3-6932ea98b326','Gerente',NULL,NULL,NULL,'ea707d12-48f3-47a1-b17d-579224d5911f',NULL, NULL),
('f26b5e34-b7ac-4834-acd9-6fc51c4df8b4','Gerente',NULL,NULL,NULL,'d66edf5e-8e93-47f6-8858-f38d77be6b88',NULL, NULL),
('f5fef7c3-7e2c-462d-a0bd-0eeb1be1853b','Atendente',NULL,NULL,NULL,'a47b8caf-bc98-43f0-8a80-2e4aa4848b9f',NULL, NULL),
('fb3905ec-6b92-4f94-8fa6-90d9794e2c0b','Atendente',NULL,NULL,NULL,'91f7b9bb-28c2-4f45-abc9-f6cb14cc5d47',NULL, NULL);
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `pessoa` VALUES ('07ca8a69-dcd1-46b3-9bfd-7d664273d27f','Mariana Ribeiro','333.444.555-66','1999-09-01','Feminino','mariana.ribeiro@email.com',NULL,'729801e2-06ea-44f7-95a1-ecdc0cce7cd8'),
('08ddc002-0684-4dc9-8c2f-db7c7216bac2','Maria Silva','123.456.789-00','1990-05-20','Feminino','maria.silva@example.com',NULL,'08ddc002-0689-4cc7-86ef-c73f3adee274'),
('08ddc0bd-2bae-4c19-8808-6ae772e068a5','Joana Lima','12345678900','1992-03-15','Feminino','joana.lima@email.com',NULL,'08ddc0bd-2bbc-498c-86a9-a0695703354a'),
('08ddc0c0-31f2-4b50-8e4a-1b22400d2261','Mariana Oliveira','98765432100','1987-06-10','Feminino','mariana.oliveira@email.com',NULL,'08ddc0c0-31f7-4af9-8598-94f7e6074b12'),
('08ddc0c5-1720-48b4-8958-8c8115410cf8','Lucas Martins','07111220004','1995-08-15','Masculino','lucas.betinha@email.com','(11)91234-5678','08ddc0c5-1720-49aa-8b01-0f1345545475'),
('08ddc0d5-d453-4c78-8ec2-eebe8f9a68e0','João da Silva','000.446.999-00','1990-05-15','Masculino','joao.silva@email.com','(11) 91234-5678','08ddc0d5-d453-4d24-802b-f06b822d3cae'),
('08ddc0d6-dbd0-411c-8a2d-fe1408144443','João da Silva','000.116.999-00','1990-05-15','Masculino','joao.silveira@email.com','(11) 91234-5678','08ddc0d6-dbd0-41aa-87fa-c7d2951c389c'),
('08ddc102-f0bb-4f33-8a07-36c4020673df','Carlos Andrade','333.116.119-11','1990-03-15','Masculino','carlos.andrade@email.com','(11) 98765-4321','08ddc102-f0bb-4e54-8ab2-08b407122dd2'),
('08ddc111-d263-443d-892c-bf27e292838d','Carlos Henrique da Silva','003.450.709-00','1985-06-10','Masculino','carlos.henrique@empresa.com','(11) 99876-5432','08ddc111-d265-4a95-83e3-448c6cdd25cb'),
('08ddc181-faba-4ced-879c-1e727b7ba115','Ana Beatriz Silva','10305070901','1988-05-14','Feminino','ana.silva@empresa.com','(11)98765-4321','08ddc181-fabf-415d-820a-20521fc24bdc'),
('0d84c2cc-bf36-4a95-b80d-b8bdf513e28f','Nuno Fernandes','444.555.666-77','1994-12-24','Masculino','nuno.fernandes@email.com',NULL,'cfdc4e04-1d24-468b-bf14-7c41ab8cc678'),
('11f17839-cb18-43df-8b93-089dd169d3d0','Hugo Pereira','88888888888','1993-02-14','Masculino','hugo.pereira@email.com',NULL,'e090ff67-5ef6-4b9f-8f31-b85e89d879d2'),
('176704d6-0a6b-43a9-af79-28425634f63c','Julio Santos','10000000000','1991-08-08','Masculino','julio.santos@email.com',NULL,'4e7278a8-345b-46d6-80fc-8320bc06e60d'),
('1ed7dc33-c86a-4898-b5e5-50f04d4d1df9','Tiago Almeida','000.111.222-33','1989-08-16','Masculino','tiago.almeida@email.com',NULL,'ebd69371-0a3f-420a-97fd-bc0df89de784'),
('20dbb5d9-3a72-4ace-8f00-37d496a62c19','abc','923.923.923-09','2015-04-12','Masculino','string',NULL,'d2b2d769-8b9b-4f57-a23d-b56812280670'),(
'3fa85f64-5717-4562-b3fc-2c963f66afa6','Azedo Milho','098.071.232-07','2001-07-09','Feminino','Arrombaste@gostosim.com',NULL,'3fa85f64-5717-4562-b3fc-2c963f66afa6'),
('3fe37e18-cc0c-4a2e-9991-1b13b1dd17c6','Ricardo Silva','888.999.000-11','1996-02-28','Masculino','ricardo.silva@email.com',NULL,'328d1c2c-389a-447b-9828-04e98b728227'),
('49b6f1a3-2834-4a36-bf5e-2ae8064541d5','Imuno Ferrandessu','672.235.146-77','1999-12-20','Masculino','imundinho.ferrados@email.com',NULL,'44325f16-b846-46c2-ac34-7e3ed0aee584'),
('4f9473cf-2d77-4a79-b83b-1d1572bb1f21','Quiteria Rocha','777.888.999-00','1993-11-11','Feminino','quiteria.rocha@email.com',NULL,'ba4e6487-cf85-47a2-8d81-983f0d3c7890'),
('67a612dc-8917-4196-9fe0-5149cef564ed','Gabriela Alves','77777777777','1980-06-25','Feminino','gabriela.alves@email.com',NULL,'bc63e37e-b0ae-486c-b2e9-186b49ea9baf'),
('73c47a23-3534-4ebf-bffb-ae0bcba30a7b','Maria Oliveira','987.654.321-00','1992-04-10','Feminino','maria.oliveira@email.com','(11) 99876-5432','fd841f01-bab6-4f16-ac8f-5ed7228ec2da'),
('8ff5e380-3d76-4cbe-9deb-0fedb6f20c78','Karen Oliveira','111.222.333-44','1998-01-20','Feminino','karen.oliveira@email.com',NULL,'05f148c3-09eb-4487-98f3-01a6fd2f34ea'),
('91f7b9bb-28c2-4f45-abc9-f6cb14cc5d47','Isabela Gomes','99999999999','1987-10-01','Feminino','isabela.gomes@email.com',NULL,'ff982d01-2d08-4848-8bba-8433b76922b7'),
('a47b8caf-bc98-43f0-8a80-2e4aa4848b9f','Bruno Costa','22222222222','1990-07-22','Masculino','bruno.costa@email.com',NULL,'1c36c4db-b8e5-4370-b6c2-46ef1d3d7801'),
('a6c2a330-b330-4a3b-a8f4-5d445f55ceac','Olivia Castro','555.666.777-88','2000-03-03','Feminino','olivia.castro@email.com',NULL,'5dcf1272-71d6-429b-8c8d-b262abdb2ebc'),
('a7c8e304-0d56-40a2-91e3-9ea6909118c3','Lucas Martins','222.333.444-55','1996-05-15','Masculino','lucas.martins@email.com',NULL,'b60c5d55-0130-4691-b522-9de2a1f8d88a'),
('b48f3787-bef1-455e-9605-61ec3986a359','Daniel Lima','44444444444','1995-01-18','Masculino','daniel.lima@email.com',NULL,'ba4e6487-cf85-47a2-8d81-983f0d3c7890'),
('b6b4a6be-61ba-4575-a707-5a70df80bfda','Fernando Rocha','66666666666','1992-04-12','Masculino','fernando.rocha@email.com',NULL,'b60c5d55-0130-4691-b522-9de2a1f8d88a'),
('d66edf5e-8e93-47f6-8858-f38d77be6b88','Eliana Souza','55555555555','1988-09-30','Feminino','eliana.souza@email.com',NULL,'c11999f8-0198-4f87-8f61-b2c2ebadff3a'),
('d8d9007a-8442-41d1-968a-00a80100ba30','Ana Silva','11111111111','1985-03-10','Feminino','ana.silva@email.com',NULL,'d8d9007a-8442-41d1-968a-00a80100ba30'),
('e1c2fc54-f199-42ca-a88c-7d656a53cd47','Sofia Mendes','999.000.111-22','1990-04-04','Feminino','sofia.mendes@email.com',NULL,'db9912a9-561f-4f0e-839d-012a252a302f'),
('ea707d12-48f3-47a1-b17d-579224d5911f','Carla Dias','33333333333','1982-11-05','Feminino','carla.dias@email.com',NULL,'729801e2-06ea-44f7-95a1-ecdc0cce7cd8'),
('f1e24097-f69b-49ab-9b63-077315fd9d1f','Pedro Goncalves','666.777.888-99','1997-07-07','Masculino','pedro.goncalves@email.com',NULL,'b60c5d55-0130-4691-b522-9de2a1f8d88a');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `id` char(36) NOT NULL,
  `data_reserva` date NOT NULL,
  `hora_reserva` time NOT NULL,
  `numero_jogadores` int NOT NULL DEFAULT 1,
  `valor_total` decimal(10,2) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'reservado',
  `observacoes` text,
  `forma_pagamento` varchar(20) NOT NULL,
  `data_criacao` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fk_cliente` char(36) NOT NULL,
  `fk_sala_jogo` char(36) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cliente` (`fk_cliente`),
  KEY `fk_sala_jogo` (`fk_sala_jogo`),
  KEY `idx_data_hora` (`data_reserva`, `hora_reserva`),
  CONSTRAINT `reserva_ibfk_1` FOREIGN KEY (`fk_cliente`) REFERENCES `cliente` (`id`),
  CONSTRAINT `reserva_ibfk_2` FOREIGN KEY (`fk_sala_jogo`) REFERENCES `sala_jogo` (`id`),
  CONSTRAINT `chk_status` CHECK (`status` IN ('reservado', 'confirmado', 'cancelado', 'concluido')),
  CONSTRAINT `chk_forma_pagamento` CHECK (`forma_pagamento` IN ('pix', 'dinheiro', 'cartao')),
  CONSTRAINT `chk_numero_jogadores` CHECK (`numero_jogadores` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `transacao`
--

DROP TABLE IF EXISTS `transacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transacao` (
  `id` char(36) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `data` datetime NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `fk_pessoa` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `fk_caixa` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `fk_reserva` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `forma_pagamento` varchar(50) DEFAULT NULL,
  `pagador` varchar(100) DEFAULT NULL,
  `valor_recebido` decimal(10,2) DEFAULT NULL,
  `troco` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pessoa` (`fk_pessoa`),
  KEY `fk_caixa` (`fk_caixa`),
  KEY `fk_reserva` (`fk_reserva`),
  CONSTRAINT `transacao_ibfk_1` FOREIGN KEY (`fk_pessoa`) REFERENCES `pessoa` (`id`) ON DELETE SET NULL,
  CONSTRAINT `transacao_ibfk_2` FOREIGN KEY (`fk_caixa`) REFERENCES `caixa` (`id`) ON DELETE SET NULL,
  CONSTRAINT `transacao_ibfk_3` FOREIGN KEY (`fk_reserva`) REFERENCES `reserva` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `transacao`
--

LOCK TABLES `transacao` WRITE;
/*!40000 ALTER TABLE `transacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `transacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidade`
--

DESCRIBE transacao;

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
  `cnpj` varchar(20) NOT NULL,
  `diafunci` varchar(255) NOT NULL,
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
INSERT INTO `unidade` VALUES 
('07094ae7-b3cd-4620-a678-aa2d014e3094','Unidade Leste',60,'08:00:00','21:00:00','(31)92345-6789','33.014.556/0001-96','Segunda a Sábado',1,'37cefc53-1898-4603-87ca-944a1f8e1461','f26b5e34-b7ac-4834-acd9-6fc51c4df8b4'),
('08ddc0d5-d453-4d95-8951-f39a1c03ece5','Unidade Centro',100,'08:00:00','18:00:00','(11) 1234-5678','09.546.984/0001-25','Segunda a Sexta',1,NULL,NULL),
('08ddc0d6-dbd0-4238-8162-085fe8377e60','Unidade Centro',100,'08:00:00','18:00:00','(11) 1234-5678','71.223.406/0001-80','Segunda a Sexta',1,NULL,NULL),
('1e4c837b-14cf-4d8f-bc80-21841127b4a4','Unidade Central',150,'08:00:00','20:00:00','(11) 3456-7890','88.947.248/0001-84','Segunda a Domingo',1,NULL,NULL),
('22df9c32-0b24-4595-9508-0f317b528a50','Unidade Nova',50,'10:00:00','23:00:00','(81)97890-1234','45.678.123/0001-90','Terça a Domingo',1,'43ae5fb1-5544-4c9e-9f27-d379c2e36735','e7a36ebc-c0d1-4793-b8c3-6932ea98b326'),
('39f7f961-3049-4edf-ad96-93cc1568ffd6','Unidade Oeste',35,'09:30:00','22:30:00','(41)93456-7890','12.345.678/0001-91','Segunda a Sábado',1,'cf3815b7-8727-45c7-b2a7-962a7f21ad21','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),
('4763072e-f310-48de-b885-0d5a4531ea6a','Unidade Principal',120,'09:00:00','22:00:00','(11) 98765-4321','23.456.789/0001-92','Todos os dias',1,'3364bf8a-274f-46b3-b7de-44d351194434',NULL),
('62ba97ef-ee2f-409f-a809-7a6d128132ad','Unidade Liberdade',100,'08:00:00','18:00:00','(11) 3322-9988','34.567.891/0001-93','Segunda a Sexta',1,'08ddc102-f0bb-4e54-8ab2-08b407122dd2',NULL),
('76ae53fc-2d4a-42ac-9c40-630dd7495ef0','Unidade Centro',50,'09:00:00','22:00:00','(11)98765-4321','45.678.912/0001-94','Segunda a Domingo',1,'8d32289a-293c-4476-94e7-543e1ba4e847','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),
('802b5a95-3481-4cea-9c63-8e30d24a405e','Unidade Central',30,'09:00:00','22:00:00','(85)96789-0123','56.789.123/0001-95','Quarta a Domingo',1,'790e6332-5ee7-4395-aa2e-f83047f26c2d','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),
('81f94d29-cd3b-4276-bbf3-b5584ce29c86','Unidade Central',50,'08:30:00','19:00:00','(11) 91234-5678','67.891.234/0001-96','Segunda a Sexta',0,NULL,NULL),
('914c81ad-3e51-4b78-a9f2-8eb90eec8844','Unidade Moema',85,'10:00:00','20:00:00','(11) 3555-1122','78.912.345/0001-97','Segunda a Sábado',1,NULL,NULL),
('96306959-ff52-486f-8cb8-83881244421d','Unidade Paulista',120,'08:00:00','22:00:00','(11) 3222-4455','89.123.456/0001-98','Todos os dias',1,NULL,NULL),
('98cb7c77-b74e-4d09-8e70-64f1fabd70eb','Unidade Centro',80,'08:00:00','22:00:00','(11) 2345-6789','91.234.567/0001-99','Segunda a Domingo',1,'67fa379d-90b8-498e-9d01-76c23ca7b39e','08ddc111-d260-4002-818a-3437b3185476'),
('9f1d74a8-69cb-483b-a5f6-646c9e6c832d','Unidade Principal',60,'09:30:00','22:30:00','(92)99012-3456','12.345.679/0001-00','Terça a Domingo',1,'97ca4370-9aeb-4ba6-af67-7e9bfee7f182','cc71cc61-b5fe-418e-a4cd-1e8bf5641839'),
('add79077-5527-40a4-81c5-14db67e84859','Unidade Sul',55,'08:30:00','21:30:00','(71)95678-9012','23.456.781/0001-01','Segunda a Sábado',1,'1206851e-394f-4dc1-ada5-97ef8943c30e','f26b5e34-b7ac-4834-acd9-6fc51c4df8b4'),
('c66d47fa-9384-4e85-823f-488cfe1367a5','Unidade Norte',45,'10:30:00','23:30:00','(51)94567-8901','34.567.892/0001-02','Quinta a Domingo',1,'72e85a1b-8404-4354-9ade-b3d74439fb58','e7a36ebc-c0d1-4793-b8c3-6932ea98b326'),
('ce46e340-b144-4942-b9a7-b2b80a18bdc8','Unidade Zona Sul',40,'10:00:00','23:00:00','(21)91234-5678','45.678.913/0001-03','Sexta a Domingo',1,'aae85497-ce90-4a5e-ab99-174c246cdc07','e7a36ebc-c0d1-4793-b8c3-6932ea98b326'),
('db584d96-76f9-4dad-9b59-316c47da6cf7','Unidade Antiga',40,'08:00:00','21:00:00','(61)98901-2345','56.789.124/0001-04','Segunda a Sexta',1,'2d767e42-8281-4197-91af-27c5ad5a94ce',NULL);
/*!40000 ALTER TABLE `unidade` ENABLE KEYS */;
UNLOCK TABLES;
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

-- Dump completed on 2025-07-12 17:18:09
