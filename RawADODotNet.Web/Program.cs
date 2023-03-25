using RawADODotNet.Web.Extensions.StartUp;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services
    .ConfigureConnectionString(builder.Configuration)
    .AddCMCustomDependency(builder.Configuration)
    .AddCMBuiltInDependency(builder.Environment, builder.Configuration);

var app = builder.Build();
app.AddMiddlewarePipelines();

