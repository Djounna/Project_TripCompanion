CREATE TABLE [dbo].[Trip]
(
	[IdTrip] INT NOT NULL identity,
	[Name] NVARCHAR(50) NOT NULL,
	[StartingDate] DATE NOT NULL,
    [EndingDate] DATE NOT NULL,
    [Budget] int,
	[Comments] TEXT,
	[IdUser] int not null,

	Constraint PK_Trip primary key ([IdTrip]),
	Constraint FK_Trip__IdUser foreign key ([IdUser]) references [User]([IdUser]),
	Constraint UK_Trip_Name unique ([Name])

)