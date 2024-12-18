﻿using hshmedstats.Application.Interfaces;
using hshmedstats.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace hshmedstats.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HshDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));
            });

            services.AddTransient<IHshDbContext>(provider =>
            {
                var dbContext = provider.GetService<HshDbContext>();
                var loggedInUser = provider.GetService<LoggedInUser>();
                dbContext.UserId = loggedInUser.Id;
                return dbContext;
            });
 
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<HshDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.Lockout.AllowedForNewUsers = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Acocunt/Logout";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
            });

            return services;
        }
    }
}
