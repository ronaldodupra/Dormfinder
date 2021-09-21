ALTER TABLE `aspnetusers`
	CHANGE COLUMN `LockoutEnd` `LockoutEndDate` TIMESTAMP NULL AFTER `LockoutEnabled`;