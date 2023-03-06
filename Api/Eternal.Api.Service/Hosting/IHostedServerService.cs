using Eternal.Api.Network.Channel;
using Microsoft.Extensions.Hosting;

namespace Eternal.Api.Service.Hosting;

public interface IHostedServerService : IHostedService
{
    ISimpleServerChannel Channel { get; }
}