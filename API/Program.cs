using System.Text;
using API;
using API.Data;
using API.Extensions;
using API.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<ExceptionsMiddleware>();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;
    try{
        var context = services.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();
        await Seed.SeedEmployees(context);
        await Seed.SeedCompanies(context);

    }
    catch(Exception ex){
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An Error has occured");
    }
app.Run();
