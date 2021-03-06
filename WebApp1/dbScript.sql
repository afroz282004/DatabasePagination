-- Script for create table
CREATE TABLE [dbo].[tblCustomers](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL
)

-- Script for create Stored procedure
CREATE PROCEDURE [dbo].[GetCustomer]
	@PageIndex INT = 1,
	@PageSize INT = 15,
	@RecordCount INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ROW_NUMBER() OVER(ORDER BY Id ASC)AS RowNumber,ID,
	Name,Company,Phone,Address,Country,Email
	INTO #Results FROM tblCustomers
     
	SELECT @RecordCount = COUNT(*) FROM #Results
           
	SELECT * FROM #Results WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 
	AND (((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
     
	DROP TABLE #Results
END