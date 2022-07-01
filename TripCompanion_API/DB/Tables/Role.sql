CREATE TABLE [dbo].[Role]
(
	[IdRole] INT NOT NULL identity,
	[RoleName] nvarchar(50) not null,

	Constraint PK_Role Primary key ([IdRole]),
	Constraint UK_RoleName unique ([RoleName])
)
