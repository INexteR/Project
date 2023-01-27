CREATE DATABASE  IF NOT EXISTS `travelagency` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `travelagency`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: travelagency
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `IdClient` int NOT NULL AUTO_INCREMENT,
  `FullName` text NOT NULL,
  `BirthDate` date NOT NULL,
  `Phone` varchar(11) NOT NULL,
  PRIMARY KEY (`IdClient`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'Билл Аллан Грин','1998-12-12','83748274623'),(2,'Ден Джефферсон Клинтон','1982-12-09','7402758741'),(3,'Сэм Уолкер Баш','1967-03-23','83510472832'),(4,'Боб Мел Ли','1979-05-12','93678177345');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `IdCity` int NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  PRIMARY KEY (`IdCity`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'Португалия'),(2,'Тайланд'),(3,'Турция'),(4,'Египет'),(5,'Мальдивы'),(6,'Гавайи'),(7,'Мексика');
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `IdEmployee` int NOT NULL AUTO_INCREMENT,
  `FullName` text NOT NULL,
  `Phone` varchar(11) NOT NULL,
  `BirthDate` date NOT NULL,
  `Login` text NOT NULL,
  `Password` text NOT NULL,
  `Status` enum('Работает','Уволен') NOT NULL,
  PRIMARY KEY (`IdEmployee`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Питер Джон Уайт','97492647787','1998-05-05','loginlogin23','passpassword32','Работает'),(2,'Чак Эпл Фостер','88826400900','1976-09-09','logb93r','pn3%%dhs','Работает'),(3,'Джоанна Кэси Смит','92740077835','1997-04-28','dk993bdhs@','///dks32-=','Работает');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `journal`
--

DROP TABLE IF EXISTS `journal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `journal` (
  `IdRecord` int NOT NULL AUTO_INCREMENT,
  `ClientId` int NOT NULL,
  `TourId` int NOT NULL,
  `EmployeeId` int NOT NULL,
  `TourCount` int NOT NULL,
  `StartDate` date NOT NULL,
  PRIMARY KEY (`IdRecord`),
  KEY `ClientId_idx` (`ClientId`),
  KEY `TourId_idx` (`TourId`),
  KEY `EmployeeId_idx` (`EmployeeId`),
  CONSTRAINT `ClientId` FOREIGN KEY (`ClientId`) REFERENCES `client` (`IdClient`),
  CONSTRAINT `EmployeeId` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`IdEmployee`),
  CONSTRAINT `TourId` FOREIGN KEY (`TourId`) REFERENCES `tour` (`IdTour`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `journal`
--

LOCK TABLES `journal` WRITE;
/*!40000 ALTER TABLE `journal` DISABLE KEYS */;
INSERT INTO `journal` VALUES (1,1,2,1,2,'2017-06-01'),(2,2,3,2,1,'2018-07-12'),(3,3,5,1,1,'2018-08-14'),(4,4,2,3,1,'2019-06-07');
/*!40000 ALTER TABLE `journal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log` (
  `IdRecord` int NOT NULL AUTO_INCREMENT,
  `EmployeeFullName` text NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`IdRecord`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (4,'Дейв Страйдер Дэвид','2023-01-22 14:47:28'),(5,'Джек Форд Линкс','2023-01-22 14:49:10'),(6,'Артур Лонг Георг','2023-01-22 14:50:58'),(9,'Джон Скит','2023-01-27 19:31:59');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tour`
--

DROP TABLE IF EXISTS `tour`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tour` (
  `IdTour` int NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `IdCity` int NOT NULL,
  `Duration` tinyint NOT NULL,
  `Cost` bigint NOT NULL,
  PRIMARY KEY (`IdTour`),
  KEY `IdCity_idx` (`IdCity`),
  CONSTRAINT `IdCity` FOREIGN KEY (`IdCity`) REFERENCES `country` (`IdCity`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tour`
--

LOCK TABLES `tour` WRITE;
/*!40000 ALTER TABLE `tour` DISABLE KEYS */;
INSERT INTO `tour` VALUES (1,'Краски мира',2,14,55000),(2,'Кругозор',3,5,30000),(3,'Флай ту флай',4,23,73000),(4,'Лотос',2,4,12000),(5,'Дракон',5,20,65000),(6,'Каньонинг',6,7,20000),(7,'Священный тотем',1,10,39000);
/*!40000 ALTER TABLE `tour` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-27 21:11:54
