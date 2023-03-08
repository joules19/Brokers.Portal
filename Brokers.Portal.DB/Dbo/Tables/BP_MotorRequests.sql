CREATE TABLE [dbo].[BP_MotorRequests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[InsuredName] VARCHAR(100) not null,
    [Occupation] VARCHAR(100) not null,
    [EmailAddress] VARCHAR(100) not null,
    [TypeOfCover] VARCHAR(100) not null,
    [VehicleMake] VARCHAR(100) not null,
    [YearOfMake] VARCHAR(100) not null,
    [InsuranceStartDate] DateTime,
    [VehicleValue] Decimal,
    [InsuredValue] Decimal,
    [PaymentMode] VARCHAR(100) not null,
    [PolicyHolder] VARCHAR(100) not null,
    [Mobile] VARCHAR(100) not null,
    [Address] VARCHAR(100) not null,
    [TypeUsage] VARCHAR(100) not null,   
    [RegistrationNumber] VARCHAR(100) not null,
    [CoverPeriod] VARCHAR(100) not null,
    [PremiumRate] Decimal,
    [Premium] Decimal,
    [IdUploadUrl] VARCHAR(100) not null,
    [UtilityBillUploadUrl] VARCHAR(100) not null,
    [VehicleLicenseUploadUrl] VARCHAR(100) not null,
    [DateCreated] DateTime

)
