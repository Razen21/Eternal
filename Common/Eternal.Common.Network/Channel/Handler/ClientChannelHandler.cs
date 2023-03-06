using DotNetty.Transport.Channels;
using Eternal.Api.Network.Channel;
using Eternal.Api.Network.Packet;
using Eternal.Common.Network.Packet;

namespace Eternal.Common.Network.Channel.Handler;

public class ClientChannelHandler : ChannelHandlerAdapter
{
    public ClientChannelHandler(ISimpleChannel channel)
    {
        
    }

    public override void ChannelRead(IChannelHandlerContext context, object message)
    {
        var data = message as IPacket;
        var packet = new InPacket(data.Buffer);

        


    }
}