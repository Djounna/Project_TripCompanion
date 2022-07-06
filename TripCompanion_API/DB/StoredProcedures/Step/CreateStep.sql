CREATE PROCEDURE [dbo].[CreateStep]
	@Name nvarchar(50),
	@Budget int,
	@Time float,
	@Comments Text,
	@IdTrip int
AS
	Insert into [Step](IdTrip, Name, Budget, Time, Comments)
	Output Inserted.IdStep
	Values (@IdTrip, @Name, @Budget, @Time, @Comments)
RETURN 0
