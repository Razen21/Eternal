using System.Net;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Eternal.Api.Network.Channel;
using Eternal.Common.Network.Channel.Handler;
using Eternal.Common.Network.Codec;

namespace Eternal.Common.Network.Channel;

public class ServerChannel : ISimpleServerChannel
{
    private readonly IEventLoopGroup? _bossGroup, _workerGroup;
    
    public IPEndPoint EndPoint { get; }
    public IChannel? Channel { get; private set; }
    public ChannelState State { get; private set; }

    private ServerChannel(IPEndPoint endPoint)
    {
        EndPoint = endPoint;
        _bossGroup = new MultithreadEventLoopGroup();
        _workerGroup = new MultithreadEventLoopGroup();
    }
    
    public static ServerChannel CreateNew(IPEndPoint endPoint) => new(endPoint);
    public static ServerChannel CreateNew(string address, int port) => new(new IPEndPoint(IPAddress.Parse(address), port));

    public async Task BindAsync()
    {
        Channel = await new ServerBootstrap()
            .Group(_bossGroup, _workerGroup)
            .Channel<TcpServerSocketChannel>()
            .Option(ChannelOption.SoBacklog, 1024)
            .ChildHandler(new ActionChannelInitializer<IChannel>(ch =>
            {
                ch.Pipeline.AddLast(
                    new ReadTimeoutHandler(TimeSpan.FromMinutes(4)),
                    new PacketDecoder(this),
                    new ServerChannelHandler(this),
                    new PacketEncoder(this)
                );
            }))
            .BindAsync(EndPoint);

        State = ChannelState.Active;
    }
    
    public async Task CloseAsync()
    {
        await Channel?.CloseAsync()!;
        await _bossGroup?.ShutdownGracefullyAsync()!;
        await _workerGroup?.ShutdownGracefullyAsync()!;

        State = ChannelState.Closed;
    }
}