using FluentValidation;
using hshmedstats.Application.Dtos;
using hshmedstats.Application.Interfaces;
using hshmedstats.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;


namespace hshmedstats.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<LoggedInUser>(sp =>
            {
                var context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                if (context != null && context.User != null)
                {
                    int.TryParse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);
                    var username = context.User.FindFirst(ClaimTypes.Name)?.Value;
                    var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
                    var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

                    return new LoggedInUser
                    {
                        Id = userId,
                        Username = username,
                        Email = email,
                    };
                }

                return new LoggedInUser();
            });


            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DependancyInjection).Assembly));
            services.AddMediatRHandlers();
            services.AddValidatorsFromAssemblyContaining<PatientDtoValidator>();
          
            return services;
        }
    }
}
