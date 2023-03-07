CREATE PROCEDURE [dbo].[spProcessFormMapping_GetMapping]
	@RoleId Int
AS
begin
	set nocount on;

	select Id, RoleId, ModuleId, ProcessId, FormName, CanCreate, CanView, CanEdit, CanDelete
	from dbo.[BP_ProcessFormMapping]
	where RoleId = @RoleId;
end 