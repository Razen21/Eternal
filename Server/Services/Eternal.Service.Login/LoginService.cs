using System.Net;
using Eternal.Api.Network.Channel;
using Eternal.Api.Service.Hosting;
using Eternal.Common.Network.Channel;

namespace Eternal.Service.Login;

public class LoginService : IHostedServerService
{

    private readonly ILogger<LoginService> _logger;

    public LoginService(ILogger<LoginService> logger)
    {
        _logger = logger;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Channel.BindAsync();
        _logger.LogInformation("{service} server successfully bound on {address}:{port}",
            GetType().Name,
            Channel.EndPoint.Address,
            Channel.EndPoint.Port);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Channel.CloseAsync();
    }

    public ISimpleServerChannel Channel => ServerChannel.CreateNew("127.0.0.1", 8484);
}