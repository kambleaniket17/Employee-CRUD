<<<<<<< HEAD
﻿--Delete Employee
=======
﻿--Delete The Data
>>>>>>> cd397ebda21058ead17057898a84f3e6f3904de9
CREATE PROCEDURE [dbo].[spDeleteEmployee]
(
@EmpId INTEGER
)
AS
BEGIN
DELETE FROM tblEmployee WHERE EmployeeId=@EmpId
END
GO