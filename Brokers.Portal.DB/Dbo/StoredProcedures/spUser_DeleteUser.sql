CREATE PROCEDURE [dbo].[spUser_DeleteUser]
	@Id int
AS
begin
	set nocount on;

	delete 
	from dbo.[BP_Users]
	where Id = @Id;
end 
