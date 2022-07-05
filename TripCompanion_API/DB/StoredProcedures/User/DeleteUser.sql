CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
	DELETE FROM [User] WHERE IdUser = @Id
RETURN 0
