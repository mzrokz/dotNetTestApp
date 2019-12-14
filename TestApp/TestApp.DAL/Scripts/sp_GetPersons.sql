USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[GetPersons]    Script Date: 12/14/2019 7:18:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetPersons]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM Person.Person
    SELECT * FROM Person.EmailAddress

	Select p.BusinessEntityID, p.FirstName,p.LastName,e.EmailAddress
	INTO #Persons
	FROM Person.Person p
	INNER JOIN Person.EmailAddress e ON p.BusinessEntityID = e.BusinessEntityID


	Select * from #Persons

END
