using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Reactivities.Application.Features.Activities.Command;
using Reactivities.Application.Mappings;
using Reactivities.Application.Middlewares;

namespace Reactivities.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
            cfg.AddOpenBehavior(typeof(ValidationMiddleware<,>));
        });
        services.AddAutoMapper(applicationAssembly);
        services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();
    }
}
