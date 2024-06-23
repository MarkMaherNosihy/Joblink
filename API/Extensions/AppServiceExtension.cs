using API.Data;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
    {

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddControllers(); // Add this line to add controller services
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}
