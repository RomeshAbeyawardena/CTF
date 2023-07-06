using CTF.Api;
using CTF.Extensions;
using Microsoft.OpenApi.Models;
using RST.Extensions;

var builder = WebApplication.CreateBuilder(args);
var assemblies = InstanceAssemblies.Names.LoadAssemblies()
.ToArray();

var services = builder.Services;

services
    .AddAutoMapper(assemblies)
    .AddSingleton<ApplicationSettings>()
    .AddServices<ApplicationSettings>(a => a.ConnectionString, InstanceAssemblies.API_ASSEMBLY)
    .AddMediatR(configure => configure
        .RegisterServicesFromAssemblies(assemblies))
    .AddControllers();
services
    .AddSwaggerGen(c => {
        c.CustomSchemaIds(c => c.FullName);
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Contractual Transaction Framework API",
            Version = "v1"
        });
    });

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.UseSwagger();
await app.RunAsync();