CREATE TABLE [dbo].[User]
(
	[IdUser] INT NOT NULL Identity,
	[Username] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Email] Nvarchar(50) Not null,
	Constraint PK_User Primary key ([IdUser]),
	Constraint UK_Username unique ([Username]),
	Constraint UK_Email unique ([Email])

)