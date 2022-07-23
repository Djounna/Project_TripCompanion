CREATE PROCEDURE [dbo].[UpdateTrip]
	@IdTrip int,
	@IdUser int,
	@Name nvarchar(50),
	@StartingDate Date,
	@EndingDate Date,
	@Budget int,
	@Comments Text
	
AS
	Update [Trip]
	Set [Name]=@Name, [StartingDate]=@StartingDate, [EndingDate]=@EndingDate, [Budget]=@Budget, [Comments]=@Comments, [IdUser]=@IdUser
	output Inserted.IdUser
	Where [IdTrip] = @IdTrip
RETURN 0
