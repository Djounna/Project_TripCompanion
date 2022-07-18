CREATE PROCEDURE [dbo].[GetAllTripByUser]
	@IdUser int
AS
	
	SELECT * FROM [Trip]
	Where [IdUser] = @IdUser;

RETURN 0
