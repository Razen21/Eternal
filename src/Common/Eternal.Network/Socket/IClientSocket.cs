using Eternal.Network.Messaging;

namespace Eternal.Network.Socket
{
    /// <summary>
    /// Interface representing a network client socket.
    /// </summary>
    public interface IClientSocket
    {
        /// <summary>
        /// Unique identification given to the client socket.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Immutable client version information used in session verification and encryption.
        /// </summary>
        ClientVersionRecord Version { get; set; }

        /// <summary>
        /// Randomly generated <see cref="uint"/> value used for session verification and encryption.
        /// </summary>
        uint ReceiveSequence { get; set; }

        /// <summary>
        /// Randomly generated <see cref="uint"/> value used for session verification and encryption.
        /// </summary>
        uint SendSequence { get; set; }

        /// <summary>
        /// Asynchronously sends an <see cref="IPacket"/> to the client associated with this socket.
        /// </summary>
        /// <param name="packet">The packet to send.</param>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the send operation.</param>
        /// <returns>A <see cref="Task"/> representing the send packet operation.</returns>
        Task SendPacketAsync(IPacket packet, CancellationToken cancellation = default);

        /// <summary>
        /// Asynchronously closes the socket.
        /// </summary>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the close operation.</param>
        /// <returns>A <see cref="Task"/> representing the close operation.</returns>
        Task CloseAsync(CancellationToken cancellation = default);
    }
}
