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
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `id` char(36) NOT NULL,
  `data_reserva` datetime NOT NULL,
  `valor_total` decimal(10,2) NOT NULL,
  `fk_cliente` char(36) NOT NULL,
  `fk_sala_jogo` char(36) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cliente` (`fk_cliente`),
  KEY `fk_sala_jogo` (`fk_sala_jogo`),
  CONSTRAINT `reserva_ibfk_1` FOREIGN KEY (`fk_cliente`) REFERENCES `cliente` (`id`),
  CONSTRAINT `reserva_ibfk_2` FOREIGN KEY (`fk_sala_jogo`) REFERENCES `sala_jogo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
INSERT INTO `reserva` VALUES ('0620b715-0eba-4cf2-b66f-0e0c764fdc55','2024-07-12 09:00:00',90.00,'d6b05066-19f6-412d-9b84-a3813aacb413','5057883e-a784-417d-b3b9-d69c7e3caec4'),('3dda60bd-1cf3-4cf7-8767-8d707edbaa6c','2024-07-13 10:00:00',210.00,'75225a5c-2e61-454f-82cd-926def203e00','0b87ceee-9bd8-435d-9632-e4083f4833f8'),('4126bf2f-facb-4f69-9716-a96649ce844c','2024-07-11 16:00:00',200.00,'ed59f436-c8ca-486a-8f8a-d10e87c0eff3','8fc5f2ef-e485-4a4a-96a6-46c4294f9273'),('48cbd7f7-ed7c-4f22-979d-4b503dc451e5','2024-07-14 11:00:00',170.00,'44d91ed6-26b8-408d-9c5b-e662722562dd','64e845a7-ee65-4dff-aa76-cb91c246e83e'),('5a4c38be-105d-404f-9fa2-e3d70b05d009','2024-07-10 14:00:00',180.00,'dbf10332-2c2f-4cee-ab01-79637bdfd4aa','45ef8415-c45d-4935-9291-6b7dc13add7b'),('723cd0f8-56a7-4789-9fc3-e6fe268d4c4c','2024-07-13 15:00:00',250.00,'31ded6ab-9cd4-4d60-872d-44b9b02baa1e','7137a2db-4112-48db-a3fe-db78a90a922e'),('951eb1de-e387-480e-a7f8-20787a84bd55','2024-07-14 14:00:00',130.00,'030b94b3-355b-4599-8385-dac54a7b21a3','7869772f-4dd0-4b04-80bc-30cd0bc1a6bd'),('be414661-e4d8-48bf-a453-8ae87ba5ab72','2024-07-10 10:00:00',150.00,'8f4f1063-8568-4188-ae3e-ab7098a6585a','7db7cb96-37b2-48b2-bd47-398b6d88216e'),('c570cafa-8129-4015-a207-9835c966eded','2024-07-11 11:00:00',100.00,'f2596d40-6a31-4e80-9cff-0217db5bd029','a20c8118-8661-4a2e-98de-40a3c17ea25f'),('c90ab3c2-0f0e-4fe7-9b6e-a05e2a34282a','2024-07-12 13:00:00',175.00,'148f49bd-508c-4aca-a504-66f065d88fb0','51241b56-aafb-45ce-94ef-bae1ff7762e8');
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-08 20:50:25
