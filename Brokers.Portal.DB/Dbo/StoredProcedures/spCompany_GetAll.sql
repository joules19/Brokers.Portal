CREATE PROCEDURE [dbo].[spCompany_GetAll]
AS
begin
	set nocount on;

	select Id, CompanyId, CompanyName, Mobile, Email, CompanyAddress, City, [State], PostalCode
	from dbo.[BP_Companies]
end 
