using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UdemyDateApi.Data;
using UdemyDateApi.Interfaces;
using UdemyDateApi.Services;
using UdemyDateApp.Data;

namespace UdemyDateApi.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Default"));
            });
            services.AddCors();
            services.AddScoped<ITokenService,TokenService>();
            return services;
        }
    }
}
