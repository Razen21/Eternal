
using Eternal.Common.Logging;
using Eternal.Server.Configuration;
using Serilog;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(ConfigurationFactory.DefaultConfiguration)
    .UseSerilog(LoggingFactory.DefaultSerilog)
    
    
    .Build().RunAsync();