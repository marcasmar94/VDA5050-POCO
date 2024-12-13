using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;


/// <summary>
/// Describes the load handling and load capability of the AGV.
/// </summary>
public record LoadSpecification
{
    [JsonProperty(PropertyName = "loadPositions", Required = Required.Always)]
    public required List<string> LoadPositions { get; init; }

    [JsonProperty(PropertyName = "loadSets", Required = Required.Always)]
    public required List<LoadSet> LoadSets { get; init; }
}

public record LoadSet
{
    [JsonProperty(PropertyName = "setName", Required = Required.Always)]
    public required string SetName { get; init; }

    [JsonProperty(PropertyName = "loadType", Required = Required.Always)]
    public required string LoadType { get; init; }

    [JsonProperty(PropertyName = "loadPositions", Required = Required.Always)]
    public required List<string> LoadPositions { get; init; }

    [JsonProperty(PropertyName = "boundingBoxReference", Required = Required.Always)]
    public required Position BoundingBoxReference { get; init; }

    [JsonProperty(PropertyName = "loadDimensions", Required = Required.Always)]
    public required LoadDimensions LoadDimensions { get; init; }
}