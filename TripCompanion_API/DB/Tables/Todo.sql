CREATE TABLE [dbo].[Todo]
(
	[IdTodo] INT NOT NULL identity,
	[IdStep] int not null,
	[IdMainTodo] int not null,
	[Name] VARCHAR(50) NOT NULL,
	[Done] bit NOT NULL,
   [Status] VARCHAR(50) NOT NULL,
   [Type] VARCHAR(50),
   [Priority] VARCHAR(50),
   [Calendar] DATETIME,
   [Location] VARCHAR(50),
   [PlannedTime] DECIMAL(4,2),
   [PlannedBudget] int,
   [RealTime] DECIMAL(4,2),
   [RealBudget] int,
   Comments TEXT,

   Constraint PK_Todo primary key ([IdTodo]),
   Constraint PK_Todo__IdStep foreign key ([IdStep]) references [Step]([IdStep]),
   Constraint PK_Todo__IdMainTodo foreign key ([IdMainTodo]) references [Todo]([IdTodo]),
   Constraint UK_TodoName unique ([Name])
)