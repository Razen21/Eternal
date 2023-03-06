using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Eternal.Api.Network.Channel;
using Eternal.Api.Network.Packet;



namespace Eternal.Common.Network.Codec;

public sealed class PacketEncoder : MessageToByteEncoder<IPacket>
{
    public PacketEncoder(ISimpleChannel channel)
    {
        
    }

    protected override void Encode(IChannelHandlerContext context, IPacket message, IByteBuffer output)
    {
        throw new NotImplementedException();
        
        
    }
}