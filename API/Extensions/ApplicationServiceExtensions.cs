using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using API.SignalR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<PresenceTracker>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSignalR();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}