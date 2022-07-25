CREATE TABLE [dbo].[Todo]
(
	[IdTodo] INT NOT NULL identity,
	[IdStep] int not null,
	[IdMainTodo] int,
	[Name] NVARCHAR(50) NOT NULL,
	[Done] bit NOT NULL,
   [Status] NVARCHAR(50) NOT NULL,
   [Type] NVARCHAR(50),
   [Priority] NVARCHAR(50),
   [Calendar] DATETIME,
   [Location] nVARCHAR(50),
   [PlannedTime] DECIMAL(4,2),
   [PlannedBudget] int,
   [RealTime] DECIMAL(4,2),
   [RealBudget] int,
   Comments TEXT,

   Constraint PK_Todo primary key ([IdTodo]),
   Constraint PK_Todo__IdStep foreign key ([IdStep]) references [Step]([IdStep]),
   Constraint PK_Todo__IdMainTodo foreign key ([IdMainTodo]) references [Todo]([IdTodo])
)