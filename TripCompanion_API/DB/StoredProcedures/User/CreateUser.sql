CREATE PROCEDURE [dbo].[CreateUser]
	@Username nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(100)
AS
	Insert into [User]([Username], [Email], [Password]) 
	Output inserted.IdUser 
	Values (@Username, @Email, @Password);
RETURN 0
