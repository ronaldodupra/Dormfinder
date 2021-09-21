
/*Table structure for table `rooms` */

DROP TABLE IF EXISTS `rooms`;

CREATE TABLE `rooms` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoomName` varchar(50) DEFAULT NULL,
  `Area` decimal(10,2) DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  `BedspaceIds` int(11) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `IsActive` tinyint(1) DEFAULT NULL,
  `BuildingId` int(11) DEFAULT NULL,
  `RoomNumber` varchar(50) DEFAULT NULL,
  `Price` decimal(10,2) DEFAULT 0.00,
  `WaterMeterNumber` varchar(50) DEFAULT NULL,
  `ElectricMeterNumber` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `BedspaceIds` (`BedspaceIds`)
) ENGINE=InnoDB AUTO_INCREMENT=84 DEFAULT CHARSET=latin1;

