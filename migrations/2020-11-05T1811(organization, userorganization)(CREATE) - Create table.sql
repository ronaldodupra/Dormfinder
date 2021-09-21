CREATE TABLE `organization` (
	`RowId` INT(11) NOT NULL AUTO_INCREMENT,
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL DEFAULT NULL,
	`UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	`UpdatedById` INT(11) NULL DEFAULT NULL,
	PRIMARY KEY (`RowId`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=7
;

CREATE TABLE `userorganization` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`UserId` INT(11) NOT NULL,
	`OrganizationId` INT(11) NOT NULL,
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL DEFAULT NULL,
	`UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	`UpdatedById` INT(11) NULL DEFAULT NULL,
	PRIMARY KEY (`Id`) USING BTREE,
	INDEX `UserId` (`UserId`) USING BTREE,
	INDEX `OrganizationId` (`OrganizationId`) USING BTREE,
	CONSTRAINT `FK_OrganizationId_Organization` FOREIGN KEY (`OrganizationId`) REFERENCES `dmsdb`.`organization` (`RowId`) ON UPDATE RESTRICT ON DELETE RESTRICT,
	CONSTRAINT `FK_UserId_AspNetUsers` FOREIGN KEY (`UserId`) REFERENCES `dmsdb`.`aspnetusers` (`Id`) ON UPDATE RESTRICT ON DELETE RESTRICT
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=2
;
