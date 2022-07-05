CREATE PROCEDURE [dbo].[GetStepById]
	@Id int
AS
	SELECT * FROM [Step] WHERE [IdStep] = @Id
RETURN 0
