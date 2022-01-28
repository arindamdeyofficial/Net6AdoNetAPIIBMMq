using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Web;
using Net6AdoNetAPIIBMMq;

var builder = WebApplication.CreateBuilder(args);
//https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
//Healthcheck
builder.Services.AddHealthChecks()
    .AddTypeActivatedCheck<HealthCheckWithArgs>(
        "Sample",
        failureStatus: HealthStatus.Degraded,
        tags: new[] { "sample" },
        args: new object[] { 1, "Arg" })
    .AddSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.Configure<HealthCheckPublisherOptions>(options =>
{
    options.Delay = TimeSpan.FromSeconds(2);
    options.Predicate = healthCheck => healthCheck.Tags.Contains("sample");
});

builder.Services.AddSingleton<IHealthCheckPublisher, HealthCheckPublisher>();


// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//HealthCheck
app.MapHealthChecks("/healthz");
app.MapHealthChecksUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
