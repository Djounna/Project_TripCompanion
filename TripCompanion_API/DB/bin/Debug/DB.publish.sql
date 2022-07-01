﻿/*
Script de déploiement pour TripCompanion

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TripCompanion"
:setvar DefaultFilePrefix "TripCompanion"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019DEV\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019DEV\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[AttachmentStep]...';


GO
CREATE TABLE [dbo].[AttachmentStep] (
    [IdAttachment] INT           IDENTITY (1, 1) NOT NULL,
    [Label]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AttachmentStep] PRIMARY KEY CLUSTERED ([IdAttachment] ASC)
);


GO
PRINT N'Création de Table [dbo].[AttachmentTodo]...';


GO
CREATE TABLE [dbo].[AttachmentTodo] (
    [IdAttachment] INT           IDENTITY (1, 1) NOT NULL,
    [Label]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AttachmentTodo] PRIMARY KEY CLUSTERED ([IdAttachment] ASC)
);


GO
PRINT N'Création de Table [dbo].[AttachmentTrip]...';


GO
CREATE TABLE [dbo].[AttachmentTrip] (
    [IdAttachment] INT           IDENTITY (1, 1) NOT NULL,
    [Label]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AttachmentTrip] PRIMARY KEY CLUSTERED ([IdAttachment] ASC)
);


GO
PRINT N'Création de Table [dbo].[Role]...';


GO
CREATE TABLE [dbo].[Role] (
    [IdRole]   INT           IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([IdRole] ASC),
    CONSTRAINT [UK_RoleName] UNIQUE NONCLUSTERED ([RoleName] ASC)
);


GO
PRINT N'Création de Table [dbo].[Step]...';


GO
CREATE TABLE [dbo].[Step] (
    [IdStep]   INT            IDENTITY (1, 1) NOT NULL,
    [IdTrip]   INT            NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [Budget]   INT            NULL,
    [Time]     DECIMAL (4, 2) NULL,
    [Comments] TEXT           NULL,
    CONSTRAINT [PK_Step] PRIMARY KEY CLUSTERED ([IdStep] ASC),
    CONSTRAINT [UK_StepName] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
PRINT N'Création de Table [dbo].[Todo]...';


GO
CREATE TABLE [dbo].[Todo] (
    [IdTodo]        INT            IDENTITY (1, 1) NOT NULL,
    [IdStep]        INT            NOT NULL,
    [IdMainTodo]    INT            NOT NULL,
    [Name]          VARCHAR (50)   NOT NULL,
    [Done]          BIT            NOT NULL,
    [Status]        VARCHAR (50)   NOT NULL,
    [Type]          VARCHAR (50)   NULL,
    [Priority]      VARCHAR (50)   NULL,
    [Calendar]      DATETIME       NULL,
    [Location]      VARCHAR (50)   NULL,
    [PlannedTime]   DECIMAL (4, 2) NULL,
    [PlannedBudget] INT            NULL,
    [RealTime]      DECIMAL (4, 2) NULL,
    [RealBudget]    INT            NULL,
    [Comments]      TEXT           NULL,
    CONSTRAINT [PK_Todo] PRIMARY KEY CLUSTERED ([IdTodo] ASC),
    CONSTRAINT [UK_TodoName] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
PRINT N'Création de Table [dbo].[Trip]...';


GO
CREATE TABLE [dbo].[Trip] (
    [IdTrip]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [StartingDate] DATE         NOT NULL,
    [EndingDate]   DATE         NOT NULL,
    [Budget]       INT          NULL,
    [Comments]     TEXT         NULL,
    [IdUser]       INT          NOT NULL,
    CONSTRAINT [PK_Trip] PRIMARY KEY CLUSTERED ([IdTrip] ASC),
    CONSTRAINT [UK_Trip_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
PRINT N'Création de Table [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [IdUser]   INT          IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IdUser] ASC),
    CONSTRAINT [UK_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Step__IdTrip]...';


GO
ALTER TABLE [dbo].[Step]
    ADD CONSTRAINT [FK_Step__IdTrip] FOREIGN KEY ([IdTrip]) REFERENCES [dbo].[Trip] ([IdTrip]);


GO
PRINT N'Création de Clé étrangère [dbo].[PK_Todo__IdStep]...';


GO
ALTER TABLE [dbo].[Todo]
    ADD CONSTRAINT [PK_Todo__IdStep] FOREIGN KEY ([IdStep]) REFERENCES [dbo].[Step] ([IdStep]);


GO
PRINT N'Création de Clé étrangère [dbo].[PK_Todo__IdMainTodo]...';


GO
ALTER TABLE [dbo].[Todo]
    ADD CONSTRAINT [PK_Todo__IdMainTodo] FOREIGN KEY ([IdMainTodo]) REFERENCES [dbo].[Todo] ([IdTodo]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Trip__IdUser]...';


GO
ALTER TABLE [dbo].[Trip]
    ADD CONSTRAINT [FK_Trip__IdUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([IdUser]);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
