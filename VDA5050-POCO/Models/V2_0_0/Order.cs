namespace VDA5050_POCO.Models.V2_0_0;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Represents the order message sent from master control to the AGV.
/// </summary>
[JsonObject]
public record Order
{
    /// <summary>
    /// Header ID of the message. Incremented by 1 with each sent message.
    /// </summary>
    [JsonProperty(PropertyName = "headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ).
    /// Example: "1991-03-11T11:40:03.12Z"
    /// </summary>
    [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch].
    /// Example: "1.3.2"
    /// </summary>
    [JsonProperty(PropertyName = "version", Required = Required.Always)]
    public required string Version { get; init; }

    /// <summary>
    /// Manufacturer of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "manufacturer", Required = Required.Always)]
    public required string Manufacturer { get; init; }

    /// <summary>
    /// Serial number of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "serialNumber", Required = Required.Always)]
    public required string SerialNumber { get; init; }

    /// <summary>
    /// Unique identifier for the order.
    /// </summary>
    [JsonProperty(PropertyName = "orderId", Required = Required.Always)]
    public required string OrderId { get; init; }

    /// <summary>
    /// Unique identifier for updates related to the order.
    /// </summary>
    [JsonProperty(PropertyName = "orderUpdateId", Required = Required.Always)]
    public required int OrderUpdateId { get; init; }

    /// <summary>
    /// Unique identifier for the zone set used for navigation or planning.
    /// Optional: Do not add to message if no zones are used.
    /// </summary>
    [JsonProperty(PropertyName = "zoneSetId")]
    public string? ZoneSetId { get; init; }

    /// <summary>
    /// List of nodes to be traversed for fulfilling the order.
    /// One node is sufficient for a valid order.
    /// </summary>
    [JsonProperty(PropertyName = "nodes", Required = Required.Always)]
    public required List<Node> Nodes { get; init; }

    /// <summary>
    /// List of edges connecting the nodes in the order graph.
    /// </summary>
    [JsonProperty(PropertyName = "edges", Required = Required.Always)]
    public required List<Edge> Edges { get; init; }
}

/// <summary>
/// Represents a node in the order graph.
/// </summary>
public record Node
{
    /// <summary>
    /// Unique identifier for the node.
    /// </summary>
    [JsonProperty(PropertyName = "nodeId", Required = Required.Always)]
    public required string NodeId { get; init; }

    /// <summary>
    /// Sequence number for tracking the order of nodes and edges.
    /// </summary>
    [JsonProperty(PropertyName = "sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    /// <summary>
    /// Indicates whether the node is part of the base plan or horizon plan.
    /// </summary>
    [JsonProperty(PropertyName = "released", Required = Required.Always)]
    public required bool Released { get; init; }

    /// <summary>
    /// Additional information about the node.
    /// </summary>
    [JsonProperty(PropertyName = "nodeDescription")]
    public string? NodeDescription { get; init; }

    /// <summary>
    /// Position of the node on a map.
    /// </summary>
    [JsonProperty(PropertyName = "nodePosition")]
    public NodePosition? NodePosition { get; init; }

    /// <summary>
    /// Actions to be performed at this node.
    /// </summary>
    [JsonProperty(PropertyName = "actions", Required = Required.Always)]
    public required List<Action> Actions { get; init; }
}

/// <summary>
/// Represents the position of a node in the map coordinate system.
/// </summary>
public record NodePosition
{
    /// <summary>
    /// X-coordinate of the position on the map.
    /// </summary>
    [JsonProperty(PropertyName = "x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-coordinate of the position on the map.
    /// </summary>
    [JsonProperty(PropertyName = "y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Unique identifier of the map.
    /// </summary>
    [JsonProperty(PropertyName = "mapId", Required = Required.Always)]
    public required string MapId { get; init; }

    /// <summary>
    /// Absolute orientation of the AGV at this node.
    /// Optional: If not defined, AGV can plan the path by itself.
    /// </summary>
    [JsonProperty(PropertyName = "theta")]
    public double? Theta { get; init; }

    /// <summary>
    /// Allowed deviation in meters for the X and Y position.
    /// Optional: If not defined, no deviation is allowed.
    /// </summary>
    [JsonProperty(PropertyName = "allowedDeviationXY")]
    public double? AllowedDeviationXY { get; init; }

    /// <summary>
    /// Allowed deviation in radians for the theta orientation.
    /// </summary>
    [JsonProperty(PropertyName = "allowedDeviationTheta")]
    public double? AllowedDeviationTheta { get; init; }

    /// <summary>
    /// Additional information about the map.
    /// </summary>
    [JsonProperty(PropertyName = "mapDescription")]
    public string? MapDescription { get; init; }
}

/// <summary>
/// Represents an edge in the order graph.
/// </summary>
public record Edge
{
    /// <summary>
    /// Unique identifier for the edge.
    /// </summary>
    [JsonProperty(PropertyName = "edgeId", Required = Required.Always)]
    public required string EdgeId { get; init; }

    /// <summary>
    /// Sequence number for tracking the order of nodes and edges.
    /// </summary>
    [JsonProperty(PropertyName = "sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    /// <summary>
    /// Indicates whether the edge is part of the base plan or horizon plan.
    /// </summary>
    [JsonProperty(PropertyName = "released", Required = Required.Always)]
    public required bool Released { get; init; }

    /// <summary>
    /// Node ID of the start node.
    /// </summary>
    [JsonProperty(PropertyName = "startNodeId", Required = Required.Always)]
    public required string StartNodeId { get; init; }

    /// <summary>
    /// Node ID of the end node.
    /// </summary>
    [JsonProperty(PropertyName = "endNodeId", Required = Required.Always)]
    public required string EndNodeId { get; init; }

    /// <summary>
    /// Actions to be performed along this edge.
    /// </summary>
    [JsonProperty(PropertyName = "actions", Required = Required.Always)]
    public required List<Action> Actions { get; init; }

    /// <summary>
    /// Permitted maximum speed of the AGV along this edge, in meters per second.
    /// </summary>
    [JsonProperty(PropertyName = "maxSpeed")]
    public double? MaxSpeed { get; init; }

    /// <summary>
    /// Verbose description of the edge.
    /// </summary>
    [JsonProperty(PropertyName = "edgeDescription")]
    public string? EdgeDescription { get; init; }
}


