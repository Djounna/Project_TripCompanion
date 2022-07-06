CREATE PROCEDURE [dbo].[CreateTrip]
	@Name nvarchar(50),
	@StartingDate Date,
	@EndingDate Date,
	@Budget int,
	@Comments Text,
	@IdUser int

AS
	Insert into [Trip](Name, StartingDate, EndingDate, Budget, Comments, IdUser)
	Output inserted.IdTrip
	Values (@Name, @StartingDate, @EndingDate, @Budget, @Comments, @IdUser)
RETURN 0
