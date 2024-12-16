namespace VDA5050_POCO.Models.V2_1_0;

using System;
using Newtonsoft.Json;

/// <summary>
/// Represents the connection message sent by the AGV.
/// </summary>
[JsonObject]
public record Connection
{
    /// <summary>
    /// Header ID of the message. Incremented by 1 with each sent message.
    /// </summary>
    [JsonProperty(PropertyName = "headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ).
    /// </summary>
    [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch].
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
    /// Connection state between the AGV and broker.
    /// </summary>
    [JsonProperty(PropertyName = "connectionState", Required = Required.Always)]
    public required ConnectionState ConnectionState { get; init; }
}

/// <summary>
/// Enumeration of possible connection states.
/// </summary>
public enum ConnectionState
{
    /// <summary>
    /// Connection between AGV and broker is active.
    /// </summary>
    ONLINE,

    /// <summary>
    /// Connection between AGV and broker has gone offline in a coordinated way.
    /// </summary>
    OFFLINE,

    /// <summary>
    /// The connection between AGV and broker has unexpectedly ended.
    /// </summary>
    CONNECTIONBROKEN
}