CREATE PROCEDURE [dbo].[spCompany_AddCompany]
	@CompanyId varchar(10),
	@CompanyName varchar(100),
	@Mobile varchar(50),
	@Email varchar(100),
	@CompanyAddress varchar(100),
	@City varchar(100),
	@State varchar(100),
	@PostalCode varchar(50)
AS
begin
	set nocount on;

	Insert into dbo.[BP_Companies] (CompanyId, CompanyName, Mobile, Email, CompanyAddress, City, [State], PostalCode)
	values (@CompanyId, @CompanyName, @Mobile, @Email, @CompanyAddress, @City, @State, @PostalCode)
end

