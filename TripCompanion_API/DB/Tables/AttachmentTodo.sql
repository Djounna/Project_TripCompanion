CREATE TABLE [dbo].[AttachmentTodo]
(
	[IdAttachment] INT NOT NULL identity,
	[IdTodo] int not null,
	[Label] Nvarchar(50) not null,

	Constraint PK_AttachmentTodo primary key ([IdAttachment]),
	Constraint FK_AttachmentTodo__Todo foreign key ([IdTodo]) references [Todo]([IdTodo])
)