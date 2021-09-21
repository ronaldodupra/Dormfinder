DROP TABLE IF EXISTS `roompic`;

CREATE TABLE `roompic` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoomId` int(11) DEFAULT NULL,
  `FileEntryId` int(11) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Viewable` tinyint(1) DEFAULT NULL,
  `IsThumbnail` tinyint(1) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
