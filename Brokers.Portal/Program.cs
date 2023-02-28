using Brokers.Portal.Modules.Management;
using Brokers.Portal.Modules.Users;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddBrokerPortalUsersServices(connectionString);
builder.Services.AddBrokerPortalManagementServices(connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
