CREATE PROCEDURE [dbo].[spUser_AddUser]
	@UserId varchar(100),
	@Email varchar(100),
	@Username varchar(100),
	@PasswordHash varchar(250),
	@PasswordSalt varchar(250),
	@DateCreated DateTime,
	@CompanyId varchar(10)
AS
begin
	set nocount on;

	Insert into dbo.[BP_Users] (UserId, CompanyId, Email, Username, PasswordHash, PasswordSalt, DateCreated)
	values (@UserId, @CompanyId, @Email, @Username, @PasswordHash, @PasswordSalt, @DateCreated)
end

