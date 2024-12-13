using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.Common;

/// <summary>
/// Represents the AGV's velocity in vehicle coordinates.
/// </summary>
public record Velocity
{
    /// <summary>
    /// Velocity of the AGV in the X-direction (forward/backward) in meters per second.
    /// </summary>
    [JsonProperty(PropertyName = "vx")]
    public double? Vx { get; init; }

    /// <summary>
    /// Velocity of the AGV in the Y-direction (lateral) in meters per second.
    /// </summary>
    [JsonProperty(PropertyName = "vy")]
    public double? Vy { get; init; }

    /// <summary>
    /// Angular velocity (omega) of the AGV in radians per second.
    /// </summary>
    [JsonProperty(PropertyName = "omega")]
    public double? Omega { get; init; }
}