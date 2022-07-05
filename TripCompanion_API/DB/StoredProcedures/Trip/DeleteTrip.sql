CREATE PROCEDURE [dbo].[DeleteTrip]
	@Id int
AS
	DELETE FROM [Trip] WHERE [IdTrip] = @Id
RETURN 0
