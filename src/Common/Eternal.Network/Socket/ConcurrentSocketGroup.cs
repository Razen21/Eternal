using System.Collections.Concurrent;
using Eternal.Network.Messaging;
using Eternal.Network.Socket;

namespace Eternal.Network;

public class ConcurrentSocketGroup<TKey, TValue>() : ConcurrentDictionary<TKey, TValue>
    where TKey : notnull
    where TValue : IClientSocket
{
    /// <summary>
    /// Asynchronously sends a packet to the client socket with the provided key if it exists.
    /// </summary>
    /// <param name="packet">The packet to send.</param>
    /// <param name="key">The key of the socket to send to.</param>
    /// <param name="cancellationToken">Optional cancellation token used to cancel the send operation.</param>
    /// <returns>The same instance of ConcurrentSocketGroup for method chaining.</returns>
    public async Task<ConcurrentSocketGroup<TKey, TValue>> SendPacketAsync(
        IPacket packet,
        TKey key,
        CancellationToken cancellationToken = default
    )
    {
        if (!TryGetValue(key, out var socket))
            return this;

        await socket.SendPacketAsync(packet, cancellationToken);

        return this;
    }

    /// <summary>
    /// Asynchronously dispatches a packet to all client socket values in the group;
    /// </summary>
    /// <param name="packet">The packet to dispatch.</param>
    /// <param name="cancellationToken">Optional cancellation token used to cancel the dispatch.</param>
    /// <returns>The same instance of ConcurrentSocketGroup for method chaining.</returns>
    public async Task<ConcurrentSocketGroup<TKey, TValue>> DispatchPacketAsync(
        IPacket packet,
        CancellationToken cancellationToken = default
    )
    {
        await Task.WhenAll(Values.Select(s => s.SendPacketAsync(packet, cancellationToken)));

        return this;
    }
}
