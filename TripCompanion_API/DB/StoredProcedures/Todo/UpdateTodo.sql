CREATE PROCEDURE [dbo].[UpdateTodo]
	@IdTodo int,
	@IdStep int,
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
	@RealTime decimal(4,2),
	@RealBudget int,
	@Comments Text
AS
	Update [Todo]
	Set [IdMainTodo]=@IdMainTodo, [IdStep]=@IdStep, [Name]=@Name, [Done]=@Done, [Status]=@Status, [Type]=@Type,
	[Priority]=@Priority, [Calendar]=@Calendar, [Location]=@Location, [RealTime]=@RealTime, [RealBudget]=@RealBudget,
	[PlannedTime]=@PlannedTime, [PlannedBudget]=@PlannedBudget, [Comments]=@Comments
	Output Inserted.IdStep
	Where [IdTodo]=@IdTodo;
RETURN 0
