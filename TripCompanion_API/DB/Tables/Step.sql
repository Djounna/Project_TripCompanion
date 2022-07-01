CREATE TABLE [dbo].[Step]
(
	[IdStep] INT NOT NULL identity,
	[IdTrip] int Not null,
	[Name] Nvarchar(50) not null,
	[Budget] int,
	[Time] DECIMAL(4,2),
	[Comments] TEXT,

	Constraint PK_Step primary key ([IdStep]),
	Constraint FK_Step__IdTrip Foreign key ([IdTrip]) references [Trip]([IdTrip]),
	Constraint UK_StepName unique ([Name])
)
