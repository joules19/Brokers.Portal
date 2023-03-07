using Brokers.Portal.MiddleWares;
using Brokers.Portal.Modules.Company;
using Brokers.Portal.Modules.Management;
using Brokers.Portal.Modules.Products;
using Brokers.Portal.Modules.Underwriting;
using Brokers.Portal.Modules.Users;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Brokers Portal API",
        Description = "",
        Version = "v1"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);

});


//Adding the Basic Authentication MiddleWare
builder.Services.AddTransient<BasicAuthenticationMiddleware>();

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
app.UseSwaggerUI(c => c.SupportedSubmitMethods());

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseMiddleware<BasicAuthenticationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
