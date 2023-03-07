CREATE PROCEDURE [dbo].[spProcess_GetProcess]
	@Id int
AS
begin
	set nocount on;

	select Id, ProcessName, EntryUrl, ModuleId
	from dbo.[BP_Processes]
	where Id = @Id;
end 
