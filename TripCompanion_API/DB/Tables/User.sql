CREATE TABLE [dbo].[User]
(
	[IdUser] INT NOT NULL Identity,
	[Username] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	Constraint PK_User Primary key ([IdUser]),
	Constraint UK_Username unique ([Username])

)