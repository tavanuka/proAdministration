using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using proAdministration.API.Mapping;
using proAdministration.API.Services;
using proAdministration.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

if (builder.Configuration.GetConnectionString("DefaultConnection") is not { } connectionString)
    throw new ArgumentException("The configuration has no provided connection string.");
    
// Ensures the connection string has been configured properly.
var csb = new MySqlConnectionStringBuilder(connectionString);

builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseMySql(csb.ToString(), ServerVersion.AutoDetect(csb.ToString())));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add operation services.
builder.Services.AddMapping();
builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();

app.UseCors(policyBuilder => policyBuilder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

app.Run();