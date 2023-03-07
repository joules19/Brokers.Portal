CREATE PROCEDURE [dbo].[spPackage_GetPackagesByProductId]
	@ProductId INT
AS
begin
	set nocount on;

	select Id, PackageName, ProductId
	from dbo.[BP_Packages]
	where ProductId = @ProductId;
end 
