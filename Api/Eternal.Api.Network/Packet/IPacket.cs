using DotNetty.Buffers;

namespace Eternal.Api.Network.Packet;

public interface IPacket
{
     /// <summary>
     /// Simple byte array containing all of the packet data.
     /// </summary>
     IByteBuffer Buffer { get; }
     
}