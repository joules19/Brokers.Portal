CREATE PROCEDURE [dbo].[spRole_GetRoles]
AS
begin
	set nocount on;

	select Id, RoleName
	from dbo.[BP_Roles];
end 
