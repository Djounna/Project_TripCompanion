CREATE PROCEDURE [dbo].[GetTodoByTodoname]
	@Todoname nvarchar(50)
AS
	SELECT * FROM [Todo] WHERE Name = @Todoname;
RETURN 0