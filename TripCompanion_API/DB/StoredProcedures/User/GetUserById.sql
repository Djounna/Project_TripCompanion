CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
AS
	SELECT * FROM [User] WHERE IdUser = @Id
RETURN 0
