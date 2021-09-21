/*Table structure for table `roominclusion` */

DROP TABLE IF EXISTS `roominclusion`;

CREATE TABLE `roominclusion` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoomId` int(11) DEFAULT NULL,
  `InclusionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=272 DEFAULT CHARSET=latin1;