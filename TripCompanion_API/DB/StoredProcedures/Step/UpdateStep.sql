CREATE PROCEDURE [dbo].[UpdateStep]
	@IdStep int,
	@Name nvarchar(50),
	@Budget int,
	@Time float,
	@Comments Text,
	@IdTrip int
AS
	Update [Step]
	Set IdTrip=@IdTrip, Name=@Name, Budget=@Budget, Time=@Time, Comments=@Comments 
	Where IdStep = @IdStep
RETURN 0
