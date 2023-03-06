using System.Net;
using DotNetty.Transport.Channels;

namespace Eternal.Api.Network.Channel;

public interface ISimpleChannel
{
    IPEndPoint EndPoint { get; }
    IChannel? Channel { get; }
    ChannelState State { get; }
    Task CloseAsync();
}

public interface ISimpleClientChannel : ISimpleChannel
{
    Task ConnectAsync();
}

public interface ISimpleServerChannel : ISimpleChannel
{
    Task BindAsync();
}