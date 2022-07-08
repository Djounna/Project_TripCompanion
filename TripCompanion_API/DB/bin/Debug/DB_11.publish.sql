/*
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
    [IdStep]       INT           NOT NULL,
    [Label]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AttachmentStep] PRIMARY KEY CLUSTERED ([IdAttachment] ASC)
);


GO
PRINT N'Création de Table [dbo].[AttachmentTodo]...';


GO
CREATE TABLE [dbo].[AttachmentTodo] (
    [IdAttachment] INT           IDENTITY (1, 1) NOT NULL,
    [IdTodo]       INT           NOT NULL,
    [Label]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AttachmentTodo] PRIMARY KEY CLUSTERED ([IdAttachment] ASC)
);


GO
PRINT N'Création de Table [dbo].[AttachmentTrip]...';


GO
CREATE TABLE [dbo].[AttachmentTrip] (
    [IdAttachment] INT           IDENTITY (1, 1) NOT NULL,
    [IdTrip]       INT           NOT NULL,
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
    [IdMainTodo]    INT            NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Done]          BIT            NOT NULL,
    [Status]        NVARCHAR (50)  NOT NULL,
    [Type]          NVARCHAR (50)  NULL,
    [Priority]      NVARCHAR (50)  NULL,
    [Calendar]      DATETIME       NULL,
    [Location]      NVARCHAR (50)  NULL,
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
    [IdTrip]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [StartingDate] DATE          NOT NULL,
    [EndingDate]   DATE          NOT NULL,
    [Budget]       INT           NULL,
    [Comments]     TEXT          NULL,
    [IdUser]       INT           NOT NULL,
    CONSTRAINT [PK_Trip] PRIMARY KEY CLUSTERED ([IdTrip] ASC),
    CONSTRAINT [UK_Trip_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
PRINT N'Création de Table [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [IdUser]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IdUser] ASC),
    CONSTRAINT [UK_Email] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [UK_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_AttachementStep__Step]...';


GO
ALTER TABLE [dbo].[AttachmentStep]
    ADD CONSTRAINT [FK_AttachementStep__Step] FOREIGN KEY ([IdStep]) REFERENCES [dbo].[Step] ([IdStep]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_AttachmentTodo__Todo]...';


GO
ALTER TABLE [dbo].[AttachmentTodo]
    ADD CONSTRAINT [FK_AttachmentTodo__Todo] FOREIGN KEY ([IdTodo]) REFERENCES [dbo].[Todo] ([IdTodo]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_AttachmentTrip__Trip]...';


GO
ALTER TABLE [dbo].[AttachmentTrip]
    ADD CONSTRAINT [FK_AttachmentTrip__Trip] FOREIGN KEY ([IdTrip]) REFERENCES [dbo].[Trip] ([IdTrip]);


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
PRINT N'Création de Procédure [dbo].[CheckUserExists]...';


GO
CREATE PROCEDURE [dbo].[CheckUserExists]
	@Username nvarchar(50),
	@Email nvarchar(50)
AS
	SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email;
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[CreateStep]...';


GO
CREATE PROCEDURE [dbo].[CreateStep]
	@IdTrip int,
	@Name nvarchar(50),
	@Budget int,
	@Time decimal(4,2),
	@Comments Text
	
AS
	Insert into [Step]([IdTrip], [Name], [Budget], [Time], [Comments])
	Output Inserted.IdStep
	Values (@IdTrip, @Name, @Budget, @Time, @Comments)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[CreateTodo]...';


GO
CREATE PROCEDURE [dbo].[CreateTodo]
	@IdMainTodo int,
	@Name nvarchar(50),
	@Done bit,
	@Status nvarchar(50),
	@Type nvarchar(50),
	@Priority nvarchar(50),
	@Calendar Datetime,
	@Location nvarchar(50),
	@PlannedTime decimal(4,2),
	@PlannedBudget int,
	
	@Comments Text

AS
	Insert into [Todo]([IdMainTodo], [Name], [Done], [Status], [Type], [Priority], [Calendar], 
	[Location], [PlannedTime], [PlannedBudget], [Comments])
	Output inserted.IdTodo
	Values (@IdMainTodo, @Name, @Done, @Status, @Type, @Priority, @Calendar, @Location,
	@PlannedTime, @PlannedBudget, @Comments);
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[CreateTrip]...';


GO
CREATE PROCEDURE [dbo].[CreateTrip]
	@Name nvarchar(50),
	@StartingDate Date,
	@EndingDate Date,
	@Budget int,
	@Comments Text,
	@IdUser int

AS
	Insert into [Trip]([Name], [StartingDate], [EndingDate], [Budget], [Comments], [IdUser])
	Output inserted.IdTrip
	Values (@Name, @StartingDate, @EndingDate, @Budget, @Comments, @IdUser)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[CreateUser]...';


GO
CREATE PROCEDURE [dbo].[CreateUser]
	@Username nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(50)
AS
	Insert into [User]([Username], [Email], [Password]) 
	Output inserted.IdUser 
	Values (@Username, @Email, @Password);
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[DeleteStep]...';


GO
CREATE PROCEDURE [dbo].[DeleteStep]
	@Id int
AS
	DELETE FROM [Step] WHERE [IdStep] = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[DeleteTodo]...';


GO
CREATE PROCEDURE [dbo].[DeleteTodo]
	@Id int
AS
	DELETE FROM [Todo] WHERE [IdTodo] = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[DeleteTrip]...';


GO
CREATE PROCEDURE [dbo].[DeleteTrip]
	@Id int
AS
	DELETE FROM [Trip] WHERE [IdTrip] = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[DeleteUser]...';


GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
	DELETE FROM [User] WHERE IdUser = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetAllStep]...';


GO
CREATE PROCEDURE [dbo].[GetAllStep]
	
AS
	SELECT * FROM [Step];
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetAllTodo]...';


GO
CREATE PROCEDURE [dbo].[GetAllTodo]
	AS
	SELECT * FROM [Todo];	
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetAllTrip]...';


GO
CREATE PROCEDURE [dbo].[GetAllTrip]
AS
	SELECT * FROM [Trip];
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetAllUser]...';


GO
CREATE PROCEDURE [dbo].[GetAllUser]
	
AS
	SELECT * FROM [User];
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetStepById]...';


GO
CREATE PROCEDURE [dbo].[GetStepById]
	@Id int
AS
	SELECT * FROM [Step] WHERE [IdStep] = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetStepByStepname]...';


GO
CREATE PROCEDURE [dbo].[GetStepByStepname]
	@Stepname nvarchar(50)
AS
	SELECT * FROM [Step] WHERE Name = @Stepname;
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetTodoById]...';


GO
CREATE PROCEDURE [dbo].[GetTodoById]
	@Id int
AS
	SELECT * FROM [Todo] WHERE [IdTodo] = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetTodoByTodoname]...';


GO
CREATE PROCEDURE [dbo].[GetTodoByTodoname]
	@Todoname nvarchar(50)
AS
	SELECT * FROM [Todo] WHERE Name = @Todoname;
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetTripById]...';


GO
CREATE PROCEDURE [dbo].[GetTripById]
	@Id int
AS
	SELECT * FROM [Trip] WHERE [IdTrip] = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetTripByTripname]...';


GO
CREATE PROCEDURE [dbo].[GetTripByTripname]
	@Tripname nvarchar(50)
AS
	SELECT * FROM [Trip] WHERE Name = @Tripname;
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetUserById]...';


GO
CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
AS
	SELECT * FROM [User] WHERE IdUser = @Id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetUserByUsername]...';


GO
CREATE PROCEDURE [dbo].[GetUserByUsername]
	@Username nvarchar(50)
AS
	SELECT * FROM [User] WHERE Username = @Username;
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[UpdateStep]...';


GO
CREATE PROCEDURE [dbo].[UpdateStep]
	@IdStep int,
	@IdTrip int,

	@Name nvarchar(50),
	@Budget int,
	@Time decimal(4,2),
	@Comments Text
	
AS
	Update [Step]
	Set [IdTrip]=@IdTrip, [Name]=@Name, [Budget]=@Budget, [Time]=@Time, [Comments]=@Comments 
	Where [IdStep] = @IdStep
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[UpdateTodo]...';


GO
CREATE PROCEDURE [dbo].[UpdateTodo]
	@IdTodo int,
	@IdMainTodo int,
	@Name nvarchar(50),
	@Done bit,
	@Status nvarchar(50),
	@Type nvarchar(50),
	@Priority nvarchar(50),
	@Calendar Datetime,
	@Location nvarchar(50),
	@PlannedTime decimal(4,2),
	@PlannedBudget int,
	@RealTime decimal(4,2),
	@RealBudget int,
	@Comments Text
AS
	Update [Todo]
	Set [IdMainTodo]=@IdMainTodo, [Name]=@Name, [Done]=@Done, [Status]=@Status, [Type]=@Type,
	[Priority]=@Priority, [Calendar]=@Calendar, [Location]=@Location, [RealTime]=@RealTime, [RealBudget]=@RealBudget,
	[PlannedTime]=@PlannedTime, [PlannedBudget]=@PlannedBudget, [Comments]=@Comments
	Where [IdTodo]=@IdTodo;
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[UpdateTrip]...';


GO
CREATE PROCEDURE [dbo].[UpdateTrip]
	@IdTrip int,
	@Name nvarchar(50),
	@StartingDate Date,
	@EndingDate Date,
	@Budget int,
	@Comments Text
	
AS
	Update [Trip]
	Set [Name]=@Name, [StartingDate]=@StartingDate, [EndingDate]=@EndingDate, [Budget]=@Budget, [Comments]=@Comments
	Where IdTrip = @IdTrip
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[UpdateUser]...';


GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@Id int,
	@Username nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(50)
AS
	Update [User]
	Set [Username]=@Username, [Email]=@Email, [Password]=@Password
	Where IdUser=@Id;
RETURN 0
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use [TripCompanion];
Go;

-- User --
Set Identity_Insert [User] On;
Go;

Insert into [User] ([IdUser],[Username],[Password],[Email])
Values (1, 'Test', 'Test', 'test.test@test.test'),
       (2, 'Corentin','Corentin','corentin.corentin@test.test');

Set Identity_Insert [User] Off;
Go;

Set Identity_Insert [Trip] On;
Go;

Insert into [Trip] ([IdTrip],[IdUser],[Name],[StartingDate],[EndingDate])
Values(1,2,'France','2022-09-01','2022-09-21');

Set Identity_Insert [Trip] Off;
Go;

Set Identity_Insert [Step] On;
Go;

Insert Into [Step]([IdStep],[IdTrip],[Name])
Values (1,1,'Paris');

Set Identity_Insert [Step] Off;
Go;

Set Identity_Insert [Todo] On;
Go;

Insert Into [Todo]([IdTodo],[IdStep],[Name],[Done],[Status])
Values (1, 1, 'MontMartre', 0, 'Actif'),
        (2,1, 'Notre-Dame', 0, 'Inactif');

Set Identity_Insert [Todo] Off;
Go;
GO

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
