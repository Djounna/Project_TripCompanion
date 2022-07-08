CREATE PROCEDURE [dbo].[GetPasswordHashByUsername]
	@Username nvarchar(50)
AS
	SELECT [Password] FROM [User] WHERE [Username] = @Username;
RETURN 0
