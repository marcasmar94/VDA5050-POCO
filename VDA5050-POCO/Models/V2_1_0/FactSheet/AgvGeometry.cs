using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Detailed definition of AGV geometry.
/// </summary>
[JsonObject]
public record AgvGeometry
{
    /// <summary>
    /// List of wheels, containing wheel arrangement and geometry.
    /// </summary>
    [JsonProperty("wheelDefinitions")]
    public List<WheelDefinition>? WheelDefinitions { get; init; }

    /// <summary>
    /// List of AGV-envelope curves in 2D.
    /// </summary>
    [JsonProperty("envelopes2d")]
    public List<Envelope2D>? Envelopes2D { get; init; }

    /// <summary>
    /// List of AGV-envelope curves in 3D (german: "Hüllkurven").
    /// </summary>
    [JsonProperty("envelopes3d")]
    public List<Envelope3D>? Envelopes3D { get; init; }
}

/// <summary>
/// Represents a wheel definition containing wheel arrangement and geometry.
/// </summary>
[JsonObject]
public record WheelDefinition
{
    /// <summary>
    /// Wheel type. Possible values are: "DRIVE", "CASTER", "FIXED", "MECANUM".
    /// </summary>
    [JsonProperty("type", Required = Required.Always)]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public required WheelType Type { get; init; }

    /// <summary>
    /// True if the wheel is actively driven (de: angetrieben).
    /// </summary>
    [JsonProperty("isActiveDriven", Required = Required.Always)]
    public required bool IsActiveDriven { get; init; }

    /// <summary>
    /// True if the wheel is actively steered (de: aktiv gelenkt).
    /// </summary>
    [JsonProperty("isActiveSteered", Required = Required.Always)]
    public required bool IsActiveSteered { get; init; }

    /// <summary>
    /// Position of the wheel in AGV-coordinate system.
    /// </summary>
    [JsonProperty("position", Required = Required.Always)]
    public required WheelPosition Position { get; init; }

    /// <summary>
    /// Nominal diameter of the wheel (in meters).
    /// </summary>
    [JsonProperty("diameter", Required = Required.Always)]
    public required double Diameter { get; init; }

    /// <summary>
    /// Nominal width of the wheel (in meters).
    /// </summary>
    [JsonProperty("width", Required = Required.Always)]
    public required double Width { get; init; }

    /// <summary>
    /// Nominal displacement of the wheel's center to the rotation point (necessary for caster wheels).
    /// If the parameter is not defined, it is assumed to be 0.
    /// </summary>
    [JsonProperty("centerDisplacement")]
    public double? CenterDisplacement { get; init; }

    /// <summary>
    /// Free text that can be used by the manufacturer to define constraints.
    /// </summary>
    [JsonProperty("constraints")]
    public string? Constraints { get; init; }
}

/// <summary>
/// Represents the possible wheel types.
/// </summary>
public enum WheelType
{
    /// <summary>
    /// Drive wheel.
    /// </summary>
    DRIVE,

    /// <summary>
    /// Caster wheel.
    /// </summary>
    CASTER,

    /// <summary>
    /// Fixed wheel.
    /// </summary>
    FIXED,

    /// <summary>
    /// Mecanum wheel.
    /// </summary>
    MECANUM
}

/// <summary>
/// Represents the position of a wheel in the AGV-coordinate system.
/// </summary>
[JsonObject]
public record WheelPosition
{
    /// <summary>
    /// X-position in the AGV-coordinate system (in meters).
    /// </summary>
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-position in the AGV-coordinate system (in meters).
    /// </summary>
    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Orientation of the wheel in the AGV-coordinate system (in radians).
    /// Necessary for fixed wheels.
    /// </summary>
    [JsonProperty("theta")]
    public double? Theta { get; init; }
}

/// <summary>
/// Represents an AGV envelope curve in 2D.
/// </summary>
[JsonObject]
public record Envelope2D
{
    /// <summary>
    /// Name of the envelope curve set.
    /// </summary>
    [JsonProperty("set", Required = Required.Always)]
    public required string Set { get; init; }

    /// <summary>
    /// Envelope curve as an x/y-polygon.
    /// The polygon is assumed as closed and must be non-self-intersecting.
    /// </summary>
    [JsonProperty("polygonPoints", Required = Required.Always)]
    public required List<PolygonPoint> PolygonPoints { get; init; }

    /// <summary>
    /// Free text description of the envelope curve set.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}

/// <summary>
/// Represents a point in a 2D polygon.
/// </summary>
[JsonObject]
public record PolygonPoint
{
    /// <summary>
    /// X-position of the polygon point (in meters).
    /// </summary>
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-position of the polygon point (in meters).
    /// </summary>
    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }
}

/// <summary>
/// Represents an AGV envelope curve in 3D.
/// </summary>
[JsonObject]
public record Envelope3D
{
    /// <summary>
    /// Name of the envelope curve set.
    /// </summary>
    [JsonProperty("set", Required = Required.Always)]
    public required string Set { get; init; }

    /// <summary>
    /// Format of the data (e.g., DXF).
    /// </summary>
    [JsonProperty("format", Required = Required.Always)]
    public required string Format { get; init; }

    /// <summary>
    /// 3D-envelope curve data, format specified in the 'format' field.
    /// </summary>
    [JsonProperty("data")]
    public object? Data { get; init; }

    /// <summary>
    /// Protocol and URL definition for downloading the 3D-envelope curve data
    /// (e.g., ftp://xxx.yyy.com/ac4dgvhoif5tghji).
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; init; }

    /// <summary>
    /// Free text description of the envelope curve set.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}