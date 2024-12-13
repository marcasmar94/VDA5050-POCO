using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;


/// <summary>
/// Detailed definition of the AGV's geometry.
/// </summary>
public record AGVGeometry
{
    [JsonProperty(PropertyName = "wheelDefinitions", Required = Required.Always)]
    public required List<WheelDefinition> WheelDefinitions { get; init; }

    [JsonProperty(PropertyName = "envelopes2d", Required = Required.Always)]
    public required List<Envelope2D> Envelopes2D { get; init; }

    [JsonProperty(PropertyName = "envelopes3d", NullValueHandling = NullValueHandling.Ignore)]
    public List<Envelope3D>? Envelopes3D { get; init; }
}

/// <summary>
/// Describes the wheel configuration and geometry of the AGV.
/// </summary>
public record WheelDefinition
{
    [JsonProperty(PropertyName = "type", Required = Required.Always)]
    public required string Type { get; init; }

    [JsonProperty(PropertyName = "isActiveDriven", Required = Required.Always)]
    public required bool IsActiveDriven { get; init; }

    [JsonProperty(PropertyName = "isActiveSteered", Required = Required.Always)]
    public required bool IsActiveSteered { get; init; }

    [JsonProperty(PropertyName = "position", Required = Required.Always)]
    public required Position Position { get; init; }

    [JsonProperty(PropertyName = "diameter", Required = Required.Always)]
    public required double Diameter { get; init; }

    [JsonProperty(PropertyName = "width", Required = Required.Always)]
    public required double Width { get; init; }

    [JsonProperty(PropertyName = "centerDisplacement", NullValueHandling = NullValueHandling.Ignore)]
    public double? CenterDisplacement { get; init; }

    [JsonProperty(PropertyName = "constraints", NullValueHandling = NullValueHandling.Ignore)]
    public string? Constraints { get; init; }
}

public record Envelope2D
{
    [JsonProperty(PropertyName = "set", Required = Required.Always)]
    public required string Set { get; init; }

    [JsonProperty(PropertyName = "polygonPoints", Required = Required.Always)]
    public required List<Position> PolygonPoints { get; init; }

    [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; init; }
}

public record Envelope3D
{
    [JsonProperty(PropertyName = "set", Required = Required.Always)]
    public required string Set { get; init; }

    [JsonProperty(PropertyName = "format", Required = Required.Always)]
    public required string Format { get; init; }

    [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
    public object? Data { get; init; }

    [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; init; }

    [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; init; }
}