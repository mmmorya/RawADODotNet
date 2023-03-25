using RawADODotNet.Web.Extensions.StartUp;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureConnectionString(builder.Configuration)
    .AddCMCustomDependency(builder.Configuration)
    .AddCMBuiltInDependency(builder.Environment, builder.Configuration);

var app = builder.Build();
app.AddMiddlewarePipelines();

