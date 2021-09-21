ALTER TABLE `buildings`
	ADD COLUMN `BuildingTypeId` INT NULL DEFAULT NULL AFTER `Name`,
	DROP COLUMN `BuildingTypeId`;
CREATE TABLE `buildingtype` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Name` VARCHAR(50) NULL DEFAULT NULL,
	`Description` VARCHAR(50) NULL DEFAULT NULL,
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL DEFAULT NULL,
	`UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	`UpdatedById` INT(11) NULL DEFAULT NULL,
	PRIMARY KEY (`Id`)
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
AUTO_INCREMENT=3
;
