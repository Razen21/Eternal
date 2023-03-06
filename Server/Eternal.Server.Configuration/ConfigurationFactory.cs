using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Eternal.Server.Configuration;

public static class ConfigurationFactory
{
    public static Action<HostBuilderContext, IConfigurationBuilder> DefaultConfiguration => (context, builder) =>
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true);
    };

}