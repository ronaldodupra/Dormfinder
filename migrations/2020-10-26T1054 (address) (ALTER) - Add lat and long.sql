CREATE TABLE IF NOT EXISTS `address` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Province` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`City` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`AddressLine1` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`AddressLine2` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL,
	`UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	`UpdatedById` INT(11) NULL,
	PRIMARY KEY (`Id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
;

ALTER TABLE `address`
	ADD COLUMN `Latitude` DECIMAL(8,6) NULL DEFAULT NULL AFTER `AddressLine2`,
	ADD COLUMN `Longitude` DECIMAL(9,6) NULL DEFAULT NULL AFTER `Latitude`;
