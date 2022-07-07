CREATE PROCEDURE [dbo].[CreateTodo]
	@IdMainTodo int,
	@Name nvarchar(50),
	@Done bit,
	@Status nvarchar(50),
	@Type nvarchar(50),
	@Priority nvarchar(50),
	@Calendar Datetime,
	@Location nvarchar(50),
	@PlannedTime decimal(4,2),
	@PlannedBudget int,
	
	@Comments Text

AS
	Insert into [Todo]([IdMainTodo], [Name], [Done], [Status], [Type], [Priority], [Calendar], 
	[Location], [PlannedTime], [PlannedBudget], [Comments])
	Output inserted.IdTodo
	Values (@IdMainTodo, @Name, @Done, @Status, @Type, @Priority, @Calendar, @Location,
	@PlannedTime, @PlannedBudget, @Comments);
RETURN 0
