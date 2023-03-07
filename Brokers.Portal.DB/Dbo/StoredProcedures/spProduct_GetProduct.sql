CREATE PROCEDURE [dbo].[spProduct_GetProduct]
	@Id INT
AS
begin
	set nocount on;

	select Id, ProductName
	from dbo.[BP_Products]
	where Id = @Id;
end 
