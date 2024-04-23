﻿using Heartify.Core.Contracts;
using Heartify.Core.Services;
using Heartify.Infrastructure.Data;
using Heartify.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonProfileService, PersonProfileService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IDatingService, DatingService>();

            return services;
        }
        public static IServiceCollection AddheartifyDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SchoolConnection");
            services.AddDbContext<HeartifyDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<HeartifyDbContext>();

            return services;
        }
    }
}
