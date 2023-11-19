using System.Text;

namespace Eternal.Network.Messaging
{
    public sealed class Packet : IPacket
    {
        private readonly MemoryStream _stream;
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;


        private Packet(MemoryStream stream)
        {
            _stream = stream;
            _reader = new BinaryReader(_stream);
            _writer = new BinaryWriter(_stream);
        }

        public byte[] Buffer  => _stream.ToArray();

        public short OperationCode { get; set; } = -1;

        /// <summary>
        /// Factory method used to create an inbound read-only packet.
        /// </summary>
        /// <param name="buffer">Raw byte array containing incoming network data.</param>
        /// <param name="readOperationCode">Value defining if the operation code should be read.</param>
        /// <returns>The created <see cref="IPacket"/> instance.</returns>
        public static IPacket CreateInbound(byte[] buffer, bool readOperationCode = true)
        {
            var packet = new Packet(new MemoryStream(buffer));

            if (readOperationCode)
            {
                packet.OperationCode = packet.ReadShort();
            }

            return packet;
        }

        /// <summary>
        /// Factory method used to create an outbound write-only packet.
        /// </summary>
        /// <param name="operationCode">Optional operation code to write.</param>
        /// <returns>The created <see cref="IPacket"/> instance.</returns>
        public static IPacket CreateOutbound(short? operationCode)
        {
            var packet = new Packet(new MemoryStream());

            if (operationCode.HasValue)
            {
                packet.OperationCode = operationCode.Value;
                packet.WriteShort(packet.OperationCode);
            }

            return packet;
        }

        public byte ReadByte()
        {
            return _reader.ReadByte();
        }

        public bool ReadBoolean()
        {
            return _reader.ReadBoolean();
        }

        public short ReadShort()
        {
            return _reader.ReadInt16();
        }

        public ushort ReadUnsignedShort()
        {
            return _reader.ReadUInt16();
        }

        public float ReadFloat()
        {
            return _reader.ReadSingle();
        }

        public int ReadInt()
        {
            return _reader.ReadInt32();
        }

        public uint ReadUnsignedInt()
        {
            return _reader.ReadUInt32();
        }

        public double ReadDouble()
        {
            return _reader.ReadDouble();
        }

        public long ReadLong()
        {
            return _reader.ReadInt64();
        }

        public ulong ReadUnsignedLong()
        {
            return _reader.ReadUInt64();
        }

        public byte[] ReadBuffer(int size)
        {
            return _reader.ReadBytes(size);
        }

        public string ReadString(short? length = null)
        {
            return Encoding.ASCII.GetString(_reader.ReadBytes(length ?? _reader.ReadInt16()));
        }

        public IPacket WriteByte(byte value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteBoolean(bool value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteShort(short value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteUnsignedShort(ushort value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteFloat(float value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteInt(int value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteUnsignedInt(uint value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteDouble(double value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteLong(long value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteUnsignedLong(ulong value)
        {
            _writer.Write(value);
            return this;
        }

        public IPacket WriteBuffer(byte[] buffer)
        {
            _writer.Write(buffer);
            return this;
        }

        public IPacket WriteString(string value, short? length = null)
        {
            if (length.HasValue)
            {
                if (value.Length > length) value = value[..length.Value];
                _writer.Write(Encoding.ASCII.GetBytes(value.PadRight(length.Value, '\0')));
            }
            else
            {
                _writer.Write((short)Encoding.ASCII.GetByteCount(value));
                _writer.Write(Encoding.ASCII.GetBytes(value));
            }

            return this;
        }

        public void Dispose()
        {
            _stream.Dispose();
            _reader.Dispose();
            _writer.Dispose();
        }
    }
}
