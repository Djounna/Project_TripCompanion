/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use [TripCompanion];
Go;

-- User --
Set Identity_Insert [User] On;
Go;

Insert into [User] ([IdUser],[Username],[Password],[Email])
Values (1, "Test", "Test", "test.test@test.test"),
       (2, "Corentin","Corentin","corentin.corentin@test.test");

Set Identity_Insert [User] Off;
Go;

Set Identity_Insert [Trip] On;
Go;

Insert into [Trip] ([IdTrip],[IdUser],[Name],[StartingDate],[EndingDate])
Values(1,2,"France",01/09/2022,21/09/2022);

Set Identity_Insert [Trip] Off;
Go;

Set Identity_Insert [Step] On;
Go;

Insert Into [Step]([IdStep],[IdTrip],[Name])
Values (1,1,"Paris");

Set Identity_Insert [Step] Off;
Go;

Set Identity_Insert [Todo] On;
Go;

Insert Into [Todo]([IdTodo],[IdStep],[Name],[Done],[Status])
Values (1, 1, "MontMartre", 0, "Actif"),
        (2,1, "Notre-Dame", 0, "Inactif");

Set Identity_Insert [Todo] Off;
Go;
GO
