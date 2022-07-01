CREATE TABLE [dbo].[AttachmentStep]
(
	[IdAttachment] INT NOT NULL identity,
	[IdStep] int not null,
	[Label] Nvarchar(50) not null,

	Constraint PK_AttachmentStep primary key ([IdAttachment]),
	Constraint FK_AttachementStep__Step foreign key ([IdStep]) references [Step]([IdStep])
)