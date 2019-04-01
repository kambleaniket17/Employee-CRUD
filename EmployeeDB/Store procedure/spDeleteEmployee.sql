--Delete Employee
CREATE PROCEDURE [dbo].[spDeleteEmployee]
(
@EmpId INTEGER
)
AS
BEGIN
DELETE FROM tblEmployee WHERE EmployeeId=@EmpId
END
GO