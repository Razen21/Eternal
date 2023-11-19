namespace Eternal.Network.Connection
{
    /// <summary>
    /// Interface representing a generic network connection.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Current state of the connection.
        /// </summary>
        ConnectionState State { get; set; }  

        /// <summary>
        /// Asynchronously stops and closes the connection. 
        /// </summary>
        /// <param name="cancellation">Optional <see cref="CancellationToken"/> used for canceling the stop operation.</param>
        /// <returns>A <see cref="Task"/> representing the stop operation.</returns>
        Task StopAsync(CancellationToken cancellation = default);
    }
}
