CREATE PROCEDURE [dbo].[spProduct_GetProductByName]
	@ProductName varchar(250)
AS
begin
	set nocount on;

	select Id, ProductName, [Description]
	from dbo.[BP_Products]
	where ProductName = @ProductName;
end 
