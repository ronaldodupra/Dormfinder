

DROP TABLE IF EXISTS `roompic`;

CREATE TABLE `roompic` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoomId` int(11) DEFAULT NULL,
  `FileName` varchar(100) DEFAULT NULL,
  `FileType` varchar(50) DEFAULT NULL,
  `FilePath` varchar(255) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Viewable` enum('Y','N') DEFAULT NULL,
  `IsThumbnail` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;