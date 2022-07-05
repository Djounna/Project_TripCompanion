CREATE PROCEDURE [dbo].[DeleteTodo]
	@Id int
AS
	DELETE FROM [Todo] WHERE [IdTodo] = @Id
RETURN 0
