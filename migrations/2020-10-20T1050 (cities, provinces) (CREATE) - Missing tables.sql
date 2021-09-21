CREATE TABLE `cities` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Description` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL,
	`UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	`UpdatedById` INT(11) NULL,
	PRIMARY KEY (`Id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
;

CREATE TABLE `provinces` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Description` INT(11) NULL,
	`CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp(),
	`CreatedById` INT(11) NULL,
	`UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
	`UpdatedById` INT(11) NULL,
	PRIMARY KEY (`Id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
;
