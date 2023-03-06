using System.Diagnostics;
using System.Net;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Eternal.Api.Network.Channel;
using Eternal.Common.Network.Channel.Handler;
using Eternal.Common.Network.Codec;

namespace Eternal.Common.Network.Channel;

public sealed class ClientChannel : ISimpleClientChannel
{
    private readonly IEventLoopGroup? _workerGroup;
    
    public IPEndPoint EndPoint { get; }
    public IChannel? Channel { get; private set; }
    public ChannelState State { get; private set; }
    
    private ClientChannel(IPEndPoint endPoint)
    {
        EndPoint = endPoint;
        _workerGroup = new MultithreadEventLoopGroup();
    }

    public static ClientChannel CreateNew(IPEndPoint endPoint) => new(endPoint);
    public static ClientChannel CreateNew(string address, int port) => new(new IPEndPoint(IPAddress.Parse(address), port));

    public async Task ConnectAsync()
    {
        Channel = await new Bootstrap()
            .Group(_workerGroup)
            .Channel<TcpSocketChannel>()
            .Option(ChannelOption.TcpNodelay, true)
            .Handler(new ActionChannelInitializer<IChannel>(ch =>
            {
                ch.Pipeline.AddLast(
                    new PacketDecoder(this),
                    new ClientChannelHandler(this),
                    new PacketEncoder(this)
                );
            }))
            .ConnectAsync(EndPoint);

        State = ChannelState.Active;
    }
    
    public async Task CloseAsync()
    {
        await Channel?.CloseAsync()!;
        await _workerGroup?.ShutdownGracefullyAsync()!;
    }



}