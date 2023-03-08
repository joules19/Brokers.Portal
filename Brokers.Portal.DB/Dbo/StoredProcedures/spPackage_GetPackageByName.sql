CREATE PROCEDURE [dbo].[spPackage_GetPackageByName]
	@PackageName VARCHAR(100)
AS
begin
	set nocount on;

	select Id, PackageName, ProductId
	from dbo.[BP_Packages]
	where PackageName = @PackageName;
end 
