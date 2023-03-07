CREATE PROCEDURE [dbo].[spApplication_AddApplication]
	@ApplicationName varchar(50)
AS
begin
	set nocount on;

	Select ApplicationName, PasswordHash from dbo.[BP_Applications]
	Where ApplicationName = @ApplicationName
end

