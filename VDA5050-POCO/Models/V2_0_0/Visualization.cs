using VDA5050_POCO.Models.V2_0_0.Common;

namespace VDA5050_POCO.Models.V2_0_0;

using System;
using Newtonsoft.Json;

/// <summary>
/// Represents the AGV position and/or velocity for visualization purposes.
/// Can be published at a higher rate if desired. Since bandwidth may be expensive depending on the update rate for this topic, all fields are optional.
/// </summary>
[JsonObject]
public record Visualization
{
    /// <summary>
    /// Header ID of the message, defined per topic and incremented with each sent message.
    /// </summary>
    [JsonProperty(PropertyName = "headerId")]
    public int? HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ).
    /// </summary>
    [JsonProperty(PropertyName = "timestamp")]
    public DateTime? Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch].
    /// </summary>
    [JsonProperty(PropertyName = "version")]
    public string? Version { get; init; }

    /// <summary>
    /// Manufacturer of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "manufacturer")]
    public string? Manufacturer { get; init; }

    /// <summary>
    /// Serial number of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "serialNumber")]
    public string? SerialNumber { get; init; }

    /// <summary>
    /// Represents the AGV's position.
    /// </summary>
    [JsonProperty(PropertyName = "agvPosition")]
    public AgvPosition? AgvPosition { get; init; }

    /// <summary>
    /// Represents the AGV's velocity in vehicle coordinates.
    /// </summary>
    [JsonProperty(PropertyName = "velocity")]
    public Velocity? Velocity { get; init; }
}


