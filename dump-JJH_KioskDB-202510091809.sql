-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 192.168.0.12    Database: JJH_KioskDB
-- ------------------------------------------------------
-- Server version	5.5.5-10.11.6-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Kiosk_Account`
--

DROP TABLE IF EXISTS `Kiosk_Account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_Account` (
  `UserID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `CreatedAt` datetime DEFAULT current_timestamp(),
  `StoreID` int(10) unsigned DEFAULT NULL,
  `Salt` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Kiosk_Account_UNIQUE` (`UserName`),
  KEY `Kiosk_Account_Kiosk_StoreList_FK` (`StoreID`),
  CONSTRAINT `Kiosk_Account_Kiosk_StoreList_FK` FOREIGN KEY (`StoreID`) REFERENCES `Kiosk_StoreList` (`StoreID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_Account`
--

LOCK TABLES `Kiosk_Account` WRITE;
/*!40000 ALTER TABLE `Kiosk_Account` DISABLE KEYS */;
INSERT INTO `Kiosk_Account` VALUES (1,'jjhadmin','$2a$11$luQuQnfgiEbDXy8Zzp88AucL1ArTA252C6emLVudkjxACnQsMp9IW','2024-10-12 22:49:16',1,NULL),(2,'guest','$2a$11$umKXxtoA5gxcqcsDeW5LYesmtlK3XY5qRxJFD5CYh9MBVBrz0Iexm','2025-10-09 17:57:42',1,NULL);
/*!40000 ALTER TABLE `Kiosk_Account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_List`
--

DROP TABLE IF EXISTS `Kiosk_List`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_List` (
  `KioskID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `KioskName` varchar(20) DEFAULT NULL,
  `InstallDate` datetime DEFAULT current_timestamp(),
  `StoreID` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`KioskID`),
  KEY `Kiosk_List_Kiosk_StoreList_FK` (`StoreID`),
  CONSTRAINT `Kiosk_List_Kiosk_StoreList_FK` FOREIGN KEY (`StoreID`) REFERENCES `Kiosk_StoreList` (`StoreID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_List`
--

LOCK TABLES `Kiosk_List` WRITE;
/*!40000 ALTER TABLE `Kiosk_List` DISABLE KEYS */;
/*!40000 ALTER TABLE `Kiosk_List` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuCategory`
--

DROP TABLE IF EXISTS `Kiosk_MenuCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuCategory` (
  `MenuCategoryID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `MenuCategoryName` varchar(20) DEFAULT NULL,
  `StoreID` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`MenuCategoryID`),
  KEY `Kiosk_MenuCategory_Kiosk_StoreList_FK` (`StoreID`),
  CONSTRAINT `Kiosk_MenuCategory_Kiosk_StoreList_FK` FOREIGN KEY (`StoreID`) REFERENCES `Kiosk_StoreList` (`StoreID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuCategory`
--

LOCK TABLES `Kiosk_MenuCategory` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuCategory` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuCategory` VALUES (1,'아메리카노',1),(2,'라떼',1),(3,'티',1),(4,'디저트',1),(5,'브랜드 음료',1),(6,'스무디',1),(7,'기타',1);
/*!40000 ALTER TABLE `Kiosk_MenuCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuList`
--

DROP TABLE IF EXISTS `Kiosk_MenuList`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuList` (
  `MenuID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(50) NOT NULL,
  `Price` int(10) unsigned NOT NULL,
  `MenuTypeID` int(10) unsigned DEFAULT NULL,
  `ImagePath` varchar(100) DEFAULT NULL,
  `MenuCategoryID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`MenuID`),
  KEY `Kiosk_MenuList_Kiosk_MenuType_FK` (`MenuTypeID`),
  KEY `Kiosk_MenuList_Kiosk_MenuCategory_FK` (`MenuCategoryID`),
  CONSTRAINT `Kiosk_MenuList_Kiosk_MenuCategory_FK` FOREIGN KEY (`MenuCategoryID`) REFERENCES `Kiosk_MenuCategory` (`MenuCategoryID`),
  CONSTRAINT `Kiosk_MenuList_Kiosk_MenuType_FK` FOREIGN KEY (`MenuTypeID`) REFERENCES `Kiosk_MenuType` (`MenuTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuList`
--

LOCK TABLES `Kiosk_MenuList` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuList` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuList` VALUES (1,'아메리카노',2500,1,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/americano.jpg',1),(2,'카페라떼',4000,2,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/아이스-카페라떼.jpg',2),(3,'오트라떼',5500,2,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/바닐라빈-오트-라떼.jpg',2),(4,'설향딸기라떼',6000,2,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/설향딸기-라떼.jpg',2),(5,'카라멜마끼아또',4500,1,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/마키아토네.jpg',1),(6,'마끼아또더블',5000,1,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/마이카토더블.jpg',1),(7,'스파클링망고',5000,5,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/스파클링망고.jpg',6),(8,'파미그래네이트 블루베리',5000,4,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/파미그래네이트-블루베리_1_1_1.jpg',3),(9,'트리플초코머핀',4000,3,'pack://application:,,,/JjhKiosk.Resource;component/MenuImages/트리플초코머핀_수정_1.jpg',4);
/*!40000 ALTER TABLE `Kiosk_MenuList` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuOptionGroup`
--

DROP TABLE IF EXISTS `Kiosk_MenuOptionGroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuOptionGroup` (
  `OptionGroupID` int(10) unsigned NOT NULL,
  `OptionGroupName` varchar(50) DEFAULT NULL,
  `MenuTypeID` int(10) unsigned DEFAULT NULL,
  `OptionTypeID` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`OptionGroupID`),
  KEY `Kiosk_MenuOptionGroup_Kiosk_MenuType_FK` (`MenuTypeID`),
  KEY `Kiosk_MenuOptionGroup_Kiosk_MenuOptionType_FK` (`OptionTypeID`),
  CONSTRAINT `Kiosk_MenuOptionGroup_Kiosk_MenuOptionType_FK` FOREIGN KEY (`OptionTypeID`) REFERENCES `Kiosk_MenuOptionType` (`OptionTypeID`),
  CONSTRAINT `Kiosk_MenuOptionGroup_Kiosk_MenuType_FK` FOREIGN KEY (`MenuTypeID`) REFERENCES `Kiosk_MenuType` (`MenuTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuOptionGroup`
--

LOCK TABLES `Kiosk_MenuOptionGroup` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuOptionGroup` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuOptionGroup` VALUES (1,'HOT/ICE',1,3),(2,'시럽추가',1,1),(3,'HOT/ICE',2,3),(4,'설탕추가',1,1),(5,'우유변경',2,1),(6,'시럽추가',2,1),(7,'설탕추가',2,1),(8,'HOT/ICE',4,3),(9,'설탕추가',4,1),(10,'설탕추가',5,1);
/*!40000 ALTER TABLE `Kiosk_MenuOptionGroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuOptionLinker`
--

DROP TABLE IF EXISTS `Kiosk_MenuOptionLinker`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuOptionLinker` (
  `LinkerId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OptionGroupID` int(10) unsigned DEFAULT NULL,
  `OptionMemberID` int(10) unsigned DEFAULT NULL,
  `OptionTypeID` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`LinkerId`),
  KEY `KioskMenuOptionLinker_Kiosk_MenuOptionGroup_FK` (`OptionGroupID`),
  KEY `KioskMenuOptionLinker_Kiosk_MenuOptionMember_FK` (`OptionMemberID`),
  KEY `KioskMenuOptionLinker_Kiosk_MenuOptionType_FK` (`OptionTypeID`),
  CONSTRAINT `KioskMenuOptionLinker_Kiosk_MenuOptionGroup_FK` FOREIGN KEY (`OptionGroupID`) REFERENCES `Kiosk_MenuOptionGroup` (`OptionGroupID`),
  CONSTRAINT `KioskMenuOptionLinker_Kiosk_MenuOptionMember_FK` FOREIGN KEY (`OptionMemberID`) REFERENCES `Kiosk_MenuOptionMember` (`OptionMemberID`),
  CONSTRAINT `KioskMenuOptionLinker_Kiosk_MenuOptionType_FK` FOREIGN KEY (`OptionTypeID`) REFERENCES `Kiosk_MenuOptionType` (`OptionTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuOptionLinker`
--

LOCK TABLES `Kiosk_MenuOptionLinker` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuOptionLinker` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuOptionLinker` VALUES (1,1,2,3),(2,1,1,3),(3,2,5,1),(4,2,6,1),(5,2,7,1),(6,4,4,1),(7,4,3,1),(8,3,2,3),(9,3,1,3),(10,5,9,3),(11,5,10,3),(12,6,5,1),(13,6,6,1),(14,6,7,1),(15,7,3,1),(16,7,4,1),(17,8,3,1),(18,8,4,1);
/*!40000 ALTER TABLE `Kiosk_MenuOptionLinker` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuOptionMember`
--

DROP TABLE IF EXISTS `Kiosk_MenuOptionMember`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuOptionMember` (
  `OptionMemberID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OptionMemberName` varchar(20) DEFAULT NULL,
  `OptionMemberPrice` int(10) unsigned NOT NULL,
  PRIMARY KEY (`OptionMemberID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuOptionMember`
--

LOCK TABLES `Kiosk_MenuOptionMember` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuOptionMember` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuOptionMember` VALUES (1,'ICE',500),(2,'HOT',0),(3,'설탕',300),(4,'스테비아',500),(5,'헤이즐넛 시럽',500),(6,'바닐라 시럽',500),(7,'저당 바닐라 시럽',1000),(8,'없음',0),(9,'저지방우유',500),(10,'고칼슘우유',500);
/*!40000 ALTER TABLE `Kiosk_MenuOptionMember` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuOptionType`
--

DROP TABLE IF EXISTS `Kiosk_MenuOptionType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuOptionType` (
  `OptionTypeID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OptionTypeName` varchar(20) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`OptionTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuOptionType`
--

LOCK TABLES `Kiosk_MenuOptionType` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuOptionType` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuOptionType` VALUES (1,'단일 선택 옵션','최대 1개만 선택이 가능한 옵션'),(2,'다수 선택 옵션','다수를 1개만 선택 가능한 옵션'),(3,'필수 단일 선택 옵션','무조건 1개 선택해야하는 옵션'),(4,'중복 다수 선택 옵션','다수를 여러개 선택 가능한 옵션');
/*!40000 ALTER TABLE `Kiosk_MenuOptionType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_MenuType`
--

DROP TABLE IF EXISTS `Kiosk_MenuType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_MenuType` (
  `MenuTypeID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `MenuTypeName` varchar(20) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MenuTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_MenuType`
--

LOCK TABLES `Kiosk_MenuType` WRITE;
/*!40000 ALTER TABLE `Kiosk_MenuType` DISABLE KEYS */;
INSERT INTO `Kiosk_MenuType` VALUES (1,'일반커피','아메리카노 등등의 일반커피'),(2,'라떼','카페라떼 등 우유첨가 커피'),(3,'디저트 빵류','허니브레드 등의 빵류'),(4,'허브티','허브류의 티'),(5,'스무디','차가운 얼음 음료');
/*!40000 ALTER TABLE `Kiosk_MenuType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_Order`
--

DROP TABLE IF EXISTS `Kiosk_Order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_Order` (
  `OrderID` varchar(23) NOT NULL,
  `FullPrice` int(10) unsigned DEFAULT NULL,
  `OrderDate` datetime NOT NULL DEFAULT current_timestamp(),
  `StatusTypeID` tinyint(3) unsigned DEFAULT NULL,
  `StoreID` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `Kiosk_Order_Kiosk_OrderStatusType_FK` (`StatusTypeID`),
  KEY `Kiosk_Order_Kiosk_StoreList_FK` (`StoreID`),
  CONSTRAINT `Kiosk_Order_Kiosk_OrderStatusType_FK` FOREIGN KEY (`StatusTypeID`) REFERENCES `Kiosk_OrderStatusType` (`StatusTypeID`) ON UPDATE CASCADE,
  CONSTRAINT `Kiosk_Order_Kiosk_StoreList_FK` FOREIGN KEY (`StoreID`) REFERENCES `Kiosk_StoreList` (`StoreID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_Order`
--

LOCK TABLES `Kiosk_Order` WRITE;
/*!40000 ALTER TABLE `Kiosk_Order` DISABLE KEYS */;
/*!40000 ALTER TABLE `Kiosk_Order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_OrderCart`
--

DROP TABLE IF EXISTS `Kiosk_OrderCart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_OrderCart` (
  `MenuOrder` tinyint(3) unsigned NOT NULL,
  `OrderID` varchar(23) NOT NULL,
  `MenuID` int(10) unsigned DEFAULT NULL,
  `Qty` smallint(5) unsigned NOT NULL,
  PRIMARY KEY (`MenuOrder`,`OrderID`),
  KEY `Kiosk_OrderCart_Kiosk_Order_FK` (`OrderID`),
  KEY `Kiosk_OrderCart_Kiosk_MenuList_FK` (`MenuID`),
  CONSTRAINT `Kiosk_OrderCart_Kiosk_MenuList_FK` FOREIGN KEY (`MenuID`) REFERENCES `Kiosk_MenuList` (`MenuID`),
  CONSTRAINT `Kiosk_OrderCart_Kiosk_Order_FK` FOREIGN KEY (`OrderID`) REFERENCES `Kiosk_Order` (`OrderID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_OrderCart`
--

LOCK TABLES `Kiosk_OrderCart` WRITE;
/*!40000 ALTER TABLE `Kiosk_OrderCart` DISABLE KEYS */;
/*!40000 ALTER TABLE `Kiosk_OrderCart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_OrderLog`
--

DROP TABLE IF EXISTS `Kiosk_OrderLog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_OrderLog` (
  `OrderDate` datetime NOT NULL,
  `FullPrice` int(11) DEFAULT NULL,
  `StoreID` int(10) unsigned DEFAULT NULL,
  `MenuDescription` varchar(200) DEFAULT NULL,
  `StatusTypeID` tinyint(3) unsigned DEFAULT NULL,
  `OrderID` varchar(23) DEFAULT NULL,
  KEY `Kiosk_OrderLog_Kiosk_OrderStatusType_FK` (`StatusTypeID`),
  KEY `Kiosk_OrderLog_Kiosk_Order_FK` (`OrderID`),
  CONSTRAINT `Kiosk_OrderLog_Kiosk_OrderStatusType_FK` FOREIGN KEY (`StatusTypeID`) REFERENCES `Kiosk_OrderStatusType` (`StatusTypeID`),
  CONSTRAINT `Kiosk_OrderLog_Kiosk_Order_FK` FOREIGN KEY (`OrderID`) REFERENCES `Kiosk_Order` (`OrderID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_OrderLog`
--

LOCK TABLES `Kiosk_OrderLog` WRITE;
/*!40000 ALTER TABLE `Kiosk_OrderLog` DISABLE KEYS */;
/*!40000 ALTER TABLE `Kiosk_OrderLog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_OrderStatusType`
--

DROP TABLE IF EXISTS `Kiosk_OrderStatusType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_OrderStatusType` (
  `StatusTypeID` tinyint(3) unsigned NOT NULL,
  `StatusTypeName` varchar(20) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`StatusTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_OrderStatusType`
--

LOCK TABLES `Kiosk_OrderStatusType` WRITE;
/*!40000 ALTER TABLE `Kiosk_OrderStatusType` DISABLE KEYS */;
INSERT INTO `Kiosk_OrderStatusType` VALUES (1,'주문대기중',NULL),(2,'조리중',NULL),(3,'배달중',NULL),(4,'최종완료',NULL);
/*!40000 ALTER TABLE `Kiosk_OrderStatusType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_StoreList`
--

DROP TABLE IF EXISTS `Kiosk_StoreList`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_StoreList` (
  `StoreID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `StoreName` varchar(20) NOT NULL,
  `TelNumber` varchar(18) DEFAULT NULL,
  `RegiDate` datetime DEFAULT current_timestamp(),
  `StoreTypeNumber` tinyint(4) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Owner` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`StoreID`),
  KEY `Kiosk_StoreList_Kiosk_StoreType_FK` (`StoreTypeNumber`),
  CONSTRAINT `Kiosk_StoreList_Kiosk_StoreType_FK` FOREIGN KEY (`StoreTypeNumber`) REFERENCES `Kiosk_StoreType` (`StoreTypeNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_StoreList`
--

LOCK TABLES `Kiosk_StoreList` WRITE;
/*!40000 ALTER TABLE `Kiosk_StoreList` DISABLE KEYS */;
INSERT INTO `Kiosk_StoreList` VALUES (1,'JH카페','010-1234-4567','2024-09-25 00:10:39',1,'','정주형');
/*!40000 ALTER TABLE `Kiosk_StoreList` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kiosk_StoreType`
--

DROP TABLE IF EXISTS `Kiosk_StoreType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kiosk_StoreType` (
  `StoreTypeNumber` tinyint(4) NOT NULL AUTO_INCREMENT,
  `StoreTypeName` varchar(20) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`StoreTypeNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kiosk_StoreType`
--

LOCK TABLES `Kiosk_StoreType` WRITE;
/*!40000 ALTER TABLE `Kiosk_StoreType` DISABLE KEYS */;
INSERT INTO `Kiosk_StoreType` VALUES (1,'커피숍','일반커피숍'),(2,'도매업소','일반도매업');
/*!40000 ALTER TABLE `Kiosk_StoreType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'JJH_KioskDB'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-09 18:09:34
