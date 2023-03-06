using System.Text;
using DotNetty.Buffers;
using Eternal.Api.Network.Packet;
using Eternal.Api.Operations;

namespace Eternal.Common.Network.Packet;

public sealed class InPacket : IPacket
{
    public InOperation Operation { get; }
    public IByteBuffer Buffer { get; }

    public InPacket(IByteBuffer buffer)
    {
        Buffer = buffer;
        Operation = (InOperation)ReadShort();
    }

    
    public byte ReadByte() => Buffer.ReadByte();
    public bool ReadBoolean() => Buffer.ReadBoolean();
    public short ReadShort() => Buffer.ReadShortLE();
    public ushort ReadUShort() => Buffer.ReadUnsignedShortLE();
    public int ReadInt => Buffer.ReadIntLE();
    public uint ReadUInt => Buffer.ReadUnsignedIntLE();
    public long ReadLong => Buffer.ReadLongLE();
    public string ReadAsciiString() => Buffer.ReadString(Buffer.ReadShortLE(), Encoding.ASCII);
    public DateTime ReadDateTime => DateTime.FromFileTimeUtc(Buffer.ReadLongLE());



}