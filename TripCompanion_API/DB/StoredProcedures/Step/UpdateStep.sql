CREATE PROCEDURE [dbo].[UpdateStep]
	@IdStep int,
	@IdTrip int,

	@Name nvarchar(50),
	@Budget int,
	@Time decimal(4,2),
	@Comments Text
	
AS
	Update [Step]
	Set [IdTrip]=@IdTrip, [Name]=@Name, [Budget]=@Budget, [Time]=@Time, [Comments]=@Comments
	Output Inserted.IdTrip
	Where [IdStep] = @IdStep
RETURN 0
