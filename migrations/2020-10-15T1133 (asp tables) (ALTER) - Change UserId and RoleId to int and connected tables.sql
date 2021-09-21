ALTER TABLE `aspnetusers`
	CHANGE COLUMN `Id` `Id` INT NOT NULL AUTO_INCREMENT FIRST;

ALTER TABLE `aspnetuserclaims`
	CHANGE COLUMN `UserId` `UserId` INT NOT NULL DEFAULT 0 AFTER `ClaimValue`;

ALTER TABLE `aspnetroleclaims`
	ALTER `RoleId` DROP DEFAULT;
ALTER TABLE `aspnetroleclaims`
	CHANGE COLUMN `RoleId` `RoleId` INT NOT NULL AFTER `ClaimValue`,
	DROP FOREIGN KEY `FK_AspNetRoleClaims_AspNetRoles`;

ALTER TABLE `aspnetuserroles`
	ALTER `UserId` DROP DEFAULT,
	ALTER `RoleId` DROP DEFAULT;
ALTER TABLE `aspnetuserroles`
	CHANGE COLUMN `UserId` `UserId` INT NOT NULL FIRST,
	CHANGE COLUMN `RoleId` `RoleId` INT NOT NULL AFTER `UserId`,
	DROP FOREIGN KEY `FK_AspNetUserRoles_AspNetRoles`;

	
ALTER TABLE `aspnetroles`
	CHANGE COLUMN `Id` `Id` INT NOT NULL AUTO_INCREMENT FIRST;
	
	
ALTER TABLE `aspnetroleclaims`
	CHANGE COLUMN `RoleId` `RoleId` INT NOT NULL DEFAULT 0 AFTER `ClaimValue`;

ALTER TABLE `aspnetroles`
	CHANGE COLUMN `Id` `Id` INT NOT NULL AUTO_INCREMENT FIRST;


ALTER TABLE `aspnetuserlogins`
	ALTER `UserId` DROP DEFAULT;
ALTER TABLE `aspnetuserlogins`
	CHANGE COLUMN `UserId` `UserId` INT NOT NULL AFTER `ProviderDisplayName`;
	
ALTER TABLE `aspnetusertokens`
	ALTER `UserId` DROP DEFAULT;
ALTER TABLE `aspnetusertokens`
	CHANGE COLUMN `UserId` `UserId` INT NOT NULL FIRST;


ALTER TABLE `aspnetroleclaims`
	ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`);

ALTER TABLE `aspnetuserroles`
	ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`);
