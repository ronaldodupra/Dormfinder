




DROP TABLE IF EXISTS `roomtype`;

CREATE TABLE `roomtype` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoomTypeName` varchar(50) DEFAULT NULL,
  `Price` double(10,2) DEFAULT 0.00,
  `AllowedPerson` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `roomtype` */

insert  into `roomtype`(`Id`,`RoomTypeName`,`Price`,`AllowedPerson`) values 
(1,'1 Bed Room',5000.00,1),
(2,'2 Bed Room',1000.00,2),
(3,'3 Bed Room',200.00,3),
(4,'4 Bed Room',500.00,4);