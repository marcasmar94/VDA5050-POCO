namespace VDA5050_POCO.Models.V2_1_0;

using System;
using Newtonsoft.Json;

/// <summary>
/// Represents the AGV position and/or velocity for visualization purposes. Can be published at a higher rate if desired. Since bandwidth may be expensive depending on the update rate for this topic, all fields are optional.
/// </summary>
[JsonObject]
public record Visualization
{
    /// <summary>
    /// Header ID of the message. The headerId is defined per topic and incremented by 1 with each sent (but not necessarily received) message.
    /// </summary>
    [JsonProperty("headerId")]
    public int? HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ffZ).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch].
    /// </summary>
    [JsonProperty("version")]
    public string? Version { get; init; }

    /// <summary>
    /// Manufacturer of the AGV.
    /// </summary>
    [JsonProperty("manufacturer")]
    public string? Manufacturer { get; init; }

    /// <summary>
    /// Serial number of the AGV.
    /// </summary>
    [JsonProperty("serialNumber")]
    public string? SerialNumber { get; init; }

    /// <summary>
    /// The AGV's position.
    /// </summary>
    [JsonProperty("agvPosition")]
    public AgvPosition? AgvPosition { get; init; }

    /// <summary>
    /// The AGV's velocity in vehicle coordinates.
    /// </summary>
    [JsonProperty("velocity")]
    public Velocity? Velocity { get; init; }
}

/// <summary>
/// Represents the position of the AGV.
/// </summary>
[JsonObject]
public record AgvPosition
{
    /// <summary>
    /// X-position on the map in reference to the map coordinate system. Precision is up to the specific implementation.
    /// </summary>
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-position on the map in reference to the map coordinate system. Precision is up to the specific implementation.
    /// </summary>
    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Absolute orientation of the AGV on the node.
    /// </summary>
    [JsonProperty("theta", Required = Required.Always)]
    public required double Theta { get; init; }

    /// <summary>
    /// Unique identification of the map in which the position is referenced.
    /// </summary>
    [JsonProperty("mapId", Required = Required.Always)]
    public required string MapId { get; init; }

    /// <summary>
    /// True if the AGV's position is initialized, false if the position is not initialized.
    /// </summary>
    [JsonProperty("positionInitialized", Required = Required.Always)]
    public required bool PositionInitialized { get; init; }

    /// <summary>
    /// Localization score for SLAM-based vehicles, if the AGV can communicate it.
    /// </summary>
    [JsonProperty("localizationScore")]
    public double? LocalizationScore { get; init; }

    /// <summary>
    /// Value for position deviation range in meters. Can be used if the AGV is able to derive it.
    /// </summary>
    [JsonProperty("deviationRange")]
    public double? DeviationRange { get; init; }
}

/// <summary>
/// Represents the velocity of the AGV in vehicle coordinates.
/// </summary>
[JsonObject]
public record Velocity
{
    /// <summary>
    /// Velocity in the x-axis of the vehicle coordinate system.
    /// </summary>
    [JsonProperty("vx")]
    public double? Vx { get; init; }

    /// <summary>
    /// Velocity in the y-axis of the vehicle coordinate system.
    /// </summary>
    [JsonProperty("vy")]
    public double? Vy { get; init; }

    /// <summary>
    /// Angular velocity around the z-axis of the vehicle coordinate system.
    /// </summary>
    [JsonProperty("omega")]
    public double? Omega { get; init; }
}
