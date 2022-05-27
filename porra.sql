-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: localhost    Database: porra
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.21-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `equip`
--

DROP TABLE IF EXISTS `equip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equip` (
  `IdEquip` int(11) NOT NULL AUTO_INCREMENT,
  `Nom_Equip` varchar(50) NOT NULL,
  `Nom_Camp` varchar(100) NOT NULL,
  `Municipi` varchar(100) NOT NULL,
  `Escut` varchar(100) NOT NULL,
  PRIMARY KEY (`IdEquip`),
  UNIQUE KEY `Nom_Equip` (`Nom_Equip`),
  UNIQUE KEY `Nom_Camp` (`Nom_Camp`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equip`
--

LOCK TABLES `equip` WRITE;
/*!40000 ALTER TABLE `equip` DISABLE KEYS */;
INSERT INTO `equip` VALUES (1,'Girona','Girona','Girona','/Images/EscutGirona.png'),(2,'SD Amorebieta','Camp Municipal de Urritxe','Amorebieta','/Images/EscutSDAmorebieta.png'),(3,'Las Palmas','Gran Canaria','Las Palmas','/Images/EscutLasPalmas.png'),(4,'Ponferradina','El Toralín','Ponferrada','/Images/EscutPonferradina.png'),(5,'Sporting','El Monilón','Gijon','/Images/EscutSporting.png'),(6,'Màlaga','La Rosaleda Stadium','Màlaga','/Images/EscutMalaga.png'),(7,'Real Valldolid','Estadi José Zorrilla','Valladolid','/Images/EscutRealValladolid.png'),(8,'Oviedo','Estadi Carlos Tartiere','Oviedo','/Images/EscutOviedo.png'),(9,'Almeria','Estadi dels Jocs Mediterranis','Almeria','/Images/EscutAlmeria.png'),(10,'Lugo','Estadi Anxo Carro','Lugo','/Images/EscutLugo.png'),(11,'Huesca','Estadi El Alcoraz','Huesca','/Images/EscutHuesca.png'),(12,'Mirandés','Estadi Municipal de Anduva','Miranda de Ebro','/Images/EscutMirandes.png'),(13,'Real Zaragoza','Estadi de La Romareda','Zaragoza','/Images/EscutRealZaragoza.png'),(14,'Fuenlabrada','Estadio Fernando Torres','Fuenlabrada','/Images/EscutFuenLabrada.png'),(15,'Alcorcón','Estadi Santo Domingo','Alcorcón','/Images/EscutAlcorcon.png'),(16,'Reial Sociedad B.','Instalaciones de Zubieta','Sant Sebastià','/Images/EscutReialSocietat.png'),(17,'FC Cartagena','Estadi Cartagonova','Cartagena','/Images/EscutFCCartagena.png'),(18,'Tenerife','Estadi Heliodoro Rodríguez López','Tenerife','/Images/EscutTenerife.png'),(19,'Burgos','Estadi Municipal del Plantío','Burgos','/Images/EscutBurgos.png'),(20,'Leganés','Estadio Municipal Butarque','Leganés','/Images/EscutLeganes.png'),(21,'Eibar','Estadi Municipal de Ipurua','Eibar','/Images/EscutEibar.png'),(22,'UD Ibiza','Estadio Municipal de Can Misses','Ibiza','/Images/EscutUDIbiza.png');
/*!40000 ALTER TABLE `equip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historic`
--

DROP TABLE IF EXISTS `historic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `historic` (
  `IdUsuari` int(11) NOT NULL,
  `Temporada` varchar(25) NOT NULL,
  `PuntuacioTotal` int(11) DEFAULT NULL,
  `Posicio` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdUsuari`,`Temporada`),
  CONSTRAINT `fk1_historic` FOREIGN KEY (`IdUsuari`) REFERENCES `usuari` (`IdUsuari`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historic`
--

LOCK TABLES `historic` WRITE;
/*!40000 ALTER TABLE `historic` DISABLE KEYS */;
INSERT INTO `historic` VALUES (1,'1',24,NULL),(1,'2',33,NULL),(1,'3',18,NULL),(1,'4',35,NULL),(2,'1',24,NULL),(2,'2',33,NULL),(2,'3',18,NULL),(2,'4',35,NULL),(3,'1',24,NULL),(3,'2',33,NULL),(3,'3',18,NULL),(3,'4',35,NULL),(4,'1',24,1),(4,'2',33,2),(4,'3',18,3),(4,'4',35,12);
/*!40000 ALTER TABLE `historic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partit`
--

DROP TABLE IF EXISTS `partit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partit` (
  `Idpartit` int(11) NOT NULL AUTO_INCREMENT,
  `Estat` varchar(25) NOT NULL DEFAULT 'Per Jugar' CHECK (`Estat` in ('Suspes','Acabat','Per Jugar','Ajornat')),
  `Moment` datetime DEFAULT NULL,
  `IdEquipLocal` int(11) NOT NULL,
  `IdEquipVisitant` int(11) NOT NULL,
  `Gols_Local` int(11) DEFAULT NULL CHECK (`Gols_Local` >= 0),
  `Gols_Visitant` int(11) DEFAULT NULL CHECK (`Gols_Visitant` >= 0),
  `Jornada` varchar(50) DEFAULT NULL,
  `Temporada` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`Idpartit`),
  KEY `FK_PARTIT_EQUIP_LOCAL` (`IdEquipLocal`),
  KEY `FK_PARTIT_EQUIP_Visitant` (`IdEquipVisitant`),
  CONSTRAINT `FK_PARTIT_EQUIP_LOCAL` FOREIGN KEY (`IdEquipLocal`) REFERENCES `equip` (`IdEquip`),
  CONSTRAINT `FK_PARTIT_EQUIP_Visitant` FOREIGN KEY (`IdEquipVisitant`) REFERENCES `equip` (`IdEquip`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partit`
--

LOCK TABLES `partit` WRITE;
/*!40000 ALTER TABLE `partit` DISABLE KEYS */;
INSERT INTO `partit` VALUES (1,'Acabat','2022-05-22 17:00:00',1,3,3,2,'Lliga','2021-2022'),(2,'Acabat','2022-05-23 13:00:00',8,9,1,2,'Lliga','2021-2022'),(3,'Acabat','2022-05-24 14:00:00',10,11,5,0,'Lliga','2021-2022'),(4,'Per Jugar','2022-05-25 17:00:00',1,3,0,0,'Lliga','2021-2022'),(5,'Per Jugar','2022-05-27 11:00:00',1,3,0,0,'Lliga','2021-2022');
/*!40000 ALTER TABLE `partit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `porra`
--

DROP TABLE IF EXISTS `porra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `porra` (
  `IdUsuari` int(11) NOT NULL,
  `IdPartit` int(11) NOT NULL,
  `GolsLocal` int(11) DEFAULT NULL CHECK (`GolsLocal` >= 0),
  `GolsVisitant` int(11) DEFAULT NULL CHECK (`GolsLocal` >= 0),
  `DataPorra` datetime DEFAULT NULL,
  `PuntuacioObtinguda` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdUsuari`,`IdPartit`),
  KEY `fk2_porra` (`IdPartit`),
  CONSTRAINT `fk1_porra` FOREIGN KEY (`IdUsuari`) REFERENCES `usuari` (`IdUsuari`),
  CONSTRAINT `fk2_porra` FOREIGN KEY (`IdPartit`) REFERENCES `partit` (`Idpartit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `porra`
--

LOCK TABLES `porra` WRITE;
/*!40000 ALTER TABLE `porra` DISABLE KEYS */;
INSERT INTO `porra` VALUES (1,1,2,16,'2022-05-26 01:35:39',11),(4,2,2,1,'2022-05-25 14:36:58',8),(7,3,5,0,'2022-05-25 14:36:58',10);
/*!40000 ALTER TABLE `porra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `porrista`
--

DROP TABLE IF EXISTS `porrista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `porrista` (
  `idPorrista` int(11) NOT NULL,
  `puntuacio` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPorrista`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `porrista`
--

LOCK TABLES `porrista` WRITE;
/*!40000 ALTER TABLE `porrista` DISABLE KEYS */;
/*!40000 ALTER TABLE `porrista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuari`
--

DROP TABLE IF EXISTS `usuari`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuari` (
  `IdUsuari` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Cognom` varchar(50) NOT NULL,
  `Nif` varchar(10) NOT NULL,
  `Alias` varchar(25) DEFAULT NULL,
  `Rol` varchar(25) NOT NULL DEFAULT 'user' CHECK (`Rol` in ('admin','user')),
  `Contrasenya` varchar(50) DEFAULT NULL,
  `DataAlta` datetime DEFAULT NULL,
  `PuntuacioTotal` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdUsuari`),
  UNIQUE KEY `Nif` (`Nif`),
  UNIQUE KEY `Alias` (`Alias`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuari`
--

LOCK TABLES `usuari` WRITE;
/*!40000 ALTER TABLE `usuari` DISABLE KEYS */;
INSERT INTO `usuari` VALUES (1,'Jordi','Fonts','12345678B','JFonts','user','1234','2022-05-25 14:36:57',12),(2,'Marti','Cespedes','12345678A','MCespedes','user','1234','2022-05-25 14:36:57',0),(3,'Julia','Noia','12345678C','JNoia','user','1234','2022-05-25 14:36:57',24),(4,'Paula','Fernandez','12345678V','PFernandez','user','1234','2022-05-25 14:36:57',0),(5,'Gelsa','Lorenzo','12345678D','GLorenzo','user','1234','2022-05-25 14:36:57',0),(6,'Oriol','Labrat','12345678E','OLabrat','user','1234','2022-05-25 14:36:57',11),(7,'Francesc','Almar','12345678F','FAlmar','user','1234','2022-05-25 14:36:57',0),(8,'Guillem','Vila','41654422K','GVila','admin','1234','2022-05-25 14:36:57',0),(9,'Javier','Sotoca','12345678M','JSotoca','admin','1234','2022-05-25 14:36:57',0),(10,'Luis','Meza','12345678T','LMeza','admin','1234','2022-05-25 14:36:57',0),(11,'Judith','Marti','12345678X','JMarti','user','1234','2022-05-25 14:36:57',0),(13,'Miquel','Perez','1111111B','MPerez','user','1234','2022-05-26 07:43:14',0);
/*!40000 ALTER TABLE `usuari` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'porra'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-26  7:53:18
