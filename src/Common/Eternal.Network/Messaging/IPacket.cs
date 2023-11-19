using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternal.Network.Messaging
{
    /// <summary>
    /// Interface representing a generic network packet message containgin raw data.
    /// </summary>
    public interface IPacket : IDisposable
    {
        /// <summary>
        /// Byte array representing the underlying raw packet data.
        /// </summary>
        byte[] Buffer { get; }

        /// <summary>
        /// Unique identifier used to denote the operation that the packet is associated with.
        /// </summary>
        short OperationCode { get; set; }

        /// <summary>
        /// Reads a <see cref="byte"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="byte"/> value.</returns>
        byte ReadByte();

        /// <summary>
        /// Reads a <see cref="bool"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="bool"/> value.</returns>
        bool ReadBoolean();

        /// <summary>
        /// Reads a <see cref="short"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="short"/> value.</returns>
        short ReadShort();

        /// <summary>
        /// Reads a <see cref="ushort"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="ushort"/> value.</returns>
        ushort ReadUnsignedShort();

        /// <summary>
        /// Reads a <see cref="float"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="float"/> value.</returns>
        float ReadFloat(); // Corrected the spelling of "Float"

        /// <summary>
        /// Reads a <see cref="int"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="int"/> value.</returns>
        int ReadInt();

        /// <summary>
        /// Reads a <see cref="uint"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="uint"/> value.</returns>
        uint ReadUnsignedInt();

        /// <summary>
        /// Reads a <see cref="double"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="double"/> value.</returns>
        double ReadDouble();

        /// <summary>
        /// Reads a <see cref="long"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="long"/> value.</returns>
        long ReadLong();

        /// <summary>
        /// Reads a <see cref="ulong"/> value from the packet buffer.
        /// </summary>
        /// <returns>The <see cref="ulong"/> value.</returns>
        ulong ReadUnsignedLong();

        /// <summary>
        /// Reads a byte array of a specified size from the packet buffer.
        /// </summary>
        /// <param name="size">The size of the byte array to read.</param>
        /// <returns>The byte array.</returns>
        byte[] ReadBuffer(int size);

        /// <summary>
        /// Reads a <see cref="string"/> from the packet buffer. A length can be specified, otherwise, the length is inferred.
        /// </summary>
        /// <param name="length">The optional length of the string to read. If null, the length is inferred.</param>
        /// <returns>The <see cref="string"/> value.</returns>
        string ReadString(short? length = null);

        /// <summary>
        /// Writes a <see cref="byte"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteByte(byte value);

        /// <summary>
        /// Writes a <see cref="bool"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteBoolean(bool value);

        /// <summary>
        /// Writes a <see cref="short"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteShort(short value);

        /// <summary>
        /// Writes a <see cref="ushort"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteUnsignedShort(ushort value);

        /// <summary>
        /// Writes a <see cref="float"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteFloat(float value);

        /// <summary>
        /// Writes a <see cref="int"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteInt(int value);

        /// <summary>
        /// Writes a <see cref="uint"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteUnsignedInt(uint value);

        /// <summary>
        /// Writes a <see cref="double"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteDouble(double value);

        /// <summary>
        /// Writes a <see cref="long"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteLong(long value);

        /// <summary>
        /// Writes a <see cref="ulong"/> value to the packet buffer.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteUnsignedLong(ulong value);

        /// <summary>
        /// Writes a byte array to the packet buffer.
        /// </summary>
        /// <param name="buffer">The byte array to write.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteBuffer(byte[] buffer);

        /// <summary>
        /// Writes a <see cref="string"/> to the packet buffer. A length can be specified, otherwise, the full string is written.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to write.</param>
        /// <param name="length">The optional length of the string to write. If null, the full string is written.</param>
        /// <returns>The <see cref="IPacket"/> instance for chaining.</returns>
        IPacket WriteString(string value, short? length = null);
    }
}
