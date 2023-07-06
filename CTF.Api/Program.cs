using CTF.Api;
using CTF.Extensions;
using Microsoft.OpenApi.Models;
using RST.Extensions;

var builder = WebApplication.CreateBuilder(args);
var assemblies = new[]
{
    "MealPlanSystem",
    "MealPlanSystem.Api"
}.LoadAssemblies()
.ToArray();

var services = builder.Services;

services
    .AddAutoMapper(assemblies)
    .AddSingleton<ApplicationSettings>()
    .AddServices<ApplicationSettings>(a => a.ConnectionString)
    .AddMediatR(configure => configure
        .RegisterServicesFromAssemblies(assemblies))
    .AddControllers();
services
    .AddSwaggerGen(c => {
        c.CustomSchemaIds(c => c.FullName);
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Meal Plan System API",
            Version = "v1"
        });
    });

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.UseSwagger();
await app.RunAsync();