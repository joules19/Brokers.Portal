CREATE TABLE [dbo].[BP_Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] VARCHAR(100) NOT NULL, 
    [FirstName] VARCHAR(100) NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [Email] VARCHAR(100) NOT NULL,
    [Mobile] VARCHAR(50) NULL, 
    [Username] VARCHAR(100) NOT NULL,
    [CompanyId] VARCHAR(10) NOT NULL,
    [PasswordHash] VARCHAR(250) NOT NULL,
    [PasswordSalt] VARCHAR(250) NOT NULL,
    [IsActive] BIT NULL,
    [IsEmailVerified] BIT NULL,
    [isProfileUpdated] BIT NULL,
    [DateCreated] DateTime NOT NULL,
)
