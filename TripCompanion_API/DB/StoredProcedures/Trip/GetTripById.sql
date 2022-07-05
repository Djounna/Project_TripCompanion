CREATE PROCEDURE [dbo].[GetTripById]
	@Id int
AS
	SELECT * FROM [Trip] WHERE [IdTrip] = @Id
RETURN 0
