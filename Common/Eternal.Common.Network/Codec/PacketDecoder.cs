using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Eternal.Api.Network.Channel;


namespace Eternal.Common.Network.Codec;

public sealed class PacketDecoder : ByteToMessageDecoder
{
    public PacketDecoder(ISimpleChannel channel)
    {
        
    }

    protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
    {
        throw new NotImplementedException();
    }
}