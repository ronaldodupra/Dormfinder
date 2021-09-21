CREATE TABLE `inclusion` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `InclusionName` varchar(255) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `inclusion` */

insert  into `inclusion`(`Id`,`InclusionName`,`CreatedAt`,`UpdatedAt`) values 
(1,'Books','2020-10-09 16:09:00','2020-10-09 16:09:02'),
(2,'Microwave','2020-10-09 16:09:41','2020-10-09 16:09:43'),
(3,'Oven','2020-10-09 16:09:43','2020-10-09 16:09:44');