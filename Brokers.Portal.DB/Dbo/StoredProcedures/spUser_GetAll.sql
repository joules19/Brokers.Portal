CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	set nocount on;

	select Id, UserId ,FirstName, MiddleName, LastName, Mobile, Email, Username, CompanyId, PasswordHash, 
	PasswordSalt, IsActive, IsEmailVerified, DateCreated
	from dbo.[BP_Users];
end 
