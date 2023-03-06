using System.Diagnostics.CodeAnalysis;
using Eternal.Api.Service.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Eternal.Common.Service.Extensions;

public static class HostedServiceExtensions
{
    public static IServiceCollection AddHostedServerService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedServerService>(this IServiceCollection services)
        where THostedServerService : class, IHostedServerService
    {
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IHostedService, THostedServerService>());

        return services;
    }
}