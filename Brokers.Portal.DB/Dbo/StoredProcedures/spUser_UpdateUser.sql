CREATE PROCEDURE [dbo].[spUser_UpdateUser]
	@UserId varchar(100),
	@FirstName varchar(100),
	@MiddleName varchar(100),
	@LastName varchar(100),
	@Mobile varchar(50),
	@isProfileUpdated bit
AS
begin
	set nocount on;

	update dbo.[BP_Users] 
	set FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Mobile = @Mobile, isProfileUpdated = @isProfileUpdated
	where UserId = @UserId;

end 

