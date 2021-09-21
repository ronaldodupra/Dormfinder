ALTER TABLE `lead`
	ADD COLUMN `CreatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() AFTER `Message`,
	ADD COLUMN `CreatedById` INT(11) NULL DEFAULT NULL AFTER `CreatedAt`,
	ADD COLUMN `UpdatedAt` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp() AFTER `CreatedById`,
	ADD COLUMN `UpdatedById` INT(11) NULL DEFAULT NULL AFTER `UpdatedAt`;
