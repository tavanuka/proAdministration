using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using proAdministration.API.Clients;
using proAdministration.API.Clients.Handlers;
using proAdministration.API.Mapping;
using proAdministration.API.Options;
using proAdministration.API.Services;
using proAdministration.Data.Contexts;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Configuration bind
builder.Services.Configure<FirstVoucherApiOptions>(
    builder.Configuration.GetSection(FirstVoucherApiOptions.SectionName));

// Configure local program.cs settings
var settings = builder.Configuration
    .GetSection(FirstVoucherApiOptions.SectionName)
    .Get<FirstVoucherApiOptions>();

if (settings is null)
    throw new ArgumentException("Settings are not configured right.");

if (builder.Configuration.GetConnectionString("DefaultConnection") is not { } connectionString)
    throw new ArgumentException("The configuration has no provided connection string.");

// Ensures the connection string has been configured properly.
var csb = new MySqlConnectionStringBuilder(connectionString);

builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseMySql(csb.ToString(), ServerVersion.AutoDetect(csb.ToString())));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add REST services to connect to the first-voucher API
builder.Services.AddTransient<FirstVoucherAuthenticationHeaderHandler>();
builder.Services.AddTransient<HttpLoggingHandler>();
builder.Services
    .AddRefitClient<IFirstVoucherApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(settings.Uri))
    .AddHttpMessageHandler<HttpLoggingHandler>()
    .AddHttpMessageHandler<FirstVoucherAuthenticationHeaderHandler>();

// Add operation services.
builder.Services.AddMapping();
builder.Services.AddScoped<IFirstVoucherService, FirstVoucherService>();
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