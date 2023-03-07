CREATE PROCEDURE [dbo].[spRole_AddRole]
	@RoleName varchar(100)
AS
begin
	set nocount on;

	Insert into dbo.[BP_Roles] (RoleName)
	values (@RoleName)
end

