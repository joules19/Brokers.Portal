CREATE PROCEDURE [dbo].[spExtension_GetExtensionsByProductId]
	@ProductId INT
AS
begin
	set nocount on;

	select Id, ExtensionName, ProductId
	from dbo.[BP_Extensions]
	where ProductId = @ProductId;
end 
