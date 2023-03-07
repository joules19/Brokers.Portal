CREATE PROCEDURE [dbo].[spApplicaton_AddApplication]
	@ApplicationName varchar(100),
	@PasswordHash varchar(250)
AS
begin
	set nocount on;

	Insert into dbo.[BP_Applications] (ApplicationName, PasswordHash)
	values (@ApplicationName, @PasswordHash)
end

