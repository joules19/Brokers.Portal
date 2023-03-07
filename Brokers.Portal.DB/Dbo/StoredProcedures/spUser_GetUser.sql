CREATE PROCEDURE [dbo].[spUser_GetUser]
	@Email varchar(100)
AS
begin
	set nocount on;

	select Id, UserId ,FirstName, MiddleName, LastName, Mobile, Email, Username, CompanyId, PasswordHash, 
	PasswordSalt, IsActive, IsEmailVerified, DateCreated
	from dbo.[BP_Users]
	where Email = @Email;
end 
