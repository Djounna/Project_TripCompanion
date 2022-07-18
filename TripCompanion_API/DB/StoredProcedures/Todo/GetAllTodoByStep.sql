CREATE PROCEDURE [dbo].[GetAllTodoByStep]
	@IdStep int
AS
	
	SELECT * FROM [Todo]
	Where [IdStep] = @IdStep;

RETURN 0
