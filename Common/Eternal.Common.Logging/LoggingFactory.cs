using Microsoft.Extensions.Hosting;
using Serilog;

namespace Eternal.Common.Logging;

public static class LoggingFactory
{
    public static Action<HostBuilderContext, LoggerConfiguration> DefaultSerilog => (context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    };
}