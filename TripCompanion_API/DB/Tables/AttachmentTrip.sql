CREATE TABLE [dbo].[AttachmentTrip]
(
	[IdAttachment] INT NOT NULL identity,
	[IdTrip] int Not null,
	[Label] Nvarchar(50) not null,

	Constraint PK_AttachmentTrip primary key ([IdAttachment]),
	Constraint FK_AttachmentTrip__Trip foreign key ([IdTrip]) references [Trip]([IdTrip])
)