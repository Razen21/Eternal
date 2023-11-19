using Eternal.Network.Messaging;
using Eternal.Network.Socket;
using System.Net;

namespace Eternal.Network.Connection
{
    /// <summary>
    /// Interface representing a network client connection.
    /// </summary>
    public interface IClientConnection : IConnection
    {
        /// <summary>
        /// The client socket associated with the client connection.
        /// </summary>
        IClientSocket Socket { get; }

        /// <summary>
        /// Remote endpoint of the server connection in which the client connection should connect to.
        /// </summary>
        EndPoint RemoteEndPoint { get; set; }

        /// <summary>
        /// Asynchronously connects to a server connection listening on the specified <see cref="RemoteEndPoint"/>.
        /// </summary>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the connect operation.</param>
        /// <returns>A <see cref="Task"/> representing the connect operation.</returns>
        Task ConnectAsync(CancellationToken cancellation = default);
        
        /// <summary>
        /// Asynchronously send a packet to the server connection the client is connected to.
        /// </summary>
        /// <param name="packet">The packet to send.</param>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the send operation.</param>
        /// <returns>A <see cref="Task"/> representing the send operation.</returns>
        Task SendPacketAsync(IPacket packet, CancellationToken cancellation = default);
    }
}
