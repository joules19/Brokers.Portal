CREATE PROCEDURE [dbo].[spQuote_GetRequestByRequestId]
	@RequestId varchar(10)
AS
begin
	set nocount on;
    
	Select RequestId, BrokerId, ProductId, PackageId, InsuredName, Occupation, EmailAddress, TypeOfCover, VehicleMake, YearOfMake, InsuranceStartDate,  
    VehicleValue, InsuredValue, ModeOfPayment, PolicyHolder, Mobile, [Address], TypeOfUsage, RegistrationNumber, CoverPeriod, PremiumRate,
    Premium, IdUploadUrl, UtilityBillUploadUrl, VehicleLicenseUploadUrl, BuildingValue, BuildingLocation, BuldingPurpose, DateCreated from dbo.[BP_Requests]
	Where RequestId = @RequestId
	
end