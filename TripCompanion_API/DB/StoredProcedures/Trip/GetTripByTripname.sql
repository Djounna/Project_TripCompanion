CREATE PROCEDURE [dbo].[GetTripByTripname]
	@Tripname nvarchar(50)
AS
	SELECT * FROM [Trip] WHERE Name = @Tripname;
RETURN 0
