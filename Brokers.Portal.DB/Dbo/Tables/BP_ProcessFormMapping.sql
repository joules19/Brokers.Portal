CREATE TABLE [dbo].[BP_ProcessFormMapping]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RoleId] INT NOT NULL,
	[ModuleId] INT NOT NULL,
	[ProcessId] INT NOT NULL,
	[FormName] VARCHAR(100) NOT NULL, 
	[CanView] BIT NULL, 
	[CanEdit] BIT NULL, 
	[CanDelete] BIT NULL, 
	[CanCreate] BIT NULL, 
)
