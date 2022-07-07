CREATE PROCEDURE [dbo].[CreateStep]
	@IdTrip int,
	@Name nvarchar(50),
	@Budget int,
	@Time decimal(4,2),
	@Comments Text
	
AS
	Insert into [Step]([IdTrip], [Name], [Budget], [Time], [Comments])
	Output Inserted.IdStep
	Values (@IdTrip, @Name, @Budget, @Time, @Comments)
RETURN 0
