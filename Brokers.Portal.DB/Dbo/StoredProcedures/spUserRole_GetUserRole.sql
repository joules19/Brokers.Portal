CREATE PROCEDURE [dbo].[spUserRole_GetUserRole]
	@UserId VARCHAR(100)
AS
begin
	set nocount on;

	select Id, UserId, RoleId
	from dbo.[BP_UserRoles]
	where UserId = @UserId;
end 
