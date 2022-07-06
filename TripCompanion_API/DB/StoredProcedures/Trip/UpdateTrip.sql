CREATE PROCEDURE [dbo].[UpdateTrip]
	@IdTrip int,
	@Name nvarchar(50),
	@StartingDate Date,
	@EndingDate Date,
	@Budget int,
	@Comments Text
	
AS
	Update [Trip]
	Set Name=@Name, StartingDate=@StartingDate, EndingDate=@EndingDate, Budget=@Budget, Comments=@Comments)
	Where IdTrip = @IdTrip
RETURN 0
