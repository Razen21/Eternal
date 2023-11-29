using System.Net;
using Eternal.Network.Socket;

namespace Eternal.Network.Connection
{
    /// <summary>
    /// Interface representing a network server connection.
    /// </summary>
    public interface IServerConnection : IConnection
    {
        /// <summary>
        /// Socket group containing all active connection sockets.
        /// </summary>
        ConcurrentSocketGroup<string, IClientSocket> SocketGroup { get; }

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
    }
}
