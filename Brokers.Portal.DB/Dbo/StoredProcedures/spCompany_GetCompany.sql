CREATE PROCEDURE [dbo].[spCompany_GetCompany]
	@CompanyId VarChar(10)
AS
begin
	set nocount on;

	select *
	from dbo.[BP_Companies]
	where CompanyId = @CompanyId;
end 
