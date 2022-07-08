CREATE PROCEDURE [dbo].[UpdateUser]
	@Id int,
	@Username nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(100)
AS
	Update [User]
	Set [Username]=@Username, [Email]=@Email, [Password]=@Password
	Where IdUser=@Id;
RETURN 0
