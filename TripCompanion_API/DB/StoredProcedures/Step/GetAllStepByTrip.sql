CREATE PROCEDURE [dbo].[GetAllStepByTrip]	
	@IdTrip int
AS	
	SELECT * FROM [Step]
	Where [IdTrip] = @IdTrip;

RETURN 0
