CREATE PROCEDURE [dbo].[DeleteStep]
	@Id int
AS
	DELETE FROM [Step] WHERE [IdStep] = @Id
RETURN 0