﻿using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Kademlia
{

    /// <summary>
    /// Represents a Kademlia network engine.
    /// </summary>
    /// <typeparam name="TKNodeId"></typeparam>
    /// <typeparam name="TKNodeData"></typeparam>
    public interface IKEngine<TKNodeId, TKNodeData> : IKEngine<TKNodeId>
        where TKNodeId : unmanaged
    {

        /// <summary>
        /// Gets the node data of the node itself.
        /// </summary>
        TKNodeData SelfData { get; }

    }

    /// <summary>
    /// Represents a Kademlia network engine.
    /// </summary>
    /// <typeparam name="TKNodeId"></typeparam>
    public interface IKEngine<TKNodeId>
        where TKNodeId : unmanaged
    {

        /// <summary>
        /// Gets the Node ID of the node itself.
        /// </summary>
        TKNodeId SelfId { get; }

        /// <summary>
        /// Attempts to connect the engine to one of the specified endpoints.
        /// </summary>
        /// <param name="targets"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ConnectAsync(IKEndpointSet<TKNodeId> targets, CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to connect the engine to one of the specified endpoints.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ConnectAsync(IKEndpoint<TKNodeId> target, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the value for the specified key currently stored in the Kademlia network.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<KValueInfo?> GetValueAsync(in TKNodeId key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Invoked to handle incoming PING requests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<KPingResponse<TKNodeId>> OnPingAsync(in TKNodeId sender, IKEndpoint<TKNodeId> source, in KPingRequest<TKNodeId> request, CancellationToken cancellationToken);

        /// <summary>
        /// Invoked to handle incoming STORE requests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<KStoreResponse<TKNodeId>> OnStoreAsync(in TKNodeId sender, IKEndpoint<TKNodeId> source, in KStoreRequest<TKNodeId> request, CancellationToken cancellationToken);

        /// <summary>
        /// Invoked to handle incoming FIND_NODE requests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<KFindNodeResponse<TKNodeId>> OnFindNodeAsync(in TKNodeId sender, IKEndpoint<TKNodeId> source, in KFindNodeRequest<TKNodeId> request, CancellationToken cancellationToken);

        /// <summary>
        /// Invoked to handle incoming FIND_VALUE requests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="endpoint"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<KFindValueResponse<TKNodeId>> OnFindValueAsync(in TKNodeId sender, IKEndpoint<TKNodeId> endpoint, in KFindValueRequest<TKNodeId> request, CancellationToken cancellationToken);

    }

}
