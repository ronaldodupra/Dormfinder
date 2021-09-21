/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE IF NOT EXISTS `dmsdb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `dmsdb`;

CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` mediumtext DEFAULT NULL,
  `ClaimValue` mediumtext DEFAULT NULL,
  `RoleId` binary(16) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` binary(16) NOT NULL,
  `ConcurrencyStamp` mediumtext DEFAULT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `IsAdmin` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` mediumtext DEFAULT NULL,
  `ClaimValue` mediumtext DEFAULT NULL,
  `UserId` binary(16) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` char(36) NOT NULL,
  `ProviderKey` char(36) NOT NULL,
  `ProviderDisplayName` mediumtext DEFAULT NULL,
  `UserId` binary(16) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` binary(16) NOT NULL,
  `RoleId` binary(16) NOT NULL,
  `OrganizationId` int(11) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`,`OrganizationId`) USING BTREE,
  UNIQUE KEY `UserId_OrganizationId` (`UserId`,`OrganizationId`),
  KEY `FK_AspNetUserRoles_AspNetRoles` (`RoleId`),
  KEY `FK_AspNetUserRoles_organization` (`OrganizationId`) USING BTREE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`),
  CONSTRAINT `FK_AspNetUserRoles_organization` FOREIGN KEY (`OrganizationId`) REFERENCES `organization` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` mediumtext DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEndDateUtc` timestamp NULL DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` mediumtext DEFAULT NULL,
  `PhoneNumber` mediumtext DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` mediumtext DEFAULT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Status` varchar(255) NOT NULL DEFAULT 'Active',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  KEY `FirstName` (`FirstName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` binary(16) NOT NULL,
  `LoginProvider` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Value` mediumtext DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `bedspace` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(200) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `Price` decimal(10,2) DEFAULT NULL,
  `WaterUsageQuantity` decimal(10,2) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `IsActive` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `buildingpic` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BuildingId` int(11) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `RoomId` int(11) DEFAULT NULL,
  `FileName` varchar(100) DEFAULT NULL,
  `FileType` varchar(50) DEFAULT NULL,
  `FilePath` varchar(255) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `IsViewable` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `BuildingId` (`BuildingId`),
  KEY `RoomId` (`RoomId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `buildings` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Location` varchar(100) DEFAULT NULL,
  `NearBySchools` varchar(100) DEFAULT NULL,
  `Amenities` varchar(100) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Inclusions` varchar(50) DEFAULT NULL,
  `AlertRentalEffectivityEndDate` date DEFAULT NULL,
  `AlertReservationExpirationDate` date DEFAULT NULL,
  `Floors` int(11) DEFAULT NULL,
  `IsActive` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `charge` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `DefaultCharge` decimal(10,2) DEFAULT NULL,
  `BillingStatementOrder` int(11) DEFAULT NULL,
  `IsVat` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `BuildingIds` int(11) DEFAULT NULL,
  `ChargeIds` int(11) DEFAULT NULL,
  `ContractIds` int(11) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `BuildingIds` (`BuildingIds`),
  KEY `ChargeIds` (`ChargeIds`),
  KEY `ContractIds` (`ContractIds`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `contact` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `MiddleName` varchar(100) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `LandLineNumber` varchar(50) DEFAULT NULL,
  `MobileNumber` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(50) DEFAULT NULL,
  `YearsOfStudy` varchar(50) DEFAULT NULL,
  `Education` varchar(50) DEFAULT NULL,
  `Gender` varchar(50) DEFAULT NULL,
  `Birthday` date DEFAULT NULL,
  `Hobbies` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `IsActive` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `contractchecklist` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StudentId` int(11) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `ParentType` varchar(50) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `StudentId` (`StudentId`),
  KEY `ParentId` (`ParentId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `contractdeposit` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ReservationFee` decimal(10,2) DEFAULT NULL,
  `EarlyTerminationFee` decimal(10,2) DEFAULT NULL,
  `RfidDeposit` decimal(10,2) DEFAULT NULL,
  `SecurityDeposit` decimal(10,2) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `contracts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RentalEffectivityDate` date DEFAULT NULL,
  `MoveInDate` date DEFAULT NULL,
  `MoveOutDate` date DEFAULT NULL,
  `RentalEndDate` date DEFAULT NULL,
  `ReservationStartDate` date DEFAULT NULL,
  `ReservationExpirationDate` date DEFAULT NULL,
  `AllowableReservationDays` int(11) DEFAULT NULL,
  `EarlyTerminationFee` double DEFAULT NULL,
  `tenantName` varchar(50) DEFAULT NULL,
  `UnitNumber` varchar(50) DEFAULT NULL,
  `BedSpaceNumber` varchar(50) DEFAULT NULL,
  `SecurityDeposit` double DEFAULT NULL,
  `RFIDDeposit` double DEFAULT NULL,
  `UtilitiesElectricity` varchar(50) DEFAULT NULL,
  `UtilitiesWater` varchar(50) DEFAULT NULL,
  `Price` decimal(10,2) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `floor` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FloorNumber` varchar(50) DEFAULT NULL,
  `RoomIds` int(11) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoomIds` (`RoomIds`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `reference` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(50) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `UpdateAt` timestamp NULL DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `rentalpdc` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CheckNumber` varchar(50) DEFAULT NULL,
  `Bank` varchar(50) DEFAULT NULL,
  `Branch` varchar(50) DEFAULT NULL,
  `AccoutNumber` varchar(50) DEFAULT NULL,
  `Amount` decimal(10,2) DEFAULT NULL,
  `CheckDate` date DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  `MaturityDate` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `room` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Area` decimal(10,2) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `BedspaceIds` int(11) DEFAULT NULL,
  `IsActive` enum('Y','N') DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `BedspaceIds` (`BedspaceIds`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `utilities` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MeterNumber` varchar(50) DEFAULT NULL,
  `InitialReading` decimal(10,2) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedById` int(11) DEFAULT NULL,
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UpdatedById` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
