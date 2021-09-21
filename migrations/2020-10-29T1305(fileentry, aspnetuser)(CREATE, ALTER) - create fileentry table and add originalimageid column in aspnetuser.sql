CREATE TABLE IF NOT EXISTS `fileentries` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Filename` VARCHAR(255) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci',
	`Path` TEXT(65535) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci',
	`Length` INT(11) NULL DEFAULT NULL,
	`MediaType` VARCHAR(255) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci',
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL DEFAULT NULL,
	`UpdatedById` INT(11) NULL DEFAULT NULL,
	`UpdatedAt` TIMESTAMP NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	PRIMARY KEY (`Id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=12
;



ALTER TABLE `aspnetusers`
	ADD COLUMN IF NOT EXISTS `OriginalImageId` INT NULL DEFAULT NULL AFTER `VerifiedAt`;
