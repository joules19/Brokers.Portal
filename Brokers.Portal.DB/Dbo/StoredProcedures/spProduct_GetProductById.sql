CREATE PROCEDURE [dbo].[spProduct_GetProductById]
	@ProductId INT
AS
begin
	set nocount on;

	select Id, ProductName, [Description]
	from dbo.[BP_Products]
	where Id = @ProductId;
end 
