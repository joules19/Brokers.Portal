CREATE PROCEDURE [dbo].[spUser_GetUserById]
	@UserId varchar(100)
AS
begin
	set nocount on;

	select Id, UserId ,FirstName, MiddleName, LastName, Mobile, Email, Username, CompanyId, PasswordHash, 
	PasswordSalt, IsActive, IsEmailVerified, DateCreated
	from dbo.[BP_Users]
	where UserId = @UserId;
end 
