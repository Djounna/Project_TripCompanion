CREATE PROCEDURE [dbo].[GetStepByStepname]
	@Stepname nvarchar(50)
AS
	SELECT * FROM [Step] WHERE Name = @Stepname;
RETURN 0
