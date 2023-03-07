CREATE TABLE [dbo].[BP_Applications]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ApplicationName] VARCHAR(100) not null,
    [PasswordHash] VARCHAR(250) NOT NULL,

    CONSTRAINT UC_Application UNIQUE (ApplicationName)
)
