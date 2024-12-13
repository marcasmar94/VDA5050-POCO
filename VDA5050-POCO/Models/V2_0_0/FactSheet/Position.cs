using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Represents a position on a 2D or 3D plane with optional rotation and metadata.
/// Used for node positions, AGV positions, and bounding box references.
/// </summary>
public record Position
{
    /// <summary>
    /// X-coordinate of the position relative to the AGV or a global coordinate system.
    /// </summary>
    [JsonProperty(PropertyName = "x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-coordinate of the position relative to the AGV or a global coordinate system.
    /// </summary>
    [JsonProperty(PropertyName = "y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Z-coordinate of the position (for 3D positions or bounding boxes). 
    /// This field is optional and may not be present in 2D use cases.
    /// </summary>
    [JsonProperty(PropertyName = "z", NullValueHandling = NullValueHandling.Ignore)]
    public double? Z { get; init; }

    /// <summary>
    /// Angle of rotation (theta) in radians relative to the AGV's orientation. 
    /// Typically ranges from -π to π (in radians).
    /// </summary>
    [JsonProperty(PropertyName = "theta", NullValueHandling = NullValueHandling.Ignore)]
    public double? Theta { get; init; }

    /// <summary>
    /// Allowed deviation in X/Y position. Used in node positions for precision.
    /// If set, it defines how much the AGV can deviate from this position.
    /// </summary>
    [JsonProperty(PropertyName = "allowedDeviationXY", NullValueHandling = NullValueHandling.Ignore)]
    public double? AllowedDeviationXY { get; init; }

    /// <summary>
    /// Allowed deviation in theta (orientation) in radians. Used to specify how much the orientation of the AGV can deviate.
    /// </summary>
    [JsonProperty(PropertyName = "allowedDeviationTheta", NullValueHandling = NullValueHandling.Ignore)]
    public double? AllowedDeviationTheta { get; init; }

    /// <summary>
    /// Unique identifier of the map where this position is defined. 
    /// Required when multiple maps or floors are used.
    /// </summary>
    [JsonProperty(PropertyName = "mapId", Required = Required.Always)]
    public required string MapId { get; init; }

    /// <summary>
    /// Descriptive information about the map. 
    /// This is optional metadata often used for debugging or display purposes.
    /// </summary>
    [JsonProperty(PropertyName = "mapDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string? MapDescription { get; init; }
}
