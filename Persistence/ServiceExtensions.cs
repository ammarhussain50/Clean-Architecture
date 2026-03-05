using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.IdentityModels;
using Persistence.Seeds;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.SharedServices;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            // Add custom service registrations here
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDataProtection();
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(30);
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IAccountService, AccountService>();
            //Seeds roles and users
            DefaultRoles.SeedRolesAsync(services.BuildServiceProvider()).Wait();
            DefaultUsers.SeedUsersAsync(services.BuildServiceProvider()).Wait();
        }
    }   
}
