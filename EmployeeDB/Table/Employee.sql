CREATE TABLE [dbo].[tblEmployee](
	[EmployeeId]     [INT]           IDENTITY(1,1)    NOT NULL,
	[Name]           [VARCHAR](20)				      NOT NULL,
	[City]           [VARCHAR](20)				      NOT NULL,
	[Department]     [VARCHAR](20)				      NOT NULL,
	[Gender]         [VARCHAR](6)				      NOT NULL
) ON [PRIMARY]									      
GO