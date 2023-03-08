CREATE PROCEDURE [dbo].[spQuote_SubmitRequestForMotor]
	@RequestId varchar(10),
	@BrokerId varchar(100),
	@ProductId INT,
	@PackageId INT,
	@InsuredName varchar(100),
    @Occupation varchar(100),
    @EmailAddress varchar(100),
    @TypeOfCover varchar(100),
    @VehicleMake varchar(100),
    @YearOfMake varchar(4),
    @InsuranceStartDate DateTime,
    @VehicleValue Decimal,
    @InsuredValue Decimal,
    @ModeOfPayment varchar(100),
    @PolicyHolder varchar(100),
    @Mobile varchar(100),
    @Address varchar(100),
    @TypeOfUsage varchar(100),
    @RegistrationNumber varchar(100),
    @CoverPeriod Int,
    @PremiumRate Int,
    @Premium varchar(100),
    @IdUploadUrl varchar(100),
    @UtilityBillUploadUrl varchar(100),
    @VehicleLicenseUploadUrl varchar(100),
    @BuildingValue Decimal,
    @BuildingLocation varchar(100),
    @BuildingPurpose varchar(100),
    @DateCreated DateTime
AS
begin
	set nocount on;

	Insert into dbo.[BP_Requests] (RequestId, BrokerId, ProductId, PackageId, InsuredName, Occupation, EmailAddress, TypeOfCover, VehicleMake, YearOfMake, InsuranceStartDate,  
    VehicleValue, InsuredValue, ModeOfPayment, PolicyHolder, Mobile, [Address], TypeOfUsage, RegistrationNumber, CoverPeriod, PremiumRate,
    Premium, IdUploadUrl, UtilityBillUploadUrl, VehicleLicenseUploadUrl, BuildingValue, BuildingLocation, BuldingPurpose, DateCreated)
	values (@RequestId, @BrokerId, @ProductId, @PackageId, @InsuredName, @Occupation, @EmailAddress, @TypeOfCover, @VehicleMake, @YearOfMake, @InsuranceStartDate,  
    @VehicleValue, @InsuredValue, @ModeOfPayment, @PolicyHolder, @Mobile, @Address, @TypeOfUsage, @RegistrationNumber, @CoverPeriod, @PremiumRate,
    @Premium, @IdUploadUrl, @UtilityBillUploadUrl, @VehicleLicenseUploadUrl, @BuildingValue, @BuildingLocation, @BuildingPurpose, @DateCreated)
end