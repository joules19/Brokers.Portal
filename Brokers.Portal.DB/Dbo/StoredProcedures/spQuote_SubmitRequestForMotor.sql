CREATE PROCEDURE [dbo].[spQuote_SubmitRequestForMotor]
	@InsuredName varchar(100),
    @Occupation varchar(100),
    @EmailAddress varchar(100),
    @TypeOfCover varchar(100),
    @VehicleMake varchar(100),
    @YearOfMake Date,
    @InsuranceStartDate DateTime,
    @VehicleValue Decimal,
    @InsuredValue Decimal,
    @PaymentMode varchar(100),
    @PolicyHolder varchar(100),
    @Mobile varchar(100),
    @Address varchar(100),
    @TypeUsage varchar(100),
    @RegistrationNumber varchar(100),
    @CoverPeriod varchar(100),
    @PremiumRate Int,
    @Premium varchar(100),
    @IdUploadUrl varchar(100),
    @UtilityBillUploadUrl varchar(100),
    @VehicleLicenseUploadUrl varchar(100),
    @DateCreated DateTime
AS
begin
	set nocount on;

	Insert into dbo.[BP_MotorRequests] (InsuredName, Occupation, EmailAddress, TypeOfCover, VehicleMake, YearOfMake, InsuranceStartDate,  
    VehicleValue, InsuredValue, PaymentMode, PolicyHolder, Mobile, [Address], TypeUsage, RegistrationNumber, CoverPeriod, PremiumRate,
    Premium, IdUploadUrl, UtilityBillUploadUrl, VehicleLicenseUploadUrl, DateCreated)
	values (@InsuredName, @Occupation, @EmailAddress, @TypeOfCover, @VehicleMake, @YearOfMake, @InsuranceStartDate,  
    @VehicleValue, @InsuredValue, @PaymentMode, @PolicyHolder, @Mobile, @Address, @TypeUsage, @RegistrationNumber, @CoverPeriod, @PremiumRate,
    @Premium, @IdUploadUrl, @UtilityBillUploadUrl, @VehicleLicenseUploadUrl, @DateCreated)
end