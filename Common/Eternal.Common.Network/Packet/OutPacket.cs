using System.Security;
using System.Text;
using DotNetty.Buffers;
using Eternal.Api.Network.Packet;
using Eternal.Api.Operations;

namespace Eternal.Common.Network.Packet;

public sealed class OutPacket : IPacket
{
    public OutOperation Operation { get; }
    
    public IByteBuffer Buffer { get; }

    public OutPacket(OutOperation operation)
    {
        Buffer = Unpooled.Buffer();
        Operation = operation;

        WriteShort((short)Operation);

    }
    

    public OutPacket WriteByte(byte value)
    {
        Buffer.WriteByte(value);
        return this;
    }

    public OutPacket WriteBytes(byte[] bytes)
    {
        Buffer.WriteBytes(bytes);
        return this;
    }

    public OutPacket WriteShort(short value)
    {
        Buffer.WriteShortLE(value);
        return this;
    }

    public OutPacket WriteInt(int value)
    {
        Buffer.WriteIntLE(value);
        return this;
    }

    public OutPacket WriteLong(long value)
    {
        Buffer.WriteLongLE(value);
        return this;
    }
    
    public OutPacket WriteFloat(float value)
    {
        Buffer.WriteFloatLE(value);
        return this;
    }
    
    public OutPacket WriteDouble(double value)
    {
        Buffer.WriteDoubleLE(value);
        return this;
    }

    
    
    
}