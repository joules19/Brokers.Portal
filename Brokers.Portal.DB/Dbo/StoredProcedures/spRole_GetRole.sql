CREATE PROCEDURE [dbo].[spRole_GetRole]
	@Id int
AS
begin
	set nocount on;

	select Id, RoleName
	from dbo.[BP_Roles]
	where Id = @Id;
end 
