CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
begin
	set nocount on;

	select Id, ProductName
	from dbo.[BP_Products];
end 