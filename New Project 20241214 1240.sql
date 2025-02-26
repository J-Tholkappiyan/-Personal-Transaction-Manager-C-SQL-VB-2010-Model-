-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.34


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema per_tran
--

CREATE DATABASE IF NOT EXISTS per_tran;
USE per_tran;

--
-- Definition of table `c_reg`
--

DROP TABLE IF EXISTS `c_reg`;
CREATE TABLE `c_reg` (
  `eid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(105) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `fdt` varchar(105) DEFAULT NULL,
  `c_name` varchar(205) DEFAULT NULL,
  `cid` varchar(95) DEFAULT NULL,
  `cno` varchar(95) DEFAULT NULL,
  `emailid` varchar(155) DEFAULT NULL,
  `r_date` date DEFAULT NULL,
  PRIMARY KEY (`eid`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `c_reg`
--

/*!40000 ALTER TABLE `c_reg` DISABLE KEYS */;
INSERT INTO `c_reg` (`eid`,`username`,`status`,`fdt`,`c_name`,`cid`,`cno`,`emailid`,`r_date`) VALUES 
 (1,'god','a','55','aa','11','11','11','2024-12-05'),
 (2,NULL,NULL,NULL,'kishore','110','122','sldfkj',NULL),
 (3,'admin','a','05/12/2024 12:10:43 PM','yyy','555','66666','yy','2024-12-05'),
 (4,'admin','a','05/12/2024 12:13:09 PM','hh','666','hh','hh','2024-12-06'),
 (5,'admin','a','05/12/2024 12:30:21 PM','hhh','5','hh','hh','2024-12-05'),
 (6,'admin','a','05/12/2024 12:32:37 PM','yy','6','yy','yy','2024-12-05'),
 (7,'admin','a','05/12/2024 12:33:18 PM','uu','7','uu','uu','2024-12-05');
/*!40000 ALTER TABLE `c_reg` ENABLE KEYS */;


--
-- Definition of table `payment`
--

DROP TABLE IF EXISTS `payment`;
CREATE TABLE `payment` (
  `eid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `c_date` date DEFAULT NULL,
  `t_mode` varchar(45) DEFAULT NULL,
  `c_name` varchar(150) DEFAULT NULL,
  `c_id` varchar(45) DEFAULT NULL,
  `amt` varchar(45) DEFAULT NULL,
  `p_mode` varchar(45) DEFAULT NULL,
  `ack_no` varchar(45) DEFAULT NULL,
  `remark` varchar(45) DEFAULT NULL,
  `fdt` varchar(150) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `t_id` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`eid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payment`
--

/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` (`eid`,`c_date`,`t_mode`,`c_name`,`c_id`,`amt`,`p_mode`,`ack_no`,`remark`,`fdt`,`username`,`status`,`t_id`) VALUES 
 (1,'2024-12-10','DEBIT','aa','11','9000','CREDIT','iu899','gfhh','10/12/2024 4:48:36 PM','admin','a','1'),
 (2,'2024-12-14','CREDIT','hhh','5','666','CREDIT','777','77','14/12/2024 11:43:56 AM','admin','a','2'),
 (3,'2024-12-14','CREDIT','yyy','555','777','CREDIT','hhh','hhgjh','14/12/2024 11:59:32 AM','admin','a','3');
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
