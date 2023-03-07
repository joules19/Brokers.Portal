CREATE PROCEDURE [dbo].[spModule_GetModule]
	@Id int
AS
begin
	set nocount on;

	select Id, ModuleName
	from dbo.[BP_Modules]
	where Id = @Id;
end 
