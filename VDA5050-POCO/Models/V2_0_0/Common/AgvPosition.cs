using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.Common;


/// <summary>
/// Represents the AGV's position.
/// </summary>
public record AgvPosition
{
    /// <summary>
    /// X-coordinate of the AGV in the map's coordinate system.
    /// </summary>
    [JsonProperty(PropertyName = "x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-coordinate of the AGV in the map's coordinate system.
    /// </summary>
    [JsonProperty(PropertyName = "y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Absolute orientation (theta) of the AGV in radians.
    /// </summary>
    [JsonProperty(PropertyName = "theta", Required = Required.Always)]
    public required double Theta { get; init; }

    /// <summary>
    /// Unique identifier of the map where the AGV's position is referenced.
    /// </summary>
    [JsonProperty(PropertyName = "mapId", Required = Required.Always)]
    public required string MapId { get; init; }

    /// <summary>
    /// True if the AGV's position is initialized; otherwise, false.
    /// </summary>
    [JsonProperty(PropertyName = "positionInitialized", Required = Required.Always)]
    public required bool PositionInitialized { get; init; }

    /// <summary>
    /// Localization score for SLAM-based vehicles, if the AGV can communicate it. (0.0 = unknown, 1.0 = known)
    /// </summary>
    [JsonProperty(PropertyName = "localizationScore")]
    public double? LocalizationScore { get; init; }

    /// <summary>
    /// Deviation range of the AGV's position in meters, if the AGV can provide this information.
    /// </summary>
    [JsonProperty(PropertyName = "deviationRange")]
    public double? DeviationRange { get; init; }
}
