using Brokers.Portal.ExceptionHandling;
using Brokers.Portal.Modules.Company;
using Brokers.Portal.Modules.Management;
using Brokers.Portal.Modules.Products;
using Brokers.Portal.Modules.Underwriting;
using Brokers.Portal.Modules.Users;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding the Exception Handler MiddleWare
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

//Adding Services From Brokers Portal Modules
builder.Services.AddBrokerPortalUsersServices(connectionString);
builder.Services.AddBrokerPortalManagementServices(connectionString);
builder.Services.AddBrokerPortalUnderwritingServices(connectionString);
builder.Services.AddBrokerPortalProductServices(connectionString);
builder.Services.AddBrokerPortalCompanyServices(connectionString);

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
