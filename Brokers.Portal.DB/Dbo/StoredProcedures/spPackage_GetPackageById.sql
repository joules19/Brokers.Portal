CREATE PROCEDURE [dbo].[spPackage_GetPackageById]
	@PackageId INT
AS
begin
	set nocount on;

	select Id, PackageName, ProductId
	from dbo.[BP_Packages]
	where Id = @PackageId;
end 
