<<<<<<< HEAD
﻿--Update Details Of Employee
=======
﻿--Update The Data
>>>>>>> cd397ebda21058ead17057898a84f3e6f3904de9
CREATE PROCEDURE [dbo].[spUpdateEmployee]
(
@EmpId INTEGER,
@Name VARCHAR(20),
@City VARCHAR(20),
@Department VARCHAR(20),
@Gender VARCHAR(20)
)
AS
BEGIN
UPDATE tblEmployee
SET
Name=@Name,
City=@City,
Department=@Department,
Gender=@Gender
WHERE
EmployeeId=@EmpId
END
GO