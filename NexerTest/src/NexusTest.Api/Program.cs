using NexusTest.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddApiConfiguration();
builder.Services.AddDatabaseConfiguration(configuration);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
var environment = app.Environment;
app.UseApiConfiguration(environment);
app.UseSwaggerConfiguration(environment);
app.Run();
