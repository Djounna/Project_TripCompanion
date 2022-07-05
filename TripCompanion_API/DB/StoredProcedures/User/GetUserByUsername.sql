CREATE PROCEDURE [dbo].[GetUserByUsername]
	@Username nvarchar(50)
AS
	SELECT * FROM [User] WHERE Username = @Username;
RETURN 0
