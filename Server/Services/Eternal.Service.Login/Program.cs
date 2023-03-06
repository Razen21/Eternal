using Eternal.Common.Logging;
using Eternal.Common.Service.Extensions;
using Eternal.Server.Configuration;
using Eternal.Service.Login;
using Serilog;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(ConfigurationFactory.DefaultConfiguration)
    .UseSerilog(LoggingFactory.DefaultSerilog)
    .ConfigureServices(((context, collection) =>
    {
        collection.AddHostedServerService<LoginService>();
    }))
    
    .Build().RunAsync();