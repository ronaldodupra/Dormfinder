/*Table structure for table `bedspace` */

DROP TABLE IF EXISTS `bedspace`;

CREATE TABLE `bedspace` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(200) DEFAULT NULL,
  `IsOccupied` tinyint(1) DEFAULT NULL,
  `CreatedAt` timestamp NULL DEFAULT current_timestamp(),
  `UpdatedAt` timestamp NULL DEFAULT current_timestamp(),
  `IsActive` tinyint(1) DEFAULT NULL,
  `RoomId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=180 DEFAULT CHARSET=latin1;