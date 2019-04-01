<<<<<<< HEAD
﻿--Add The Employee
=======
﻿--Add The Data
>>>>>>> cd397ebda21058ead17057898a84f3e6f3904de9
CREATE PROCEDURE [dbo].[spAddEmployee]
(
@Name VARCHAR(20),
@City VARCHAR(20),
@Department VARCHAR(20),
@Gender VARCHAR(6)
)
AS
BEGIN
INSERT INTO tblEmployee(Name,City,Department,Gender)
VALUES(@Name,@City,@Department,@Gender)
END
GO