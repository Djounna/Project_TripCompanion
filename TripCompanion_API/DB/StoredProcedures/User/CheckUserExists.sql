CREATE PROCEDURE [dbo].[CheckUserExists]
	@Username nvarchar(50),
	@Email nvarchar(50)
AS
	SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email;
RETURN 0
