CREATE PROCEDURE [dbo].[spQuote_SubmitRequestForMotor]
	@Title varchar(100),
    @FirstName varchar(100),
    @Surname varchar(100),
    @Email varchar(100),
    @Mobile varchar(100),
    @Dob Date,
    @Gender varchar(100),
    @Occupation varchar(100),
    @Address varchar(100),
    @State varchar(100),
    @IdentificationType varchar(100),
    @IdentificationNumber varchar(100),
    @IdUpload varchar(100),
    @IdUploadUrl varchar(100),
    @TypeOfCover varchar(100),
    @VehicleCategory varchar(100),
    @VehicleValue Int,
    @PaymentOption varchar(100),
    @VehicleMake varchar(100),
    @ModelOfVehicle varchar(100),
    @RegistrationNumber varchar(100),
    @ChasisNumber varchar(100),
    @EngineNumber varchar(100),
    @YearOfMake varchar(100),
    @InsuranceStartDate Date,
    @VehicleColor varchar(100),
    @TotalCost Int,
    @DateCreated DateTime
AS
begin
	set nocount on;

	Insert into dbo.[BP_MotorRequests] (Title, FirstName, Email, Dob, Gender, Occupation, [Address], [State], IdentificationType, IdentificationNumber, IdUploadUrl, TypeOfCover, 
    VehicleCategory, VehicleValue, PaymentOption, VehicleMake, ModelOfVehicle, RegistrationNumber, ChasisNumber, EngineNumber, YearOfMake, InsuranceStartDate, VehicleColor, 
    TotalCost, DateCreated)
	values (@Title, @FirstName, @Email, @Dob, @Gender, @Occupation, @Address, @State, @IdentificationType, @IdentificationNumber, @IdUploadUrl, @TypeOfCover, 
    @VehicleCategory, @VehicleValue, @PaymentOption, @VehicleMake, @ModelOfVehicle, @RegistrationNumber, @ChasisNumber, @EngineNumber, @YearOfMake, @InsuranceStartDate, @VehicleColor, 
    @TotalCost, @DateCreated)
end