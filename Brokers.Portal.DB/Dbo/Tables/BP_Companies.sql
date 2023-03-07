CREATE TABLE [dbo].[BP_Companies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CompanyId] VARCHAR(10) NOT NULL, 
    [CompanyName] VARCHAR(100) NOT NULL, 
    [CompanyAddress] VARCHAR(100) NOT NULL, 
    [Mobile] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(100) NOT NULL,
    [City] VARCHAR(100) NOT NULL, 
    [State] VARCHAR(100) NOT NULL, 
    [PostalCode] VARCHAR(50) NULL, 
    [IsActive] BIT NOT NULL, 

)
