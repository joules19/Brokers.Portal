CREATE PROCEDURE [dbo].[spUserRole_AddUserRole]
	@UserId varchar(100), 
	@RoleId INT
AS
begin
	set nocount on;

	Insert into dbo.[BP_UserRoles] (UserId, RoleId)
	values (@UserId, @RoleId)
end

