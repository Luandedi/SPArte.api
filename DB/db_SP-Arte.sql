CREATE DATABASE  IF NOT EXISTS `sparte` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `sparte`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: dbartesp.mysql.database.azure.com    Database: sparte
-- ------------------------------------------------------
-- Server version	5.6.42.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `controle`
--

DROP TABLE IF EXISTS `controle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `controle` (
  `obra_id` int(11) NOT NULL,
  `exposicao_id` int(11) NOT NULL,
  `capa` varchar(1) DEFAULT 'N',
  PRIMARY KEY (`obra_id`,`exposicao_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `controle`
--

LOCK TABLES `controle` WRITE;
/*!40000 ALTER TABLE `controle` DISABLE KEYS */;
INSERT INTO `controle` VALUES (5,1,'S'),(7,1,'S'),(8,1,'N');
/*!40000 ALTER TABLE `controle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exposicoes`
--

DROP TABLE IF EXISTS `exposicoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `exposicoes` (
  `idexposicao` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `informacoes` varchar(2000) DEFAULT NULL,
  `periodo` varchar(45) DEFAULT NULL,
  `local` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idexposicao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exposicoes`
--

LOCK TABLES `exposicoes` WRITE;
/*!40000 ALTER TABLE `exposicoes` DISABLE KEYS */;
INSERT INTO `exposicoes` VALUES (1,'“Somos”, Bob Wolfenson','Em parceria com o Facebook, a SP-ARTE Digital exibe uma série de fotos assinada por Bob Wolfenson, fotógrafo convidado a desenvolver no Brasil a campanha global “Somos Mais Juntos”. Entre as oito obras reunidas, duas são inéditas, concebidas especialmente para a exposição. Em grandes formatos numa escala que remete ao outdoor e aos estímulos visuais de uma cidade, o conjunto reunido em um espaço expositivo permite que as obras sejam contempladas fora do ritmo acelerado do dia-a-dia das pessoas. Além disso, a potência das fotos de Wolfenson é acompanhada de vídeos inéditos que aprofundam as diferentes narrativas condensadas em sua lente.','10 dezembro de 2019 a 12 janeiro de 2020','Instituto Tomie Ohtake, São Paulo');
/*!40000 ALTER TABLE `exposicoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `obras`
--

DROP TABLE IF EXISTS `obras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `obras` (
  `id` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `autor` varchar(45) DEFAULT NULL,
  `url` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `obras`
--

LOCK TABLES `obras` WRITE;
/*!40000 ALTER TABLE `obras` DISABLE KEYS */;
INSERT INTO `obras` VALUES (1,'Rita Lobo','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/kw56grzwxq_1760px.jpg'),(2,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/8nbw12ertl_1760px.jpg'),(3,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/smxi7wsu91_1760px.jpg'),(4,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/fodsc0vxad_1760px.jpg'),(5,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/teteuc8sy3_1760px.jpg'),(6,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/2wukwlzeme_1760px.jpg'),(7,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/a7szobttv0_1180x550.jpg'),(8,'Sem título','Bob Wolfenson','https://admin.sp-arte.com/uploads/images-resize/dxa_bob_foto_7_1760px.jpg');
/*!40000 ALTER TABLE `obras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'sparte'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-15  5:41:33
