DROP TABLE IF EXISTS `roombedspacetype`;

CREATE TABLE `roombedspacetype` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `roomTypeId` int(11) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `roombedspacetype` */

insert  into `roombedspacetype`(`Id`,`roomTypeId`,`Description`) values 
(1,1,'BedSpace A'),
(2,2,'BedSpace A(Upper Bunk)'),
(3,2,'BedSpace B(LowerBunk)'),
(4,3,'BedSpace A'),
(5,3,'BedSpace B'),
(6,3,'BedSpace C'),
(7,4,'BedSpace A(Upper Bunk)'),
(8,4,'BedSpace B(LowerBunk)'),
(9,4,'BedSpace C(Upper Bunk)'),
(10,4,'BedSpace D(LowerBunk)');