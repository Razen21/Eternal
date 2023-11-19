using Eternal.Network.Messaging;
using Eternal.Network.Socket;
using System.Collections.Concurrent;
using System.Net;

namespace Eternal.Network.Connection
{
    /// <summary>
    /// Interface representing a network server connection.
    /// </summary>
    public interface IServerConnection : IConnection
    {
        /// <summary>
        /// Concurrent Dictionary used as a thread-safe in memory storage for active client sockets.
        /// </summary>
        ConcurrentDictionary<string, IClientSocket> Sockets { get; }

        /// <summary>
        /// Local endpoint the server connection should listen on.
        /// </summary>
        EndPoint LocalEndPoint { get; set; }

        /// <summary>
        /// Asynchronously starts a server connection and listens on the endpoint of <see cref="LocalEndPoint"/>. 
        /// </summary>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the start operation.</param>
        /// <returns>A <see cref="Task"/> representing the start operation.</returns>
        Task StartAsync(CancellationToken cancellation = default);

        /// <summary>
        /// Asynchronously sends a packet to the specified client socket if the socket is active.
        /// </summary>
        /// <param name="packet">The packet to send.</param>
        /// <param name="socket">The client socket to send the packet to.</param>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the send operation.</param>
        /// <returns>A <see cref="Task"/> representing the send operation.</returns>
        Task SendPacketAsync(IPacket packet, IClientSocket socket, CancellationToken cancellation = default);

        /// <summary>
        /// Asynchronously dispatches a packet to all active client sockets connected to the server connection.
        /// </summary>
        /// <param name="packet">The packet to dispatch.</param>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used to cancel the dispatch operation.</param>
        /// <returns>A <see cref="Task"/> representing the dispatch operation.</returns>
        Task DispatchPacketAsync(IPacket packet, CancellationToken cancellation = default);
    }
}
