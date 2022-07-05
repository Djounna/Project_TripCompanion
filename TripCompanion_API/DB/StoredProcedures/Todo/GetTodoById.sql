CREATE PROCEDURE [dbo].[GetTodoById]
	@Id int
AS
	SELECT * FROM [Todo] WHERE [IdTodo] = @Id
RETURN 0