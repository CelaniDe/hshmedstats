using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace hshmedstats.Application
{
    public static class MediatRInjections
    {
        public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
        {
          /*  services.AddTransient(typeof(IRequestHandler<AssignOrganizationToOwnerCommand<Payer>, bool>), typeof(AssignOrganizationToOwnerCommandHandler<Payer>));
            services.AddTransient(typeof(IRequestHandler<AssignOrganizationToOwnerCommand<Client>, bool>), typeof(AssignOrganizationToOwnerCommandHandler<Client>));*/

            /*services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));*/
            /*services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingHandler<,,>));*/
            return services;
        }
    }
}
